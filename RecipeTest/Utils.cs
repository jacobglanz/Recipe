using System.Data;

namespace RecipeTesting
{
    public static class Utils
    {


        public static int GetFirstRowColumnIfInt(DataTable dt)
        {
            int n = 0;
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0 && dt.Rows[0][0] is int)
            {
                n = (int)dt.Rows[0][0];
            }
            return n;
        }

        public static int GetFirstRowColumnIfInt(string sql)
        {
            return GetFirstRowColumnIfInt(SQLUtility.GetDataTable(sql));
        }

        public static string GetFirstRowColumnIfString(string sql)
        {
            string s = "";

            DataTable dt = SQLUtility.GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                s = (string)dt.Rows[0][0];
            }

            return s;
        }

        public static string GetFirstRowColumnIfString(DataTable dt, string columnName)
        {
            string s = "";

            if (dt.Rows.Count > 0 && dt.Columns.Count > 0 && dt.Columns.Contains(columnName))
            {
                s = (string)dt.Rows[0][columnName];
            }

            return s;
        }
    }
}
