using System.Data;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable Search(string searchInput)
        {
            string sql = $"SELECT RecipeId, RecipeName FROM Recipe WHERE RecipeName LIKE '%{searchInput}%'";
            DataTable dt = SQLUtility.GetDateTable(sql);
            return dt;
        }

        public static DataTable Load(int recipeId)
        {
            string sql = "select r.RecipeId, r.StaffId, r.CuisineTypeId, r.RecipeName, r.Calories, r.DraftTime, r.PublishedTime, r.ArchivedTime, r.RecipeStatus from Recipe r where r.RecipeId = " + recipeId;
            return SQLUtility.GetDateTable(sql);
        }

        public static void Save(DataTable dtRecipe)
        {
            string sql = "";
            DataRow r = dtRecipe.Rows[0];

            string publishedDate = r["PublishedTime"].ToString() == "" ? "null" : $"'{r["PublishedTime"]}'";
            string archivedTime = r["ArchivedTime"].ToString() == "" ? "null" : $"'{r["ArchivedTime"]}'";

            if ((int)r["RecipeId"] == 0)
            {
                sql = "insert Recipe (StaffId, CuisineTypeId, RecipeName, Calories, DraftTime, PublishedTime, ArchivedTime) ";
                sql += $"select {r["StaffId"]}, {r["CuisineTypeId"]}, '{r["RecipeName"]}', {r["Calories"]}, '{r["DraftTime"]}', {publishedDate}, {archivedTime}";

            }
            else
            {
                sql = string.Join(Environment.NewLine, "update Recipe",
                    $"set StaffId = {r["StaffId"]},",
                    $"CuisineTypeId = {r["CuisineTypeId"]},",
                    $"RecipeName = '{r["RecipeName"]}',",
                    $"Calories = {r["Calories"]},",
                    $"DraftTime = '{r["DraftTime"]}',",
                    $"PublishedTime = {publishedDate},",
                    $"ArchivedTime = {archivedTime}",
                    $"where Recipeid = {r["RecipeId"]}");
            }
            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtRecipe)
        {
            int recipeId = (int)dtRecipe.Rows[0]["RecipeId"];
            SQLUtility.ExecuteSQL("delete recipe where RecipeId = " + recipeId);
        }

        public static DataTable GetStaffList()
        {
            return SQLUtility.GetDateTable("select * from Staff");
        }

        public static DataTable GetCuisineTypeList()
        {
            return SQLUtility.GetDateTable("select * from CuisineType");
        }
    }

}
