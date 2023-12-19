using RecipeSystem;
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
            gRecipes.CellContentClick += GRecipes_CellContentClick;
            this.Shown += FrmCookbook_Shown;
        }

        public void LoadForm(int pkId)
        {
            cookBookId = pkId;
            LoadData();
            SetFormData();
            BindData();
            SetButtonsEnabled();
        }

        private void LoadData()
        {
            dtCookBook = Cookbook.Get(cookBookId);

            dtCookBook.Rows.Add();
            if (dtCookBook.Rows.Count == 0)
            {
                dtCookBook.Rows.Add();
            }

            dtCookbookRecipes = Cookbook.GetCookbookRecipes(cookBookId);
            dtStaff = DataMaintenance.GetAll(DataMaintenance.DataType.Staff);
            dtAllRecipes = Recipe.GetAll();
        }

        private void SetFormData()
        {
            this.Tag = cookBookId;
            this.Text = Cookbook.GetDesc(cookBookId, dtCookBook);
        }

        private void BindData()
        {
            cookbookBindSource.DataSource = dtCookBook;
            gRecipes.DataSource = dtCookbookRecipes;

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
                    cookBookId = DataMaintenance.GetValueFromFirstRowAsInt(dtCookBook, "CookbookId");
                    SetButtonsEnabled();
                    cookbookBindSource.ResetBindings(false);
                    SetFormData();
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
                MessageBox.Show("Invalid price");
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
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookList));
                this.Close();
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
                Cookbook.SaveCookbookRecipes(dtCookbookRecipes, cookBookId);
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
        private void GRecipes_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gRecipes.Columns[e.ColumnIndex].Name == deleteColName && e.RowIndex > -1)
            {
                if (gRecipes.Rows[e.RowIndex].Cells["CookbookRecipeId"].Value.ToString() != "")
                {
                    DeleteCookbookRecipe(e.RowIndex);
                }
            }
        }


    }
}
