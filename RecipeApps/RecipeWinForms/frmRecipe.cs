using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipe = new();
        BindingSource bindSource = new();
        DataTable dtStaff = new();
        DataTable dtCuisineType = new();
        DataTable dtRecipeIngredients = new();
        DataTable dtRecipeInstructions = new();
        DataTable dtIngredients = new();
        DataTable dtUnitOfMeasure = new();
        int recipeId = 0;
        string deleteColName = "DelCol";

        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            btnSaveIngredients.Click += BtnSaveIngredients_Click;
            btnSaveInstructions.Click += BtnSaveInstructions_Click;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            gIngredients.DataError += GIngredients_DataError;
            gInstructions.CellContentClick += GInstructions_CellContentClick;
            gInstructions.DataError += GInstructions_DataError;
            this.Shown += FrmRecipe_Shown;
        }

        public void LoadForm(int pkId)
        {
            recipeId = pkId;
            LoadData();
            SetFormData();
            SetButtons();
        }

        private void SetFormData()
        {
            this.Tag = recipeId;
            this.Text = Recipe.GetDesc(recipeId, dtRecipe);
        }

        private void LoadData()
        {
            dtStaff = DataMaintenance.GetAll(DataMaintenance.DataType.Staff);
            dtCuisineType = DataMaintenance.GetAll(DataMaintenance.DataType.CuisineType);
            dtRecipeIngredients = Recipe.GetRecipeIngredients(recipeId);
            dtRecipeInstructions = Recipe.GetRecipeInstructions(recipeId);
            dtIngredients = DataMaintenance.GetAll(DataMaintenance.DataType.Ingredient);
            dtUnitOfMeasure = DataMaintenance.GetAll(DataMaintenance.DataType.UnitOfMeasure, true);
            dtRecipe = Recipe.Get(recipeId);
            if (recipeId < 1)
            {
                dtRecipe.Rows.Add();
            }
        }

        private void BindData()
        {
            bindSource.DataSource = dtRecipe;

            gIngredients.DataSource = dtRecipeIngredients;
            gInstructions.DataSource = dtRecipeInstructions;

            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindSource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindSource);
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, bindSource);
            WindowsFormsUtility.SetControlBinding(lblDraftTime, bindSource);
            WindowsFormsUtility.SetControlBinding(lblPublishedTime, bindSource);
            WindowsFormsUtility.SetControlBinding(lblArchivedTime, bindSource);
            WindowsFormsUtility.SetListBinding(lstUserName, dtStaff, dtRecipe, "Staff");
            WindowsFormsUtility.SetListBinding(lstCuisineTypeName, dtCuisineType, dtRecipe, "CuisineType");

            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, dtUnitOfMeasure, "UnitOfMeasure", "UnitName");
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, dtIngredients, "Ingredient", "IngredientName");
            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredients, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gIngredients);

            WindowsFormsUtility.AddDeleteButtonToGrid(gInstructions, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gInstructions);
        }

        private void SetButtons()
        {
            bool n = recipeId == 0 ? false : true;
            btnChangeStatus.Enabled = n;
            btnDelete.Enabled = n;
            btnSaveIngredients.Enabled = n;
            btnSaveInstructions.Enabled = n;
        }

        private void SaveRecipe()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtRecipe);
                recipeId = DataMaintenance.GetValueFromFirstRowAsInt(dtRecipe, "RecipeId");
                SetFormData();
                SetButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }


        private void DeleteRecipe()
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this Recipe", Application.ProductName, MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return;
            }

            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(recipeId);
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeList));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void OpenRecipeStatusForm()
        {
            if (MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeStatus), recipeId);
            }
        }

        private void SaveRecipeChild(DataTable dt, string tableName)
        {
            var rows = dt.Select("", "Seq ASC");
            int seq = 1;
            foreach (DataRow r in rows)
            {
                if (r["Seq"] is int && (int)r["Seq"] != seq)
                {
                    MessageBox.Show("Seq not correct, make sure to start from 1 and not skip any number", Application.ProductName);
                    return;
                }
                seq++;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Recipe.SaveRecipeChild(dt, tableName, recipeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void HandleGridFormatError(int columnIndex, DataGridView grid)
        {
            if (grid.Columns["Seq"].Index == columnIndex)
            {
                MessageBox.Show("Seq should be a number (int)", Application.ProductName);
            }
            else if (grid.Columns["Amount"].Index == columnIndex)
            {
                MessageBox.Show("Amount should be a number (decimal)", Application.ProductName);
            }
        }

        private void DeleteRecipeChild(DataGridView grid, int rowIndex, string tableName)
        {
            if (grid.Rows[rowIndex].Cells[$"{tableName}Id"].Value.ToString() != "")
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete?", Application.ProductName, MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return;
                }

                int pkId = WindowsFormsUtility.GetPkIdFromGrid(grid, $"{tableName}Id", rowIndex);
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Recipe.DeleteRecipeChild(tableName, pkId);
                    grid.Rows.RemoveAt(rowIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }


        private void BtnChangeStatus_Click(object? sender, EventArgs e)
        {
            OpenRecipeStatusForm();
        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            DeleteRecipe();
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveRecipe();
        }
        private void BtnSaveInstructions_Click(object? sender, EventArgs e)
        {
            SaveRecipeChild(dtRecipeInstructions, "RecipeInstruction");
        }
        private void BtnSaveIngredients_Click(object? sender, EventArgs e)
        {
            SaveRecipeChild(dtRecipeIngredients, "RecipeIngredient");
        }
        private void GInstructions_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gInstructions.Columns[e.ColumnIndex].Name == deleteColName && e.RowIndex > -1)
            {
                DeleteRecipeChild(gInstructions, e.RowIndex, "RecipeInstruction");
            }
        }
        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gIngredients.Columns[e.ColumnIndex].Name == deleteColName && e.RowIndex > -1)
            {
                DeleteRecipeChild(gIngredients, e.RowIndex, "RecipeIngredient");
            }
        }
        private void FrmRecipe_Shown(object? sender, EventArgs e)
        {
            BindData();
        }
        private void GInstructions_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException && sender is DataGridView g)
            {
                HandleGridFormatError(e.ColumnIndex, g);
            }
        }
        private void GIngredients_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException && sender is DataGridView g)
            {
                HandleGridFormatError(e.ColumnIndex, g);
            }
        }
    }
}