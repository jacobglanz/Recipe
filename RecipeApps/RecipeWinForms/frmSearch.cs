using System.Data;
using CPUFramework;

namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            gRecipes.CellDoubleClick += GRecipes_CellDoubleClick;
        }

        private void ShowRecipeDetailPage(int rowIndex)
        {
            int recipeid = (int)gRecipes.Rows[rowIndex].Cells["RecipeId"].Value;
            frmRecipe frm = new();
            frm.ShowForm(recipeid);
        }
        private void SearchRecipe(string searchInput)
        {
            string sql = "SELECT RecipeId, RecipeName FROM Recipe WHERE RecipeName LIKE '%" + searchInput + "%'";
            DataTable dt = SQLUtility.GetDateTable(sql);
            gRecipes.DataSource = dt;
            gRecipes.Columns["RecipeId"].Visible = false;
        }
        private void GRecipes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                ShowRecipeDetailPage(e.RowIndex);
            }
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchRecipe(txtSearchBox.Text);
        }
    }
}
