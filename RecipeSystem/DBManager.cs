namespace RecipeSystem
{
    public class DBManager
    {
        public static void SetConnectionString(string connString, bool tryOopen, string userId = "", string password = "")
        {
            SQLUtility.SetConnectionString(connString, tryOopen, userId, password);
        }
    }
}
