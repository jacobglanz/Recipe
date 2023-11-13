using CPUFramework;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowForm(int recipeId)
        {
            this.Show();
            SetRecipeDetails(recipeId);
            SetRecipeIngredients(recipeId);
            SetRecipeInstructions(recipeId);
        }
        private void SetRecipeDetails(int recipeId)
        {
            string sql = "select r.RecipeId, r.RecipeName, ct.CuisineTypeName, r.Calories, r.RecipeStatus, r.DraftTime, r.PublishedTime, r.ArchivedTime, s.FirstName, s.LastName, s.UserName from recipe r join CuisineType ct on r.CuisineTypeId = ct.CuisineTypeId join Staff s on r.StaffId = s.StaffId where r.RecipeId = " + recipeId;
            DataTable dt = SQLUtility.GetDateTable(sql);

            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtCuisineTypeName.DataBindings.Add("Text", dt, "CuisineTypeName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            txtDraftTime.DataBindings.Add("Text", dt, "DraftTime");
            txtPublishedTime.DataBindings.Add("Text", dt, "PublishedTime");
            txtArchivedTime.DataBindings.Add("Text", dt, "ArchivedTime");
            txtFirstName.DataBindings.Add("Text", dt, "FirstName");
            txtLastName.DataBindings.Add("Text", dt, "LastName");
            txtUsername.DataBindings.Add("Text", dt, "Username");
        }
        private void SetRecipeIngredients(int recipeId)
        {
            string sql = "select ri.Seq, i.IngredientName, ri.Amount, uom.UnitName from RecipeIngredient ri join Ingredient i on ri.IngredientId = i.IngredientId left join UnitOfMeasure uom on ri.UnitOfMeasureId = uom.UnitOfMeasureId where ri.RecipeId = " + recipeId + " order by ri.Seq";
            DataTable dt = SQLUtility.GetDateTable(sql);
            gIngredients.DataSource = dt;
        }
        private void SetRecipeInstructions(int recipeId)
        {
            string sql = "select Seq, InstructionDesc from RecipeInstruction where RecipeId = " + recipeId + " order by Seq";
            DataTable dt = SQLUtility.GetDateTable(sql);
            gInstructions.DataSource = dt;
        }

    }
}
