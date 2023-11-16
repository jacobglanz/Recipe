use HeartyHearthDB
   go 
   delete CookBookRecipe
   delete CookBook
   delete MealCourseRecipe
   delete MealCourse
   delete RecipeInstruction
   delete RecipeIngredient
   delete Recipe
   delete Meal
   delete Staff
   delete Ingredient
   delete UnitOfMeasure
   delete Course
   delete CuisineType
go

insert CuisineType(CuisineTypeName)
   select 'American'
   union select 'French'
   union select 'English'
   union select 'China'
   union select 'Egy'
go

insert Staff(FirstName, LastName, Username)
   select 'Jacob', 'Glanz', 'jacob123'
   union select 'Jhon', 'Dow', 'JDow9856'
   union select 'Moshe', 'Weiss', 'MosheW546'
go

;with x as(
   select UserName = 'jacob123', CuisineTypeName = 'American', RecipeName = 'Chocolate Chip Cookies', Calories = 200, DraftTime = getdate(), PublishedTime = null, ArchivedTime = null
   union select 'jacob123', 'French', 'Apple Yogurt Smoothie', 100, getdate(), null, getdate()
   union select 'JDow9856', 'English', 'Cheese Bread', 155, getdate(), dateadd(day, 323, getdate()), dateadd(day, 500, getdate())
   union select 'MosheW546', 'American', 'Butter Muffins', 175, dateadd(day, -500, getdate()), null, null
)
insert Recipe(StaffId, CuisineTypeId, RecipeName, Calories, DraftTime, PublishedTime, ArchivedTime)
   select s.StaffId, ct.CuisineTypeId, x.RecipeName, x.Calories, x.DraftTime, x.PublishedTime, x.ArchivedTime
   from x
   join Staff s on x.UserName = s.Username
   join CuisineType ct on x.CuisineTypeName = ct.CuisineTypeName
go 