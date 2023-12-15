using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class Cookbook
    {
        public static DataTable Get(int cookBookId, bool all = false)
        {
            int allBit = all ? 1 : 0;
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookBookGet");
            SQLUtility.SetParamValue(cmd, "@CookBookId", cookBookId);
            SQLUtility.SetParamValue(cmd, "@All", allBit);
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable GetAll()
        {
            return Get(0, true);
        }

        public static string GetDesc(int cookbookId, DataTable dtCookBook)
        {
            return cookbookId > 0 ? $"Cookbook: {SQLUtility.GetValueFromFirstRowAsString(dtCookBook, "CookBookName")}" : "New Cookbook";
        }

        public static void Delete(int cookbookId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookDelete");
            SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookId);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void Save(DataTable dtCookbook)
        {
            if (dtCookbook.Rows.Count != 1)
            {
                throw new Exception("Cannot save Recipe, 'DataTable of Recipes Rows Count != 1'");
            }
            SQLUtility.SaveDateRow(dtCookbook.Rows[0], "CookBookUpdate");
        }

        public static DataTable CreateForUser(int staffId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookCreateOfStaffRecipes");  
            SQLUtility.SetParamValue(cmd, "@StaffId", staffId);
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable GetCookbookRecipes(int cookBookId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookBookRecipeGet");
            SQLUtility.SetParamValue(cmd, "@CookBookId", cookBookId);
            return SQLUtility.GetDataTable(cmd);
        }

        public static void UpdateCookbookRecipes(DataTable dtCookbookRecipes, int cookbookId)
        {
            if (dtCookbookRecipes.Rows.Count == 0)
            {
                throw new Exception("Cannot save Cookbook Recipes, 'dtCookbookRecipes.Rows.Count == 0'");
            }

            foreach(DataRow r  in dtCookbookRecipes.Rows)
            {
                r["CookbookId"] = cookbookId;
            }

            SQLUtility.SaveDataTable(dtCookbookRecipes, "CookBookRecipeUpdate");
        }

        public static void DeleteCookbookRecipes(int cookBookRecipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookBookRecipeDelete");
            SQLUtility.SetParamValue(cmd, "@CookBookRecipeId", cookBookRecipeId);
            SQLUtility.ExecuteSQL(cmd);
        }



    }
}
