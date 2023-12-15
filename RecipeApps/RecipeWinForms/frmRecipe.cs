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
            gInstructions.CellContentClick += GInstructions_CellContentClick;
            this.Shown += FrmRecipe_Shown;
        }

        public void LoadForm(int pkId)
        {
            recipeId = pkId;
            LoadLists();
            SetFormData();
            SetButtons();
        }

        private void SetFormData(bool refresh = false)
        {
            if (refresh)
            {
                recipeId = DataMaintenance.GetValueFromFirstRowAsInt(dtRecipe, "RecipeId");
            }
            this.Tag = recipeId;
            this.Text = Recipe.GetDesc(recipeId, dtRecipe);
        }

        private void LoadLists()
        {
            dtStaff = DataMaintenance.GetAll(DataMaintenance.DataType.Staff);
            dtCuisineType = DataMaintenance.GetAll(DataMaintenance.DataType.CuisineType);
            dtRecipeIngredients = Recipe.GetRecipeIngredients(recipeId);
            dtRecipeInstructions = Recipe.GetRecipeInstructions(recipeId);
            dtIngredients = DataMaintenance.GetAll(DataMaintenance.DataType.Ingredient);
            dtUnitOfMeasure = DataMaintenance.GetAll(DataMaintenance.DataType.UnitOfMeasure, true);
            dtRecipe = Recipe.Get(recipeId);
            bindSource.DataSource = dtRecipe;
            if (recipeId < 1)
            {
                dtRecipe.Rows.Add();
            }

            gIngredients.DataSource = dtRecipeIngredients;
            gInstructions.DataSource = dtRecipeInstructions;
        }

        private void BindData()
        {
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
                SetFormData(true);
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
                Recipe.Delete(dtRecipe);
                this.Close();
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

        private void OpenRecipeStatusForm()
        {
            if (MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeStatus), recipeId);
            }
        }

        private void SaveRecipeChild(DataTable dt)
        {
            var rows = dt.Select("", "Seq ASC");
            int seq = 1;
            foreach (DataRow r in rows)
            {
                if ((int)r["Seq"] != seq)
                {
                    MessageBox.Show("Seq out of order, make sure to start from 1 and not skip any number");
                    return;
                }
                seq++;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Recipe.SaveRecipeChild(dtRecipeIngredients, "RecipeIngredient", recipeId);
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
                    gIngredients.Rows.RemoveAt(rowIndex);
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
            else
            {
                MessageBox.Show("Cannot delete before saving", Application.ProductName);
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
            SaveRecipeChild(dtRecipeInstructions);
        }
        private void BtnSaveIngredients_Click(object? sender, EventArgs e)
        {
            SaveRecipeChild(dtRecipeIngredients);
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

    }
}