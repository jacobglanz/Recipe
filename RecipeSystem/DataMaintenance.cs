using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class DataMaintenance
    {
        public enum DataType { Staff, CuisineType, Ingredient, UnitOfMeasure, Course }
        public static DataTable DashboardGet()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("DashboardGet");
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable GetAll(DataType tableName, bool includeBlank = false)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(tableName + "Get");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            if (includeBlank)
            {
                SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            }
            return SQLUtility.GetDataTable(cmd);
        }

        public static void SaveAll(DataType tableName, DataTable dt)
        {
            if(dt.Rows.Count < 1)
            {
                throw new Exception("Cannot save data, no rows found");
            }
            SQLUtility.SaveDataTable(dt, tableName + "Update");
        }

        public static void DeleteRecord(DataType tableName, int recordId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(tableName + "Delete");
            SQLUtility.SetParamValue(cmd, $"@{tableName}Id", recordId);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void RefreshSampleData()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("DataUpdate");
            SQLUtility.ExecuteSQL(cmd);
        }

        public static int GetValueFromFirstRowAsInt(DataTable dt, string columnName)
        {
            return SQLUtility.GetValueFromFirstRowAsInt(dt, columnName);
        }
    }
}
