using System.Data;

namespace RecipeWinForms
{
    public partial class frmCookbook : Form
    {
        int cookBookId = 0;
        DataTable dtCookBook = new();
        BindingSource cookbookBindSource = new();
        DataTable dtStaff = new();
        DataTable dtCookbookRecipes = new();
        DataTable dtAllRecipes = new();
        string deleteColName = "DelCol";

        public frmCookbook()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSaveRecipes.Click += BtnSaveRecipes_Click;
            gRecipes.CellDoubleClick += GRecipes_CellDoubleClick;
            gRecipes.CellContentClick += GRecipes_CellContentClick;
            this.Shown += FrmCookbook_Shown;
        }

        public void LoadForm(int pkId)
        {
            cookBookId = pkId;
            LoadCookbook();
            dtCookbookRecipes = Cookbook.GetCookbookRecipes(cookBookId);
            gRecipes.DataSource = dtCookbookRecipes;
            LoadListData();
            BindFormControls();
            SetButtonsEnabled();
        }

        private void LoadCookbook(bool refresh = false)
        {
            if (refresh)
            {
                cookBookId = DataMaintenance.GetValueFromFirstRowAsInt(dtCookBook, "CookbookId");
            }
            dtCookBook = Cookbook.Get(cookBookId);
            if (dtCookBook.Rows.Count == 0)
            {
                dtCookBook.Rows.Add();
            }
            cookbookBindSource.DataSource = dtCookBook;
            this.Tag = cookBookId;
            this.Text = Cookbook.GetDesc(cookBookId, dtCookBook);
        }

        private void LoadListData()
        {
            dtStaff = DataMaintenance.GetAll(DataMaintenance.DataType.Staff);
            dtAllRecipes = Recipe.GetAll();
        }

        private void BindFormControls()
        {
            WindowsFormsUtility.SetControlBinding(txtCookBookName, cookbookBindSource);
            WindowsFormsUtility.SetControlBinding(txtPrice, cookbookBindSource);
            WindowsFormsUtility.SetControlBinding(lblCreatedDate, cookbookBindSource);
            WindowsFormsUtility.SetControlBinding(cbxActive, cookbookBindSource);
            WindowsFormsUtility.SetListBinding(lstUserName, dtStaff, dtCookBook, "Staff");
            WindowsFormsUtility.AddComboBoxToGrid(gRecipes, dtAllRecipes, "Recipe", "RecipeName");
            WindowsFormsUtility.FormatGridForEdit(gRecipes);
        }

        private void SetButtonsEnabled()
        {
            bool b = cookBookId > 0 ? true : false;
            btnDelete.Enabled = b;
            btnSaveRecipes.Enabled = b;
        }

        private void Save()
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Cookbook.Save(dtCookBook);
                    LoadCookbook(true);
                    SetButtonsEnabled();
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
                MessageBox.Show("Invalide price, format should be $###.##");
            }
        }

        private void Delete()
        {
            DialogResult res = MessageBox.Show($"Are you sure you wanna delete this cookbook?", Application.ProductName, MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Cookbook.Delete(cookBookId);
                this.Close();
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookList));
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

        private void SaveCookbookRecipes()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Cookbook.UpdateCookbookRecipes(dtCookbookRecipes, cookBookId);
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

        private void DeleteCookbookRecipe(int rowIndex)
        {
            DialogResult res = MessageBox.Show("Are you sure you wanna delete this recipe from the cookbook?", Application.ProductName, MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Cookbook.DeleteCookbookRecipes(WindowsFormsUtility.GetPkIdFromGrid(gRecipes, "CookbookRecipeId", rowIndex));
                gRecipes.Rows.RemoveAt(rowIndex);
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

        private void FrmCookbook_Shown(object? sender, EventArgs e)
        {
            WindowsFormsUtility.AddDeleteButtonToGrid(gRecipes, deleteColName);
        }

        private void BtnSaveRecipes_Click(object? sender, EventArgs e)
        {
            SaveCookbookRecipes();
        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
        private void GRecipes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DeleteCookbookRecipe(e.RowIndex);
            }
        }
        private void GRecipes_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gRecipes.Columns[e.ColumnIndex].Name == deleteColName && e.RowIndex > -1)
            {
                DeleteCookbookRecipe(e.RowIndex);
            }
        }
    }
}
