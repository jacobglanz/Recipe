using System.Data;
using System.Data.SqlClient;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable Search(string searchInput)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            cmd.Parameters["@RecipeName"].Value = searchInput;
            if (string.IsNullOrEmpty(searchInput))
            {
                cmd.Parameters["@All"].Value = 1;
            }
            return SQLUtility.GetDateTable(cmd);
        }

        public static DataTable Load(int recipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            cmd.Parameters["@RecipeId"].Value = recipeId;
            return SQLUtility.GetDateTable(cmd);
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

        public static void DeleteStaff(DataTable dtStaff)
        {
            int staffId = (int)dtStaff.Rows[0]["StaffId"];
            SQLUtility.ExecuteSQL("delete Staff where StaffId = " + staffId);
        }

        public static DataTable GetStaffList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("StaffGet");
            cmd.Parameters["@All"].Value = 1;
            return SQLUtility.GetDateTable(cmd);
        }

        public static DataTable GetCuisineTypeList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineTypeGet");
            cmd.Parameters["@All"].Value = 1;
            return SQLUtility.GetDateTable(cmd);
        }
    }

}
