using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipeStatus : Form
    {
        DataTable dtRecipe = new();
        BindingSource bindSource = new();
        enum StatusEnum { Draft, Published, Archived }
        StatusEnum recipeStatus;
        int recipeId = 0;

        public frmRecipeStatus()
        {
            InitializeComponent();
            btnDraft.Tag = StatusEnum.Draft;
            btnPublish.Tag = StatusEnum.Published;
            btnArchive.Tag = StatusEnum.Archived;

            foreach (Control c in tblMain.Controls)
            {
                if (c is Button)
                {
                    c.Click += C_Click;
                }
            }
        }

        public void LoadForm(int pkId)
        {
            recipeId = pkId;
            this.Tag = recipeId;
            dtRecipe = Recipe.Get(recipeId);
            bindSource.DataSource = dtRecipe;
            if (recipeId < 1
                || dtRecipe.Rows.Count != 1
                || !dtRecipe.Columns.Contains("RecipeName")
                || !dtRecipe.Columns.Contains("RecipeStatus"))
            {
                return;
            }

            btnArchive.Enabled = true;
            btnPublish.Enabled = true;
            btnDraft.Enabled = true;
            bool b = Enum.TryParse(dtRecipe.Rows[0]["RecipeStatus"].ToString(), true, out recipeStatus);
            if (b)
            {
                switch (recipeStatus)
                {
                    case StatusEnum.Archived:
                        btnArchive.Enabled = false;
                        break;
                    case StatusEnum.Published:
                        btnPublish.Enabled = false;
                        break;
                    case StatusEnum.Draft:
                        btnDraft.Enabled = false;
                        break;
                }
            }
            else
            {
                return;
            }

            this.Text = $"Change Status - {dtRecipe.Rows[0]["RecipeName"]}";

            WindowsFormsUtility.SetControlBinding(lblRecipeName, bindSource);
            WindowsFormsUtility.SetControlBinding(lblDraftTime, bindSource);
            WindowsFormsUtility.SetControlBinding(lblPublishedTime, bindSource);
            WindowsFormsUtility.SetControlBinding(lblArchivedTime, bindSource);
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, bindSource);
        }


        private void ChangeStatus(StatusEnum newRecipeStatus)
        {
            DialogResult res = MessageBox.Show($"Are you sure you want to change this recipe to {newRecipeStatus}?",
                Application.ProductName, MessageBoxButtons.YesNo);
            if(res == DialogResult.No)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRecipe.Rows[0]["RecipeStatus"] = newRecipeStatus;
                Recipe.Save(dtRecipe);
                recipeStatus = newRecipeStatus;
                LoadForm(recipeId);
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

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Button b)
            {
                ChangeStatus((StatusEnum)b.Tag);
            }
        }

    }
}
