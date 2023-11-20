﻿
namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            btnNew.Click += BtnNew_Click;
            gRecipes.CellDoubleClick += GRecipes_CellDoubleClick;
            WindowsFormsUtility.FormatGridForSearchResults(gRecipes);
        }

        private void ShowRecipeDetailPage(int rowIndex)
        {
            int recipeId = rowIndex > -1 ? (int)gRecipes.Rows[rowIndex].Cells["RecipeId"].Value : 0;
            frmRecipe frm = new();
            frm.ShowForm(recipeId);
        }
        private void SearchRecipe(string searchInput)
        {
            gRecipes.DataSource = Recipe.Search(searchInput);
            gRecipes.Columns["RecipeId"].Visible = false;
        }
        private void GRecipes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeDetailPage(e.RowIndex);
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeDetailPage(-1);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchRecipe(txtSearchBox.Text);
        }

    }
}