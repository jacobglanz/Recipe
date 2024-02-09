create or alter proc [dbo].[DataUpdate]
as
begin
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

insert CuisineType(CuisineTypeName)
   select 'American'
   union select 'French'
   union select 'English'
   union select 'China'
   union select 'Egy'

insert Course(CourseName, Seq)
   select 'Appetizer', 1
   union select 'Main Course', 2
   union select 'Dessert', 3

insert UnitOfMeasure(UnitName, Abbreviation)
   select 'Tablespoon', 'tbsp'
   union select 'Teaspoon', 'tsp'
   union select 'Ounce', 'oz'
   union select 'Cup', 'cup'
   union select 'Milliliter', 'ml'
   union select 'Liter', 'l'
   union select 'Pound', 'lb'
   union select 'Gram', 'g'
   union select 'Kilogram', 'kg'
   union select 'Quantity', 'qty'
   union select 'Pinch ', 'pinch'
   union select 'Stick', 'stick'

insert Ingredient(IngredientName)
   select 'Sugar'
   union select 'Vanilla Sugar'
   union select 'Oil'
   union select 'Egg'
   union select 'Flour'
   union select 'Baking Powder'
   union select 'Baking Soda'
   union select 'Chocolate Chips'
   union select 'Granny Smith Apple'
   union select 'Vanilla Yogurt'
   union select 'Orange Juice'
   union select 'Honey'
   union select 'Ice Cube'
   union select 'Club Bread'
   union select 'Butter'
   union select 'Shredded Cheese'
   union select 'Cloves Garlic (Crushed)'
   union select 'Black Pepper'
   union select 'Salt'
   union select 'Canilla Pudding'
   union select 'Whipped Cream Cheese'
   union select 'sour cream cheese'
   union select 'vanilla pudding'
   union select 'water'

insert Staff(FirstName, LastName, Username)
   select 'Jacob', 'Glanz', 'jacob123'
   union select 'Jhon', 'Dow', 'JDow9856'
   union select 'Moshe', 'Weiss', 'MosheW546'

;with x as(
   select MealName = 'Breakfast bash', Username = 'jacob123', CreatedAt = getdate()
   union select 'Snack', 'JDow9856', getdate()
   union select 'Lunch', 'jacob123', getdate()
)
insert Meal(StaffId, MealName, CreatedDate)
   select s.StaffId, x.MealName, x.CreatedAt
   from x
   join Staff s
   on x.Username = s.Username

;with x as(
   select MealName = 'Breakfast bash', CourseName = 'Main course'
   union select 'Breakfast bash', 'Appetizer'
   union select 'Snack', 'Appetizer'
   union select 'Lunch', 'Appetizer'
   union select 'Lunch', 'Main course'
)
insert MealCourse(MealId, CourseId)
   select m.MealId, c.CourseId
   from x
   join Course c on x.CourseName = c.CourseName
   join Meal m on x.MealName = m.MealName

;with x as(
   select UserName = 'jacob123', CuisineTypeName = 'American', RecipeName = 'Chocolate Chip Cookies', Calories = 200, DraftTime = getdate(), PublishedTime = null, ArchivedTime = null
   union select 'jacob123', 'French', 'Apple Yogurt Smoothie', 100, getdate(), null, getdate()
   union select 'JDow9856', 'English', 'Cheese Bread', 155, getdate(), dateadd(day, 323, getdate()), dateadd(day, 500, getdate())
   union select 'MosheW546', 'American', 'Butter Muffins', 175, dateadd(day, -500, getdate()), null, null
   union select 'MosheW546', 'American', 'Family Pizza Pie', 2505, dateadd(day, -50, getdate()), null, null
   union select 'MosheW546', 'American', 'Tomato Basil Pasta', 2505, dateadd(day, -50, getdate()), null, null
   union select 'MosheW546', 'American', 'Pancakes', 2505, dateadd(day, -50, getdate()), null, null
   union select 'MosheW546', 'American', 'Grilled Cheese', 2505, dateadd(day, -50, getdate()), dateadd(day, -25, getdate()), null
)
insert Recipe(StaffId, CuisineTypeId, RecipeName, Calories, DraftTime, PublishedTime, ArchivedTime)
   select s.StaffId, ct.CuisineTypeId, x.RecipeName, x.Calories, x.DraftTime, x.PublishedTime, x.ArchivedTime
   from x
   join Staff s on x.UserName = s.Username
   join CuisineType ct on x.CuisineTypeName = ct.CuisineTypeName

;with x as(
   select Amount = 1, UnitOfMeasureAbbreviation = 'tsp', IngredientName = 'sugar', Seq = 1, RecipeName = 'Chocolate Chip Cookies'
   union select 0.5, 'cup', 'oil', 2, 'Chocolate Chip Cookies'
   union select 0.5, 'cup', 'Flour', 1, 'Pancakes'
   union select 3, 'qty',  'egg', 3, 'Chocolate Chip Cookies'
   union select 2, 'cup', 'Flour', 4, 'Chocolate Chip Cookies'
   union select 1, 'tsp', 'vanilla sugar', 5, 'Chocolate Chip Cookies'
   union select 2, 'tsp', 'baking powder', 6, 'Chocolate Chip Cookies'
   union select 0.5, 'tsp', 'baking soda', 7, 'Chocolate Chip Cookies'
   union select 1, 'cup', 'chocolate chips', 8, 'Chocolate Chip Cookies'
   union select 3, 'qty', 'granny smith apple', 1, 'Apple Yogurt Smoothie'
   union select 2, 'cup', 'vanilla yogurt', 2, 'Apple Yogurt Smoothie'
   union select 2, 'tsp', 'sugar', 3, 'Apple Yogurt Smoothie'
   union select 0.5, 'cup', 'orange juice', 4, 'Apple Yogurt Smoothie'
   union select 2, 'tbsp', 'honey', 5, 'Apple Yogurt Smoothie'
   union select 6, 'qty', 'ice cube', 6, 'Apple Yogurt Smoothie'
   union select 1, 'qty', 'club bread', 1, 'Cheese Bread'
   union select 4, 'oz', 'butter', 2, 'Cheese Bread'
   union select 8, 'oz', 'shredded cheese', 3, 'Cheese Bread'
   union select 2, 'qty', 'cloves garlic (crushed)', 4, 'Cheese Bread'
   union select 0.25, 'tsp', 'black pepper', 5, 'Cheese Bread'
   union select 1, 'pinch', 'salt', 6, 'Cheese Bread'
   union select 1, 'stick', 'butter', 1, 'Butter Muffins'
   union select 3, 'cup', 'sugar', 2, 'Butter Muffins'
   union select 2, 'tbsp', 'vanilla pudding', 3, 'Butter Muffins'
   union select 4, null, 'egg', 4, 'Butter Muffins'
   union select 8, 'oz', 'whipped cream cheese', 5, 'Butter Muffins'
   union select 8, 'oz', 'sour cream cheese', 6, 'Butter Muffins'
   union select 1, 'cup', 'flour', 7, 'Butter Muffins'
   union select 2, 'tsp', 'baking powder', 8, 'Butter Muffins'
)
insert RecipeIngredient(RecipeId, IngredientId, Amount, UnitOfMeasureId, Seq)
   select r.RecipeId, i.IngredientId, x.Amount, uom.UnitOfMeasureId, x.Seq
   from x
   join Recipe r on x.RecipeName = r.RecipeName
   join Ingredient i on x.IngredientName = i.IngredientName
   left join UnitOfMeasure uom on x.UnitOfMeasureAbbreviation = uom.Abbreviation

;with x as(
   select InstructionDesc = 'First combine sugar, oil and eggs in a bowl', Seq = 1, RecipeName = 'Chocolate Chip Cookies'
   union select 'Grill the Cheese for 12 minutes on 250 ', 1, 'Grilled Cheese '
   union select 'mix well', 2, 'Chocolate Chip Cookies'
   union select 'add flour, vanilla sugar, baking powder and baking soda', 3, 'Chocolate Chip Cookies'
   union select 'beat for 5 minutes', 4, 'Chocolate Chip Cookies'
   union select 'add chocolate chips', 5, 'Chocolate Chip Cookies'
   union select 'freeze for 1-2 hours', 6, 'Chocolate Chip Cookies'
   union select 'roll into balls and place spread out on a cookie sheet', 7, 'Chocolate Chip Cookies'
   union select 'bake on 350 for 10 min.', 8, 'Chocolate Chip Cookies'
   union select 'Peel the apples and dice', 1, 'Apple Yogurt Smoothie'
   union select 'Combine all ingredients in bowl except for apples and ice cubes', 2, 'Apple Yogurt Smoothie'
   union select 'mix until smooth', 3, 'Apple Yogurt Smoothie'
   union select 'add apples and ice cubes', 4, 'Apple Yogurt Smoothie'
   union select 'pour into glasses', 5, 'Apple Yogurt Smoothie'
   union select 'Slit bread every 3/4 inch', 1, 'Cheese Bread'
   union select 'Combine all ingredients in bowl', 2, 'Cheese Bread'
   union select 'fill slits with cheese mixture', 3, 'Cheese Bread'
   union select 'wrap bread into a foil and bake for 30 minutes', 4, 'Cheese Bread'
   union select 'Cream butter with sugars', 1, 'Butter Muffins'
   union select 'Add eggs and mix well', 2, 'Butter Muffins'
   union select 'Slowly add rest of ingredients and mix well', 3, 'Butter Muffins'
   union select 'fill muffin pans 3/4 full and bake for 30 minutes', 4, 'Butter Muffins'
)
insert RecipeInstruction(RecipeId, InstructionDesc, Seq)
   select r.RecipeId, x.InstructionDesc, x.Seq
   from x
   join Recipe r
   on x.RecipeName = r.RecipeName

;with x as(
   select RecipeName = 'Cheese Bread', MainDish = 1, CourseName = 'Main course', MealName = 'Breakfast bash'
   union select 'Butter Muffins', 0, 'Main course', 'Breakfast bash'
   union select 'Apple Yogurt Smoothie', 1, 'Appetizer', 'Breakfast bash'
   union select 'Apple Yogurt Smoothie', 1, 'Appetizer', 'Snack'
   union select 'Chocolate Chip Cookies', 1, 'Appetizer', 'Lunch'
   union select 'Butter Muffins', 1, 'Appetizer', 'Lunch'
   union select 'Grilled Cheese ', 0, 'Appetizer', 'Lunch'
)
insert MealCourseRecipe(RecipeId, MealCourseId, MainDish)
   select r.RecipeId, mc.MealCourseId, x.MainDish
   from x
   join Recipe r on r.RecipeName = x.RecipeName
   join Meal m on m.MealName = x.MealName
   join Course c on c.CourseName = x.CourseName
   join MealCourse mc on mc.CourseId = c.CourseId and mc.MealId = m.MealId

;with x as (
   select CookBookName = 'Treats for two', Price = 30, Active = 1, Username = 'jacob123', CreatedDate = getdate()
   union select 'The best of the 20''s', 50, 1, 'jacob123', getdate()
   union select 'i''m hungry', 19.9, 0, 'JDow9856', getdate()
   union select 'American food line', 19.99, 0, 'JDow9856', getdate()
   union select 'Canada food line', 19.99, 0, 'MosheW546', getdate()
)
insert CookBook(StaffId, CookBookName, Price, Active, CreatedDate)
   select s.StaffId, x.CookBookName, x.Price, x.Active, x.CreatedDate
   from x
   join Staff s on x.Username = s.Username

;with x as(
   select CookBookName = 'Treats for two', RecipeName = 'Chocolate Chip Cookies', Seq = 1
   union select 'Treats for two', 'Apple Yogurt Smoothie', 2
   union select 'American food line', 'Apple Yogurt Smoothie', 3
   union select 'The best of the 20''s', 'Apple Yogurt Smoothie', 3
   union select 'Canada food line', 'Apple Yogurt Smoothie', 3
   union select 'Treats for two', 'Pancakes', 5
   union select 'Treats for two', 'Cheese Bread', 3
   union select 'Treats for two', 'Butter Muffins', 4
   union select 'The best of the 20''s', 'Butter Muffins', 1
   union select 'The best of the 20''s', 'Cheese Bread', 2
   union select 'American food line', 'Butter Muffins', 1
   union select 'American food line', 'Cheese Bread', 2
   union select 'Canada food line', 'Butter Muffins', 1
   union select 'Canada food line', 'Cheese Bread', 2
   union select 'i''m hungry', 'Cheese Bread', 1
   union select 'i''m hungry', 'Butter Muffins', 2
)
insert CookBookRecipe(CookBookId, RecipeId, Seq)
   select cb.CookBookId, r.RecipeId, x.Seq
   from x
   join CookBook cb on x.CookBookName = cb.CookBookName
   join Recipe r on x.RecipeName = r.RecipeName

end
GO
