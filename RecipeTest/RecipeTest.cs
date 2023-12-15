using System.Data;

namespace RecipeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=.\\SQLExpress;Database=HeartyHearthDB;Trusted_Connection=true;TrustServerCertificate=true");
        }

        [Test]
        public static void GetListOfRecipies()
        {
            int dbRecipeCount = GetFirstColumnFirstRowValueAsString("select count(*) from Recipe");
            Assume.That(dbRecipeCount > 0, "No records returned from DB, can't run test");
            TestContext.WriteLine($"DB has {dbRecipeCount} records");
            TestContext.WriteLine($"App should return {dbRecipeCount} records");

            int appRecipeCount = Recipe.Get("").Rows.Count;

            Assert.IsTrue(appRecipeCount == dbRecipeCount, $"App Retuned {appRecipeCount} records");
            TestContext.WriteLine($"App Retuned {appRecipeCount} records");
        }

        [Test]
        public static void LoadRecipe()
        {
            int recipeId = GetFirstColumnFirstRowValueAsString("select top 1 RecipeId from Recipe");
            Assume.That(recipeId > 0, "No records returned from DB, can't run test");
            TestContext.WriteLine($"App should return RecipeId {recipeId}");

            DataTable dtAppRecipe = Recipe.Get(recipeId);
            int appRecipeId = (int)dtAppRecipe.Rows[0]["RecipeId"];

            Assert.IsTrue(appRecipeId == recipeId, $"App returned RecipeId {appRecipeId}");
            TestContext.WriteLine($"App returned RecipeId {appRecipeId}");
        }

        [Test]
        [TestCase("Update", "01-01-2020", null, null)]
        [TestCase("Update", "01-01-2022", null, "05-01-2022")]
        [TestCase("Update", "06-07-2023", "09-24-2023", null)]
        public static void UpdateRecipe(string RecipeName, DateTime DraftTime, DateTime? PublishedTime, DateTime? ArchivedTime)
        {
            DataTable dtDbRecipe = SQLUtility.GetDataTable("select top 1 * from Recipe");
            Assume.That(dtDbRecipe.Rows.Count > 0, "No records retunred from DB, can't run test");
            DataRow r = dtDbRecipe.Rows[0];
            int oldStaffId = (int)r["StaffId"];
            int oldCuisineTypeId = (int)r["CuisineTypeId"];
            TestContext.WriteLine($"DB Recipe ({r["RecipeId"]}): RecipeName = {r["RecipeName"]}, Calories = {r["Calories"]}");
            string newRecipeName = $"{RecipeName} {DateTime.Now}";
            int newCalories = new Random().Next(50, 500);
            int newStaffId = GetFirstColumnFirstRowValueAsString($"select top 1 StaffId from Staff where StaffId <> {oldStaffId}");
            newStaffId = newStaffId != 0 ? newStaffId : oldStaffId;
            int newCuisineTypeId = GetFirstColumnFirstRowValueAsString($"select top 1 CuisineTypeId from CuisineType where CuisineTypeId <> {oldCuisineTypeId}");
            newCuisineTypeId = newCuisineTypeId != 0 ? newCuisineTypeId : oldCuisineTypeId;
            TestContext.WriteLine($"App should update Recipe to: RecipeName = {newRecipeName}, Calories = {newCalories}");

            r["RecipeName"] = newRecipeName;
            r["Calories"] = newCalories;
            r["StaffId"] = newStaffId;
            r["CuisineTypeId"] = newCuisineTypeId;
            r["DraftTime"] = DraftTime;
            r["PublishedTime"] = PublishedTime.HasValue ? PublishedTime : DBNull.Value;
            r["ArchivedTime"] = ArchivedTime.HasValue ? ArchivedTime : DBNull.Value;

            Recipe.Save(dtDbRecipe);

            DataRow rUpdated = SQLUtility.GetDataTable($"select * from Recipe where RecipeId = {r["RecipeId"]}").Rows[0];
            Assert.IsTrue((string)rUpdated["RecipeName"] == newRecipeName, $"Updated RecipeName = {rUpdated["RecipeName"]}");
            Assert.IsTrue((int)rUpdated["Calories"] == newCalories, $"Update Calories = {rUpdated["Calories"]}");
            Assert.IsTrue((int)rUpdated["StaffId"] == newStaffId, $"Update StaffId = {rUpdated["StaffId"]}");
            Assert.IsTrue((int)rUpdated["CuisineTypeId"] == newCuisineTypeId, $"Update CuisineTypeId = {rUpdated["CuisineTypeId"]}");
            Assert.IsTrue((DateTime)rUpdated["DraftTime"] == DraftTime, $"Update DraftTime = {rUpdated["DraftTime"]}");
            Assert.IsTrue(rUpdated["PublishedTime"].ToString() == PublishedTime.ToString(), $"Update PublishedTime = {rUpdated["PublishedTime"]}");
            Assert.IsTrue(rUpdated["ArchivedTime"].ToString() == ArchivedTime.ToString(), $"Update ArchivedTime = {rUpdated["ArchivedTime"]}");
            TestContext.WriteLine($"DB Updated Recipe ({rUpdated["RecipeId"]}), RecipeName = {rUpdated["RecipeName"]}, Calories = {rUpdated["Calories"]}, StaffId = {rUpdated["StaffId"]}, CuisineTypeId = {rUpdated["CuisineTypeId"]}, DraftTime = {rUpdated["DraftTime"]}, PublishedTime = {rUpdated["PublishedTime"]}, ArchivedTime = {rUpdated["ArchivedTime"]}");
        }

        [Test]
        public static void UpdateRecipeToInvalidCalories()
        {
            DataTable dtRecipe = SQLUtility.GetDataTable("select top 1 * from Recipe");
            Assume.That(dtRecipe.Rows.Count > 0, "No records returned from DB, can't run test");
            DataRow r = dtRecipe.Rows[0];
            int recipeId = (int)r["RecipeId"];
            int calories = (int)r["Calories"];
            int newCalories = -50;
            TestContext.WriteLine($"Recipe ({recipeId}) Calories = {calories}");
            TestContext.WriteLine($"Changing Reciep Calories to {newCalories}");

            r["Calories"] = newCalories;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dtRecipe));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public static void UpdateRecipeToInvalidRecipeName()
        {
            DataTable dtRecipe = SQLUtility.GetDataTable("select top 1 * from Recipe");
            Assume.That(dtRecipe.Rows.Count > 0, "No records returned from DB, can't run test");
            DataRow r = dtRecipe.Rows[0];
            int recipeId = (int)r["RecipeId"];
            string recipeName = (string)r["RecipeName"];
            TestContext.WriteLine($"Recipe ({recipeId}) RecipeName = {recipeName}");
            TestContext.WriteLine($"Inserting another recipe with the same name");

            r["RecipeId"] = 0;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dtRecipe));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        [TestCase("Pizza Slice", 100, "01-01-2020", "02-01-2020", "09-26-2022")] // ALl Fields
        [TestCase("Pizza Family", 800, "08-01-2022", "08-09-2022", null)] // Missing ArchivedDate
        [TestCase("Egg Saled", 205, "08-04-2019", null, "08-25-2019")] // Missing PublishedDate
        public static void InsertRecipe(string RecipeName, int Calories, DateTime DraftTime, DateTime? PublishedTime, DateTime? ArchivedTime)
        {
            RecipeName = $"{RecipeName} - {DateTime.Now}";
            int staffId = GetFirstColumnFirstRowValueAsString("select top 1 StaffId from Staff");
            Assume.That(staffId > 0, "No Staff returned from DB, can't run test");
            int cuisineTypeId = GetFirstColumnFirstRowValueAsString("select top 1 CuisineTypeId from CuisineType");
            Assume.That(cuisineTypeId > 0, "No CuisineTypes returned from DB, can't run test");
            TestContext.WriteLine($"Recipe data should be: StaffId = {staffId}, CuisineTypeId = {cuisineTypeId}, RecipeName = {RecipeName}, Calories = {Calories}, DraftTime = {DraftTime}, PublishedTime = {PublishedTime}, ArchivedTime = {ArchivedTime}");

            DataTable dt = SQLUtility.GetDataTable("select * from Recipe where RecipeId = 0");
            dt.Rows.Add();
            DataRow r = dt.Rows[0];
            r["StaffId"] = staffId;
            r["CuisineTypeId"] = cuisineTypeId;
            r["RecipeName"] = RecipeName;
            r["Calories"] = Calories;
            r["DraftTime"] = DraftTime;
            if (PublishedTime.HasValue) r["PublishedTime"] = PublishedTime;
            if (ArchivedTime.HasValue) r["ArchivedTime"] = ArchivedTime;
            Recipe.Save(dt);

            DataTable dtNew = SQLUtility.GetDataTable($"select * from Recipe where RecipeName = '{RecipeName}'");
            Assert.IsTrue(dtNew.Rows.Count > 0, $"Recipe with RecipeName = {RecipeName} not retunred from DB");
            DataRow rNew = dtNew.Rows[0];
            Assert.IsTrue((int)rNew["StaffId"] == staffId, $"StaffId Returned from db is {rNew["StaffId"]}");
            Assert.IsTrue((int)rNew["CuisineTypeId"] == cuisineTypeId, $"CuisineTypeId Returned from db is {rNew["CuisineTypeId"]}");
            Assert.IsTrue((string)rNew["RecipeName"] == RecipeName, $"RecipeName Returned from db is {rNew["RecipeName"]}");
            Assert.IsTrue((int)rNew["Calories"] == Calories, $"Calories Returned from db is {rNew["Calories"]}");
            Assert.IsTrue((DateTime)rNew["DraftTime"] == DraftTime, $"DraftTime Returned from db is {rNew["DraftTime"]}");
            Assert.IsTrue(rNew["PublishedTime"].ToString() == PublishedTime.ToString(), $"PublishedTime Returned from db is {rNew["PublishedTime"]}");
            Assert.IsTrue(rNew["ArchivedTime"].ToString() == ArchivedTime.ToString(), $"ArchivedTime Returned from db is {rNew["ArchivedTime"]}");
            TestContext.WriteLine($"Recipe data returned from DB: StaffId = {rNew["StaffId"]}, CuisineTypeId = {rNew["CuisineTypeId"]}, RecipeName = {rNew["RecipeName"]}, Calories = {rNew["Calories"]}, DraftTime = {rNew["DraftTime"]}, PublishedTime = {rNew["PublishedTime"]}, ArchivedTime = {rNew["ArchivedTime"]}");
        }

        [Test]
        public static void DeleteRecipeWithoutRelatedRecordsAndBusinessRules()
        {
            string sql = @"
                select top 1 r.RecipeId
                from Recipe r
                left join CookBookRecipe cbr on cbr.RecipeId = r.RecipeId
                left join MealCourseRecipe mcr on r.RecipeId = mcr.RecipeId
                where cbr.CookBookRecipeId is null and mcr.MealCourseRecipeId is null
                and (r.RecipeStatus <> 'Published' or datediff(day, r.ArchivedTime, getdate()) > 30)";
            DataTable dt = SQLUtility.GetDataTable(sql);
            Assume.That(dt.Rows.Count > 0, "No records returned from DB, can't do test");
            int recipeId = (int)dt.Rows[0]["RecipeId"];
            TestContext.WriteLine($"Recipe ({recipeId}) exists in DB");

            TestContext.WriteLine($"Deleting Recipe ({recipeId}), should not exists in DB anymore");
            Recipe.Delete(dt);

            DataTable dtNew = SQLUtility.GetDataTable($"select * from Recipe where RecipeId = {recipeId}");
            Assert.IsTrue(dtNew.Rows.Count == 0, $"Recipe ({recipeId}) still exists in DB");
            TestContext.WriteLine($"Recipe ({recipeId}) does not exists in DB");
        }

        [Test]
        public static void DeletePublishedRecipe()
        {
            string sql = "select top 1 r.RecipeId from Recipe r where r.RecipeStatus = 'Published'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            Assume.That(dt.Rows.Count > 0, "No records returned from DB, can't do test");
            int recipeId = (int)dt.Rows[0]["RecipeId"];
            TestContext.WriteLine($"Recipe ({recipeId}) exists in DB");
            TestContext.WriteLine($"Deleting Recipe {recipeId}");

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public static void DeleteRecipeThatIsArchivedLessOrEqualTo30Days()
        {
            string sql = "select top 1 r.RecipeId from Recipe r where datediff(day, r.ArchivedTime, getdate()) <= 30";
            DataTable dt = SQLUtility.GetDataTable(sql);
            Assume.That(dt.Rows.Count > 0, "No records returned from DB, can't do test");
            int recipeId = (int)dt.Rows[0]["RecipeId"];
            TestContext.WriteLine($"Recipe ({recipeId}) exists in DB");
            TestContext.WriteLine($"Deleting Recipe {recipeId}");

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }
        [Test]
        public static void DeleteStaffWithRecipe()
        {
            DataTable dtStaff = SQLUtility.GetDataTable("select top 1 * from Staff s join Recipe r on s.StaffId = r.StaffId");
            Assume.That(dtStaff.Rows.Count > 0, "No records returned from DB, can't do test");
            int staffId = (int)dtStaff.Rows[0]["StaffId"];
            TestContext.WriteLine($"Staff ({staffId}) exists in DB");
            TestContext.WriteLine($"Deleting Staff {staffId}");

            Exception ex = Assert.Throws<Exception>(() => Recipe.DeleteStaff(dtStaff));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void GetListOfStaff()
        {
            int dbStaffCount = GetFirstColumnFirstRowValueAsString("select count(*) from Staff");
            Assume.That(dbStaffCount > 0, "0 records returned from DB, can't run test");
            TestContext.WriteLine($"DB returned {dbStaffCount} records");
            TestContext.WriteLine($"App should return {dbStaffCount} records");

            int appStaffCount = Recipe.GetStaffList().Rows.Count;

            Assert.IsTrue(dbStaffCount == appStaffCount, $"App returned {appStaffCount} records");
            TestContext.WriteLine("$App returned {appStaffCount} records");
        }

        [Test]
        public void GetListOfCuisineTypes()
        {
            int dbCuisineTypeListCount = GetFirstColumnFirstRowValueAsString("select count(*) from CuisineType");
            Assume.That(dbCuisineTypeListCount > 0, "No records returned from DB, can't run test");
            TestContext.WriteLine($"App should return {dbCuisineTypeListCount} records");

            int appCuisineTypeListCount = Recipe.GetCuisineTypeList().Rows.Count;

            Assert.IsTrue(dbCuisineTypeListCount == appCuisineTypeListCount, $"App returned {appCuisineTypeListCount} records");
            TestContext.WriteLine($"App returned {appCuisineTypeListCount} records");
        }

        private static int GetRandomRecipeId()
        {
            return GetFirstColumnFirstRowValueAsString("select top 1 RecipeId from Recipe");
        }

        private static int GetFirstColumnFirstRowValueAsString(string sql)
        {
            int n = 0;
            DataTable dt = SQLUtility.GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != null)
                {
                    int.TryParse(dt.Rows[0][0].ToString(), out n);
                }

            }
            return n;
        }
    }
}