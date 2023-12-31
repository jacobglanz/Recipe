﻿namespace RecipeTesting
{
    public class MealTest
    {
        [SetUp]
        public void Set()
        {
            Utils.RefreshTestData();
        }

        [Test]
        public void GetAllMeal()
        {
            int dbMealCount = Utils.GetFirstRowColumnIfInt("select count(*) from Meal");
            Assume.That(dbMealCount > 0, "DB didn't return any records, can't run test");
            TestContext.WriteLine($"DB returned {dbMealCount} Meal(s)");
            TestContext.WriteLine($"App should also return {dbMealCount} Meal(s)");

            int appMealCount = Meal.GetAll().Rows.Count;

            Assert.IsTrue(dbMealCount == appMealCount, $"App returned {appMealCount} Meal(s)");
            TestContext.WriteLine($"App returned {appMealCount} Meal(s)");
        }
    }
}
