using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipe;
        BindingSource bindSource = new();
        DataTable dtStaff;
        DataTable dtCuisineType;
        private enum StatusEnum { Draft, Published, Archived }
        StatusEnum currentRecipeStatus;
        Color defaultStatusBtnBackColor = Color.WhiteSmoke;
        Color selectedStatusBtnBackColor = Color.LightBlue;

        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnDraft.Click += BtnDraft_Click;
            btnPublish.Click += BtnPublish_Click;
            btnArchive.Click += BtnArchive_Click;
        }

        public void ShowForm(int recipeId)
        {
            dtRecipe = Recipe.Load(recipeId);
            bindSource.DataSource = dtRecipe;
            if (recipeId < 1)
            {
                dtRecipe.Rows.Add();
            }
            
            dtStaff = Recipe.GetStaffList();
            dtCuisineType = Recipe.GetCuisineTypeList();

            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindSource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindSource);
            WindowsFormsUtility.SetControlBinding(lblDraftTime, bindSource);
            WindowsFormsUtility.SetControlBinding(lblPublishedTime, bindSource);
            WindowsFormsUtility.SetControlBinding(lblArchivedTime, bindSource);
            WindowsFormsUtility.SetListBinding(lstStaff, dtStaff, dtRecipe, "Staff");
            WindowsFormsUtility.SetListBinding(lstCuisineType, dtCuisineType, dtRecipe, "CuisineType");

            this.Show();
            SetRecipeStatusEnum();
            SetRecipeStatusButtons();
        }

        private void Save()
        {
            Application.UseWaitCursor = true;
            try
            {
                dtRecipe.Rows[0]["RecipeStatus"] = currentRecipeStatus;
                Recipe.Save(dtRecipe);
                bindSource.ResetBindings(false);
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
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this Recipe", "Delete Recipe?", MessageBoxButtons.YesNo);
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

        private void SetRecipeStatusEnum()
        {
            currentRecipeStatus = StatusEnum.Draft;
            if (!string.IsNullOrEmpty(lblArchivedTime.Text))
            {
                currentRecipeStatus = StatusEnum.Archived;
            }
            else if (!string.IsNullOrEmpty(lblPublishedTime.Text))
            {
                currentRecipeStatus = StatusEnum.Published;
            }
            SetRecipeStatusButtons();
        }

        private void SetRecipeStatusEnum(StatusEnum recipeStatus)
        {
            currentRecipeStatus = recipeStatus;
            SetRecipeStatusButtons();
        }

        private void SetRecipeStatusButtons()
        {
            foreach (Control c in tblStatusBtns.Controls)
            {
                c.BackColor = defaultStatusBtnBackColor;
                if (c.Text == currentRecipeStatus.ToString())
                {
                    c.BackColor = selectedStatusBtnBackColor;
                }
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

        private void BtnArchive_Click(object? sender, EventArgs e)
        {
            SetRecipeStatusEnum(StatusEnum.Archived);
            SetRecipeStatusButtons();
        }

        private void BtnPublish_Click(object? sender, EventArgs e)
        {
            SetRecipeStatusEnum(StatusEnum.Published);
            SetRecipeStatusButtons();
        }

        private void BtnDraft_Click(object? sender, EventArgs e)
        {
            SetRecipeStatusEnum(StatusEnum.Draft);
            SetRecipeStatusButtons();
        }


    }
}