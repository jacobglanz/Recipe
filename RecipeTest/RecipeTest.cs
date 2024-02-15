using NUnit.Framework.Internal;
using System.Data;

namespace RecipeTesting
{
    public class RecipeTest
    {

        [SetUp]
        public void Setup()
        {
            Utils.RefreshTestData();
        }

        [Test]
        public void GetIngredients()
        {
            int dbResultCount = Utils.GetFirstRowColumnIfInt("select count(*) from Ingredient");
            TestContext.WriteLine($"DB returned {dbResultCount} records, app should return the same");

            bizIngredient g = new();
            int appResultCount = g.GetList().Count;

            Assert.IsTrue(dbResultCount == appResultCount, $"App returned {appResultCount} records");
            TestContext.WriteLine($"App returned {appResultCount} records");
        }

        [Test]
        public void SearchIngredients()
        {
            string searchVal = "bak";
            string sql = $"select Count = count(*) from Ingredient where IngredientName like '%{searchVal}%'";
            int dbResultCount = Utils.GetFirstRowColumnIfInt(sql);
            TestContext.WriteLine($"DB returned {dbResultCount} results for the search value '{searchVal}'");
            TestContext.WriteLine($"App should also return {dbResultCount} results for this search");

            bizIngredient g = new();
            int appResultCount = g.Search(searchVal).Count;

            Assert.IsTrue(dbResultCount == appResultCount, $"App returned {appResultCount} results");
            TestContext.WriteLine($"App returned {appResultCount} results");
        }

        [Test]
        public void SearcRecipe()
        {
            string searchVal = "ie";
            string sql = $"select Count = count(*) from Recipe where RecipeName like '%{searchVal}%'";
            int dbResultCount = Utils.GetFirstRowColumnIfInt(sql);
            TestContext.WriteLine($"DB returned {dbResultCount} results for the search value '{searchVal}'");
            TestContext.WriteLine($"App should also return {dbResultCount} results for this search");

            bizRecipe recipe = new();
            int appResultCount = recipe.Search(searchVal).Count;

            Assert.IsTrue(dbResultCount == appResultCount, $"App returned {appResultCount} results");
            TestContext.WriteLine($"App returned {appResultCount} results");
        }

        [Test]
        public void GetRecipe()
        {
            int dbRecipeId = Utils.GetFirstRowColumnIfInt("select top 1 RecipeId from Recipe");
            Assume.That(dbRecipeId > 0, "DB didn't return any records, can't run test");
            TestContext.WriteLine($"DB returned recipe {dbRecipeId}");
            TestContext.WriteLine($"App should return Recipe {dbRecipeId}");

            bizRecipe recipe = new();
            recipe.Load(dbRecipeId);
            int appRecipeId = Utils.GetFirstRowColumnIfInt(recipe.Load(dbRecipeId));

            Assert.IsTrue(appRecipeId == dbRecipeId, $"App returned Recipe {appRecipeId}");
            TestContext.WriteLine($"App returned Recipe {appRecipeId}");
        }

        [Test]
        public static void GetAll()
        {
            int dbRecipeCount = Utils.GetFirstRowColumnIfInt("select count(*) from Recipe");
            Assume.That(dbRecipeCount > 0, "DB didn't return any records, can't run test");
            TestContext.WriteLine($"DB Recipe Count = {dbRecipeCount}");
            TestContext.WriteLine($"App Recipe Count shold also be = {dbRecipeCount}");

            bizRecipe recipe = new();
            int appRecipeCount = recipe.GetList().Count;

            Assert.IsTrue(dbRecipeCount == appRecipeCount, $"App Recipe Count should be = {dbRecipeCount} but is = {appRecipeCount}");
            TestContext.WriteLine($"App Recipe Count = {appRecipeCount}");
        }

        [Test]
        public void DeleteRecipeAndAllMenationsOfIt()
        {
            //Delete a Recipe it's ingredients and instructions, and also remove it from meals and cookbooks
            string sql = "select top 1 r.RecipeId from Recipe r " +
                "join RecipeIngredient rg on r.RecipeId = rg.RecipeId " +
                "join RecipeInstruction rs on r.RecipeId = rs.RecipeId " +
                "join CookBookRecipe cbr on r.RecipeId = cbr.RecipeId " +
                "join MealCourseRecipe mcr on r.RecipeId = mcr.RecipeId";
            DataTable dtRecipeDB = Utils.GetDataTable(sql);
            int recipeId = Utils.GetFirstRowColumnIfInt(dtRecipeDB);
            Assume.That(recipeId > 0, "DB didn't return a recipe that is related to RecipeIngredient, RecipeInstruction, CookBookRecipe and MealCourseRecipe");
            TestContext.WriteLine($"Recipe ({recipeId}) exists in DB");
            TestContext.WriteLine($" Deleting Recipe ({recipeId})... should not exists in DB anymore");

            bizRecipe recipe = new();
            recipe.Load(recipeId);
            recipe.Delete();

            recipeId = Utils.GetFirstRowColumnIfInt($"select RecipeId from Recipe where RecipeId = {recipeId}");

            Assert.IsTrue(recipeId == 0, $"Recipe ({recipeId}) exists in DB");
            TestContext.WriteLine($"Recipe ({recipeId}) does not exists in DB");
        }

        [Test]
        public static void DeletePublishedRecipe()
        {
            string sql = "select top 1 r.RecipeId from Recipe r where r.RecipeStatus = 'Published'";
            DataTable dt = Utils.GetDataTable(sql);
            Assume.That(dt.Rows.Count > 0, "No records returned from DB, can't do test");
            int recipeId = (int)dt.Rows[0]["RecipeId"];
            TestContext.WriteLine($"Recipe ({recipeId}) exists in DB");
            TestContext.WriteLine($"Deleting Recipe ({recipeId}) should not work because RecipeStatus = Published");

            bizRecipe recipe = new();
            Exception ex = Assert.Throws<Exception>(() => recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public static void DeleteRecipeThatIsArchivedLessOrEqualTo30Days()
        {
            string sql = "select top 1 r.RecipeId from Recipe r where datediff(day, r.ArchivedTime, getdate()) <= 30";
            DataTable dt = Utils.GetDataTable(sql);
            Assume.That(dt.Rows.Count > 0, "No records returned from DB, can't do test");
            int recipeId = (int)dt.Rows[0]["RecipeId"];
            TestContext.WriteLine($"Recipe ({recipeId}) exists in DB");
            TestContext.WriteLine($"Deleting Recipe ({recipeId}) should not work because ArchivedTime <= 30 Days from today");

            bizRecipe recipe = new();
            Exception ex = Assert.Throws<Exception>(() => recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        [TestCase("Recipe test 1", 25, "01/01/2015", null, null)]
        [TestCase("Recipe test 2", 45, "06/17/2019", "06/17/2022", null)]
        [TestCase("Recipe test 3", 150, "12/16/2012", null, "02/19/2019")]
        public static void SaveRecipe(string recipeName, int calories, DateTime draftTime, DateTime? publishedTime, DateTime? archivedTime)
        {

            int staffId = Utils.GetFirstRowColumnIfInt("select top 1 StaffId from Staff");
            Assume.That(staffId > 0, "No staff found in DB and it's needed in order to create a Recipe");
            int cuisineTypeId = Utils.GetFirstRowColumnIfInt("select top 1 CuisineTypeId from CuisineType");
            Assume.That(cuisineTypeId > 0, "No CuisineType found in DB and it's needed in order to create a Recipe");
            TestContext.WriteLine("Creating new Recipe...");

            bizRecipe recipe = new()
            {
                StaffId = staffId,
                CuisineTypeId = cuisineTypeId,
                RecipeName = recipeName + DateTime.Now,
                Calories = calories,
                DraftTime = draftTime,
                PublishedTime = publishedTime,
                ArchivedTime = archivedTime
            };
            recipe.Save();

            int newRecipeId = recipe.RecipeId;
            Assert.IsTrue(newRecipeId > 0, $"Recipe not created");
            TestContext.WriteLine($"New recipe ({newRecipeId}) successfully created");
        }

        [Test]
        public void Clone()
        {
            string sql = "select top 1 r.RecipeId from Recipe r " +
                "join RecipeIngredient rg on r.RecipeId = rg.RecipeId " +
                "join RecipeInstruction rs on r.RecipeId = rs.RecipeId";
            int recipeId = Utils.GetFirstRowColumnIfInt(sql);
            Assume.That(recipeId > 0, "DB didn't return a recipe that is related to RecipeIngredient and RecipeInstruction");
            int recipeIngredientsCount = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeIngredient where RecipeId = {recipeId}");
            int recipeInstructionsCount = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeInstruction where RecipeId = {recipeId}");
            TestContext.WriteLine($"Recipe ({recipeId}) has {recipeIngredientsCount} Ingredients and {recipeInstructionsCount} Instructions");
            TestContext.WriteLine($"Cloning Recipe...");

            Recipe.Clone(recipeId);
            string clonedRecipeName = Utils.GetFirstRowColumnIfString($"select RecipeName from Recipe where RecipeId = {recipeId}") + " - clone";
            int clonedRecipeId = Utils.GetFirstRowColumnIfInt($"select RecipeId from Recipe where RecipeName = '{clonedRecipeName}'");

            Assert.IsTrue(clonedRecipeId > 0, "Recipe not cloned");
            TestContext.WriteLine($"Cloned Recipe ({clonedRecipeId} - {clonedRecipeName}) has {recipeIngredientsCount} Ingredients and {recipeInstructionsCount} Instructions");
        }

        [Test]
        public void GetRecipeIngredients()
        {
            int recipeId = Utils.GetFirstRowColumnIfInt("select top 1 r.RecipeId from Recipe r join RecipeIngredient rg on r.RecipeId = rg.RecipeId");
            Assume.That(recipeId > 0, "DB didn't return a recipe has Ingredients");
            int dbRecipeIngredientCount = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeIngredient where RecipeId = {recipeId}");
            TestContext.WriteLine($"DB RecipeIngredient Count is {dbRecipeIngredientCount}");
            TestContext.WriteLine($"App RecipeIngredient Count should alos be {dbRecipeIngredientCount}");

            int appRecipeIngredientCount = Recipe.GetRecipeIngredients(recipeId).Rows.Count;

            Assert.IsTrue(appRecipeIngredientCount == dbRecipeIngredientCount, $"App RecipeIngredient Count is {appRecipeIngredientCount}");
            TestContext.WriteLine($"App RecipeIngredient Count is {appRecipeIngredientCount}");
        }

        [Test]
        public void GetRecipeInstructions()
        {
            int recipeId = Utils.GetFirstRowColumnIfInt("select top 1 r.RecipeId from Recipe r join RecipeInstruction rs on r.RecipeId = rs.RecipeId");
            Assume.That(recipeId > 0, "DB didn't return a recipe has Instructions");
            int dbRecipeInstructionsCount = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeInstruction where RecipeId = {recipeId}");
            TestContext.WriteLine($"DB RecipeInstruction Count is {dbRecipeInstructionsCount}");
            TestContext.WriteLine($"App RecipeInstruction Count should alos be {dbRecipeInstructionsCount}");

            int appRecipeInstructionsCount = Recipe.GetRecipeInstructions(recipeId).Rows.Count;

            Assert.IsTrue(appRecipeInstructionsCount == dbRecipeInstructionsCount, $"App RecipeInstruction Count is {appRecipeInstructionsCount}");
            TestContext.WriteLine($"App RecipeInstruction Count is {appRecipeInstructionsCount}");
        }

        [Test]
        public void InsertRecipeIngredient()
        {
            DataTable dtRecipeIngredients = Utils.GetDataTable("select RecipeId, RecipeIngredientId, IngredientId, UnitOfMeasureId, Amount, Seq from RecipeIngredient where RecipeId = (select top 1 RecipeId from RecipeIngredient group by RecipeId order by count(*) desc)");
            int recipeId = Utils.GetFirstRowColumnIfInt(dtRecipeIngredients);
            Assume.That(recipeId > 0, "DB didn't return Recipethat has Ingredients, can't run test");
            int initialCountRecipeIngredients = dtRecipeIngredients.Rows.Count;
            TestContext.WriteLine($"Recipe ({recipeId}) chosen for test, currently has {initialCountRecipeIngredients} Ingredient(s)");
            TestContext.WriteLine("Deleting all Ingredients to re-insert them");
            Utils.ExecuteSQL($"delete RecipeIngredient where RecipeId = {recipeId}");
            int tempCountRecipeIngredients = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeIngredient where RecipeId = {recipeId}");
            Assume.That(tempCountRecipeIngredients == 0, "RecipeIngredients not deleted, cant run test");
            TestContext.WriteLine($"Recipe ({recipeId}) currently has {tempCountRecipeIngredients} Ingredient(s)");


            foreach (DataRow r in dtRecipeIngredients.Rows)
            {
                r["RecipeIngredientId"] = 0;
            }
            Recipe.SaveRecipeChild(dtRecipeIngredients, "RecipeIngredient", recipeId);
            int newCountRecipeIngredients = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeIngredient where RecipeId = {recipeId}");

            Assert.IsTrue(newCountRecipeIngredients == initialCountRecipeIngredients, $"Recipe ({initialCountRecipeIngredients}) should have {initialCountRecipeIngredients} RecipeIngredients");
            TestContext.WriteLine($"Recipe ({recipeId}) has {newCountRecipeIngredients} RecipeIngredients");
        }

        [Test]
        public void InsertRecipeInstruction()
        {
            DataTable dtRecipeInstructions = Utils.GetDataTable("select RecipeId, RecipeInstructionId, Seq, InstructionDesc from RecipeInstruction where RecipeId = (select top 1 RecipeId from RecipeInstruction group by RecipeId order by count(*) desc)");
            int recipeId = Utils.GetFirstRowColumnIfInt(dtRecipeInstructions);
            Assume.That(recipeId > 0, "DB didn't return Recipethat has Instructions, can't run test");
            int initialCountRecipeInstructions = dtRecipeInstructions.Rows.Count;
            TestContext.WriteLine($"Recipe ({recipeId}) chosen for test, currently has {initialCountRecipeInstructions} Instruction(s)");
            TestContext.WriteLine("Deleting all Instructions to re-insert them");
            Utils.ExecuteSQL($"delete RecipeInstruction where RecipeId = {recipeId}");
            int tempCountRecipeInstructions = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeInstruction where RecipeId = {recipeId}");
            Assume.That(tempCountRecipeInstructions == 0, "RecipeInstructions not deleted, cant run test");
            TestContext.WriteLine($"Recipe ({recipeId}) currently has {tempCountRecipeInstructions} Instruction(s)");


            foreach (DataRow r in dtRecipeInstructions.Rows)
            {
                r["RecipeInstructionId"] = 0;
            }
            Recipe.SaveRecipeChild(dtRecipeInstructions, "RecipeInstruction", recipeId);
            int newCountRecipeIngredients = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeInstruction where RecipeId = {recipeId}");

            Assert.IsTrue(newCountRecipeIngredients == initialCountRecipeInstructions, $"Recipe ({initialCountRecipeInstructions}) should have {initialCountRecipeInstructions} RecipeInstructions");
            TestContext.WriteLine($"Recipe ({recipeId}) has {newCountRecipeIngredients} RecipeInstructions");
        }


        [Test]
        public void DeleteRecipeIngredients()
        {
            int recipeId = Utils.GetFirstRowColumnIfInt("select top 1 RecipeId from RecipeIngredient");
            Assume.That(recipeId > 0, "DB didn't return Recipe that has Ingredients, can't run test");
            DataTable dtRecipeIngredient = Utils.GetDataTable($"select * from RecipeIngredient where RecipeId = {recipeId}");
            int recipeIngredientCount = dtRecipeIngredient.Rows.Count;
            TestContext.WriteLine($"Recipe {recipeId} has {recipeIngredientCount} Ingredient(s)");
            TestContext.WriteLine("Deleting ingredients...");

            foreach (DataRow r in dtRecipeIngredient.Rows)
            {
                Recipe.DeleteRecipeChild("RecipeIngredient", (int)r["RecipeIngredientId"]);
            }
            recipeIngredientCount = Utils.GetFirstRowColumnIfInt($"select count(*) from RecipeIngredient where RecipeId = {recipeId}");

            Assert.IsTrue(recipeIngredientCount == 0, $"Recipe should have 0 Ingredients but has {recipeIngredientCount}");
            TestContext.WriteLine($"Recipe {recipeId} has {recipeIngredientCount} Ingredient(s)");
        }


    }
}