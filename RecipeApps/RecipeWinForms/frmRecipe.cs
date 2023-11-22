using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipe;
        DataTable dtStaff;
        DataTable dtCuisineType;
        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
        }

        public void ShowForm(int recipeId)
        {
            dtRecipe = Recipe.Load(recipeId);
            if (recipeId < 1)
            {
                dtRecipe.Rows.Add();
            }

            dtStaff = Recipe.GetStaffList();
            dtCuisineType = Recipe.GetCuisineTypeList();

            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtRecipe);
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, dtRecipe);
            WindowsFormsUtility.SetControlBinding(dtpDraftTime, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtPublishedTime, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtArchivedTime, dtRecipe);
            WindowsFormsUtility.SetListBinding(lstStaff, dtStaff, dtRecipe, "Staff");
            WindowsFormsUtility.SetListBinding(lstCuisineType, dtCuisineType, dtRecipe, "CuisineType");
            this.Show();
        }

        private void Save()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtRecipe);
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

        private void Delete()
        {
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

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

    }
}