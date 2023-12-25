using System.Data;
using System.Configuration;

namespace RecipeTesting
{
    public class Utils
    {
        public static string connString = ConfigurationManager.ConnectionStrings["devconn"].ConnectionString;
        public static string testConnString = ConfigurationManager.ConnectionStrings["unittestconn"].ConnectionString;

        public static void RefreshTestData()
        {
            DBManager.SetConnectionString(testConnString, true);
            SQLUtility.ExecuteSQL(SQLUtility.GetSQLCommand("DataUpdate"));
            DBManager.SetConnectionString(connString, true);
        }

        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new();
            DBManager.SetConnectionString(testConnString, true);
            dt = SQLUtility.GetDataTable(sql);
            DBManager.SetConnectionString(connString, true);
            return dt;
        }

        public static void ExecuteSQL(string sql)
        {
            GetDataTable(sql);
        }

        public static int GetFirstRowColumnIfInt(string sql)
        {
            return GetFirstRowColumnIfInt(GetDataTable(sql));
        }

        public static int GetFirstRowColumnIfInt(DataTable dt)
        {
            int n = 0;
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0 && dt.Rows[0][0] is int)
            {
                n = (int)dt.Rows[0][0];
            }
            return n;
        }

     

        public static string GetFirstRowColumnIfString(string sql)
        {
            string s = "";

            DataTable dt = GetDataTable(sql);
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
