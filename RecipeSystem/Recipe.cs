using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace RecipeSystem
{
    public class Recipe
    {

        public static DataTable Get(int recipeId, bool all = false, string searchInput = "")
        {
            int allBit = all ? 1 : 0;
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            SQLUtility.SetParamValue(cmd, "@RecipeName", searchInput);
            SQLUtility.SetParamValue(cmd, "@All", allBit);
            return SQLUtility.GetDataTable(cmd);
        }
        
        public static DataTable GetAll()
        {
            return Get(0, true);
        }

        public static void Save(DataTable dtRecipe)
        {
            if (dtRecipe.Rows.Count != 1)
            {
                throw new Exception("Cannot save Recipe, 'DataTable of Recipes Rows Count != 1'");
            }
            SQLUtility.SaveDateRow(dtRecipe.Rows[0], "RecipeUpdate");
        }

        public static void Delete(int recipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static DataTable Clone(int recipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeClone");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            return SQLUtility.GetDataTable(cmd);
        }

        public static string GetDesc(int recipeId, DataTable dtRecipe)
        {
            return recipeId > 0 ? $"Recipe - {SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "RecipeName")}" : "New Recipe";
        }

        public static DataTable GetRecipeIngredients(int recipeId, int ingredientId = 0)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeIngredientGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable GetRecipeInstructions(int recipeId, int instructionId = 0)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeInstructionGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            return SQLUtility.GetDataTable(cmd);
        }

        public static void SaveRecipeChild(DataTable dt, string tableName, int recipeId)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r["RecipeId"] = recipeId;
                }
            }
            SQLUtility.SaveDataTable(dt, tableName + "Update");
        }

        public static void DeleteRecipeChild(string tableName, int recordId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(tableName + "Delete");
            SQLUtility.SetParamValue(cmd, $"@{tableName}Id", recordId);
            SQLUtility.ExecuteSQL(cmd);
        }


    }
}


