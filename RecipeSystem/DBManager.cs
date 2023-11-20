
namespace RecipeSystem
{
    public class DBManager
    {
        public static void SetConnectionString(string connectionString)
        {
            SQLUtility.ConnectionString = connectionString;
        }
    }
}
