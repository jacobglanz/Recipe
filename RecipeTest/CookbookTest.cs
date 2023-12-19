using NuGet.Frameworks;
using System.Data;
using System.Data.SqlClient;

namespace RecipeTesting
{
    public class CookbookTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=.\\SQLExpress;Database=HeartyHearthDB;Trusted_Connection=true;TrustServerCertificate=true");
            SQLUtility.ExecuteSQL(SQLUtility.GetSQLCommand("DataUpdate"));
        }

        [Test]
        public static void GetCookbook()
        {
            int cbId = Utils.GetFirstRowColumnIfInt("select top 1 cookbookId from Cookbook");
            Assume.That(cbId > 0, "No cookbook found, can't run test");
            string cbName = Utils.GetFirstRowColumnIfString($"select CookBookName from Cookbook where cookbookId = {cbId}");
            Assume.That(!string.IsNullOrEmpty(cbName), "Cookbook name is null or empty, can't run test");
            TestContext.WriteLine($"Cookbbok ({cbId}) Name should be = {cbName}");

            DataTable dt = Cookbook.Get(cbId);
            string cookbookName = Utils.GetFirstRowColumnIfString(dt, "cookbookName");

            Assert.IsTrue(cookbookName == cbName, $"Cookbbok ({cbId}) Name should be {cbName} but is {cookbookName}");
            TestContext.WriteLine($"Cookbbok ({cbId}) Name is = {cookbookName}");
        }

        [Test]
        public static void GetAllCookbooks()
        {
            int DBCookbookCount = Utils.GetFirstRowColumnIfInt("select count(*) from Cookbook");
            Assume.That(DBCookbookCount > 0, "DB returned 0 records, can't run test");
            TestContext.WriteLine($"DB Cookbook count is = {DBCookbookCount}");
            TestContext.WriteLine($"App Cookbook count should be = {DBCookbookCount}");

            int appCookbookCount = Cookbook.GetAll().Rows.Count;

            Assert.IsTrue(DBCookbookCount == appCookbookCount, $"App Cookbook count is {appCookbookCount}");
            TestContext.WriteLine($"App Cookbook count is {appCookbookCount}");
        }

        [Test]
        public static void DeleteCookbookAndItsRecipes()
        {
            int DBCookbookId = Utils.GetFirstRowColumnIfInt("select top 1cb.CookbookId from Cookbook cb join CookbookRecipe cbr on cb.CookbookId = cbr.CookbookId");
            Assume.That(DBCookbookId > 0, "No cookbook found, can't run test");
            TestContext.WriteLine($"Cookbbok ({DBCookbookId}) exists in DB and has Recipes");
            TestContext.WriteLine($"Cookbbok ({DBCookbookId}) should not exists in DB");

            Cookbook.Delete(DBCookbookId);

            DBCookbookId = Utils.GetFirstRowColumnIfInt($"select CookbookId from Cookbook where CookbookId = {DBCookbookId}");
            Assert.IsTrue(DBCookbookId == 0, $"Cookbbok ({DBCookbookId}) should not exists in DB");
            TestContext.WriteLine($"Cookbbok ({DBCookbookId}) does not exists in DB");
        } 

        [Test]
        [TestCase("Cookbook test 1", 24.99, true, "2023-04-05")]
        [TestCase("Cookbook test 2", 35.02, true, "2018-04-17")]
        [TestCase("Cookbook test 3", 123.65, true, "2020-09-25")]
        public static void SaveCookbook(string cookbookName, decimal price, bool active, DateTime createdDate)
        {
            DataTable dt = Cookbook.Get(0);
            dt.Rows.Add();
            DataRow r = dt.Rows[0];
            int StaffId = Utils.GetFirstRowColumnIfInt("select top 1 StaffId from Staff");
            Assume.That(StaffId > 0, "No staff found in DB and it's needed in order to create a Cookbook");
            r["StaffId"] = StaffId;
            r["CookBookName"] = cookbookName + DateTime.Now;
            r["Price"] = price;
            r["Active"] = active ? 1 :2;
            r["CreatedDate"] = createdDate;
            TestContext.WriteLine("Creating new cookbook...");

            Cookbook.Save(dt);

            int newCookbookId = (int)dt.Rows[0][0];
            Assert.IsTrue(newCookbookId > 0, $"Cookbook not created");
            TestContext.WriteLine($"New cookbook ({newCookbookId}) successfully created");
        }

        [Test]
        public static void CreateCookbookForAllRecipesFromAUser()
        {
            int staffId = Utils.GetFirstRowColumnIfInt("select top 1 StaffId from Recipe");
            SQLUtility.ExecuteSQL($"delete CookBookRecipe where CookbookId in (select CookbookId from CookBook where StaffId = {staffId})");
            SQLUtility.ExecuteSQL($"delete CookBook where StaffId = {staffId}");
            TestContext.WriteLine($"Deleting all cookbook's (and their recipe's) created by Staff({staffId})");
            int staffCookbookCount = Utils.GetFirstRowColumnIfInt($"select count(*) from Cookbook where StaffId = {staffId}");
            Assume.That(staffCookbookCount == 0, $"Cookbook(s) not deleted, count = {staffCookbookCount}");
            int staffRecipeCount = Utils.GetFirstRowColumnIfInt($"select count(*) from Recipe where StaffId = {staffId}");
            Assume.That(staffRecipeCount > 0, $"Staff didn't create any recipes");

            DataTable dtNewCookbook = Cookbook.CreateForUser(staffId);
            int newCookbookId = Utils.GetFirstRowColumnIfInt(dtNewCookbook);
            int staffCookbookRecipeCount = Utils.GetFirstRowColumnIfInt($"select count(*) from CookBookRecipe where CookbookId = {newCookbookId}");

            Assert.IsTrue(staffRecipeCount == staffCookbookRecipeCount, $"Cookbook ({newCookbookId}) should have {staffRecipeCount} recipes, but has {staffCookbookRecipeCount}");
            TestContext.WriteLine($"Cookbook ({newCookbookId}) has {staffCookbookRecipeCount} recipe(s)");
        }

        [Test]
        public static void GetCookbookRecipes()
        {
            int cookbookId = Utils.GetFirstRowColumnIfInt("select top 1 cb.cookbookId from Cookbook cb join CookbookRecipe cbr on cb.CookbookId = cbr.CookbookId");
            Assume.That(cookbookId > 0, $"DB didn't found cookbook(s) with recipe(s)");
            int DBCoobookRecipeCount = Utils.GetFirstRowColumnIfInt($"select count(*) from CookbookRecipe where CookbookId = {cookbookId}");
            TestContext.WriteLine($"Cookbook ({cookbookId}) has {DBCoobookRecipeCount} recipes(s)");
            TestContext.WriteLine($"App should return {DBCoobookRecipeCount} recipes(s) for Cookbook ({cookbookId})");

            DataTable dtAppCookbookRecipes = Cookbook.GetCookbookRecipes(cookbookId);
            int appCoobookRecipeCount = 0;
            foreach (DataRow r in dtAppCookbookRecipes.Rows)
            {
                if ((int)r["CookbookId"] == cookbookId)
                {
                    appCoobookRecipeCount += 1;
                }
            }

            Assert.IsTrue(DBCoobookRecipeCount == appCoobookRecipeCount, $"DB returned {appCoobookRecipeCount} recipes(s) for Cookbook ({cookbookId})");
            TestContext.WriteLine($"DB returned {appCoobookRecipeCount} recipes(s) for Cookbook ({cookbookId})");
        }

        [Test]
        public static void InsertCookbookRecipes()
        {
            DataTable dtCookbookRecipes = SQLUtility.GetDataTable($"select CookBookId, CookBookRecipeId, RecipeId, Seq from CookBookRecipe where CookBookId = (select top 1 CookbookId from CookbookRecipe group by CookbookId order by count(*) desc)");
            int cookbookId = Utils.GetFirstRowColumnIfInt(dtCookbookRecipes);
            Assume.That(cookbookId > 0, "DB didn't return Cookbook, can't run test");
            int InitialCountCbRecipes = Utils.GetFirstRowColumnIfInt($"select count(*) from CookBookRecipe where CookBookId = {cookbookId}");
            TestContext.WriteLine($"Cookbook ({cookbookId}) chosen for test, currently has {InitialCountCbRecipes} recipe(s)");
            TestContext.WriteLine("Deleting all recipes to re-insert them");
            SQLUtility.ExecuteSQL($"delete CookbookRecipe where CookbookId = {cookbookId}");
            int tempCountCbRecipes = Utils.GetFirstRowColumnIfInt($"select count(*) from CookBookRecipe where CookBookId = {cookbookId}");
            Assume.That(tempCountCbRecipes == 0, "CookbookRecipes not deleted, cant run test");
            TestContext.WriteLine($"Cookbook ({cookbookId}) currently has {tempCountCbRecipes} recipe(s)");


            foreach (DataRow r in dtCookbookRecipes.Rows)
            {
                r["CookBookRecipeId"] = 0;
            }
            Cookbook.SaveCookbookRecipes(dtCookbookRecipes, cookbookId);
            int newCountCbRecipes = Utils.GetFirstRowColumnIfInt($"select count(*) from CookBookRecipe where CookBookId = {cookbookId}");

            Assert.IsTrue(newCountCbRecipes == InitialCountCbRecipes, $"Cookbook ({cookbookId}) should have {InitialCountCbRecipes} CookbookRecipes");
            TestContext.WriteLine($"Cookbook ({cookbookId}) has {newCountCbRecipes} CookbookRecipes");
        }

        [Test]
        public static void UpdateCookbookRecipes()
        {
            DataTable dtCookbookRecipes = SQLUtility.GetDataTable($"select CookBookId, CookBookRecipeId, RecipeId, Seq from CookBookRecipe where CookBookId = (select top 1 CookbookId from CookbookRecipe group by CookbookId order by count(*) desc) order by Seq desc");
            int cookbookId = Utils.GetFirstRowColumnIfInt(dtCookbookRecipes);
            Assume.That(cookbookId > 0, "DB didn't return Cookbook, can't run test");
            int countCbRecipes = dtCookbookRecipes.Rows.Count;
            Assume.That(countCbRecipes >= 2, $"Cookbook ({cookbookId}) only has {countCbRecipes} recipe(s) (highest amount per Cookbook), Test will not be sufficient"); 
            
            for(int n = 0; n < 2; n++)
            {
                dtCookbookRecipes.Rows[n]["Seq"] = (int)dtCookbookRecipes.Rows[n]["Seq"] + 1;
            }
            Cookbook.SaveCookbookRecipes(dtCookbookRecipes, cookbookId);

            DataTable newDtCookbookRecipes = SQLUtility.GetDataTable($"select top 2 Seq from CookBookRecipe where Cookbookid = {cookbookId} order by Seq desc");
            int SeqLast = (int)newDtCookbookRecipes.Rows[0]["Seq"];
            int SeqOneBeforeLast = (int)newDtCookbookRecipes.Rows[1]["Seq"];

            Assert.IsTrue(SeqLast == countCbRecipes + 1 && SeqOneBeforeLast == countCbRecipes, $"Record ");
            TestContext.WriteLine($"ssssss");
        }

        [Test]
        public static void DeleteCookbookRecipes()
        {
            int cookbookRecipeId = Utils.GetFirstRowColumnIfInt("select top 1 CookbookRecipeId from CookbookRecipe");
            Assume.That(cookbookRecipeId > 0, $"DB didn't found CookbookRecipes");
            TestContext.WriteLine($"CookbookRecipe ({cookbookRecipeId} exists in DB)");
            TestContext.WriteLine($"Deleting CookbookRecipe ({cookbookRecipeId}), DB should not return it again");

            Cookbook.DeleteCookbookRecipes(cookbookRecipeId);
            int appCookbookRecipeId = Utils.GetFirstRowColumnIfInt($"select CookbookRecipeId from CookbookRecipe where CookbookRecipeId = {cookbookRecipeId}");

            Assert.IsTrue(appCookbookRecipeId == 0, $"DB returned CookbookRecipe {cookbookRecipeId}");
            TestContext.WriteLine($"CookbookRecipe ({cookbookRecipeId} does not exists in DB)");
        }


    }
}
