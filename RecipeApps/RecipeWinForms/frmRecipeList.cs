namespace RecipeWinForms
{
    public partial class frmRecipeList : Form
    {
        public frmRecipeList()
        {
            InitializeComponent();
            gRecipes.CellDoubleClick += GRecipes_CellDoubleClick;
            gRecipes.KeyDown += GRecipes_KeyDown;
            btnNewRecipe.Click += BtnNewRecipe_Click;
            this.Activated += FrmRecipeList_Activated;
        }

        private void GetRecipeList()
        {
            gRecipes.DataSource = Recipe.GetAll();
            WindowsFormsUtility.FormatGridForSearchResults(gRecipes);
        }

        private void OpenRecipeForm(int rowIndex)
        {
            int recipeId = rowIndex > -1 ? WindowsFormsUtility.GetPkIdFromGrid(gRecipes, "RecipeId", rowIndex) : 0;
            if (MdiParent is frmMain)
            {
                ((frmMain)MdiParent).OpenForm(typeof(frmRecipe), recipeId);
            }
        }


        private void GRecipes_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gRecipes.CurrentCell != null)
            {
                OpenRecipeForm(gRecipes.CurrentCell.RowIndex);
            }
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                btnNewRecipe.Focus();
            }
        }

        private void GRecipes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                OpenRecipeForm(e.RowIndex);
            }
        }
        private void BtnNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenRecipeForm(-1);
        }
        private void FrmRecipeList_Activated(object? sender, EventArgs e)
        {
            GetRecipeList();
        }


    }
}
