use HeartyHearthDB
/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/

/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
select EntityName = 'Recipes', RecordCount = count(r.RecipeId ) from Recipe r
union select 'Meals', count(m.MealId) from Meal m 
union select 'CookBooks', count(cb.CookBookId) from CookBook cb 

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
;with x as(
    select ri.RecipeId, IngredientsCount = count(ri.RecipeIngredientId)
    from RecipeIngredient ri 
    group by ri.RecipeId
)
select 
    RecipeName = 
        case r.RecipeStatus
            when 'Archived' then concat('<span style="color:gray">', r.RecipeName, '</span>')
            else r.RecipeName
        end, 
    r.RecipeStatus, 
    PublishedDate = isnull(convert(char(10) , r.PublishedTime, 101), ''),
    ArchivedDate = isnull(convert(char(10), r.ArchivedTime, 101), ''),
    s.Username,
    r.Calories,
    x.IngredientsCount
from x
join Recipe r on x.RecipeId = r.RecipeId
join Staff s on r.StaffId = s.StaffId
where r.RecipeStatus <> 'Draft'
order by r.RecipeStatus desc

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
select r.RecipeName, r.Calories, IngredientsCount = count(distinct rg.RecipeIngredientId), InstructionsCount = count(distinct rs.RecipeInstructionId)
from Recipe r 
join RecipeIngredient rg on r.RecipeId = rg.RecipeId
join RecipeInstruction rs on r.RecipeId = rs.RecipeId
where r.RecipeName = 'Butter Muffins'
group by r.RecipeName, r.Calories

select Ingredient = concat(rg.Amount, ' ', uom.UnitName, ' ', i.IngredientName)
from Recipe r 
join RecipeIngredient rg on r.RecipeId = rg.RecipeId
join Ingredient i on rg.IngredientId = i.IngredientId
left join UnitOfMeasure uom on rg.UnitOfMeasureId = uom.UnitOfMeasureId
where r.RecipeName = 'Butter Muffins'
order by rg.Seq

select rs.InstructionDesc 
from Recipe r 
join RecipeInstruction rs on r.RecipeId = rs.RecipeId
where r.RecipeName = 'Butter Muffins'
order by rs.Seq

/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.MealName, s.Username, Calories = sum(r.Calories), CoursesCount = count(distinct mc.MealCourseId), RecipesCount = count(mcr.MealCourseRecipeId)
from Meal m 
join Staff s on m.StaffId = s.StaffId
join MealCourse mc on m.MealId = mc.MealId
join MealCourseRecipe mcr on mc.MealCourseId = mcr.MealCourseId
join Recipe r on r.RecipeId = mcr.RecipeId
where m.Active = 1
group by m.MealName, s.Username
order by m.MealName

/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
select m.MealName, s.Username, m.CreatedDate
from meal m 
join Staff s on m.StaffId = s.StaffId
where m.MealName = 'Breakfast bash'

select Recipe = case 
    when c.CourseName <> 'Main Course' 
        then concat(c.CourseName, ': ', r.RecipeName)
    when c.CourseName = 'Main Course'  and mcr.MainDish = 1 
        then concat('<b>', c.CourseName, ': Main dish - ', r.RecipeName, '</b>')
    else concat( c.CourseName, ': Side dish - ', r.RecipeName)
end 
from meal m 
join MealCourse mc on m.MealId = mc.MealId
join Course c on mc.CourseId = c.CourseId
join MealCourseRecipe mcr on mc.MealCourseId = mcr.MealCourseId
join Recipe r on mcr.RecipeId = r.RecipeId
where m.MealName = 'Breakfast bash'

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select 
    cb.CookBookName, 
    Author = concat(s.FirstName, ' ', s.LastName), 
    RecipeCount = count(cbr.CookBookRecipeId)
from CookBook cb 
join Staff s on cb.StaffId = s.StaffId
join CookBookRecipe cbr on cb.CookBookId = cbr.CookBookId
where cb.Active = 1
group by cb.CookBookName, s.FirstName, s.LastName
order by cb.CookBookName


/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
select cb.CookBookName, s.Username, cb.CreatedDate, cb.Price, Recipes = count(cbr.CookBookRecipeId)
from CookBook cb 
join CookBookRecipe cbr 
    on cb.CookBookId = cbr.CookBookId
join Staff s 
    on cb.StaffId = s.StaffId
where cb.CookBookName = 'Treats for two'
group by cb.CookBookName, s.Username, cb.CreatedDate, cb.Price

select r.RecipeName, ct.CuisineTypeName, IngredientsCount = count(distinct rg.RecipeIngredientId), InstructionsCount = count(distinct rs.RecipeInstructionId)
from Recipe r 
join CuisineType ct on r.CuisineTypeId = ct.CuisineTypeId
join RecipeIngredient rg on r.RecipeId = rg.RecipeId
join RecipeInstruction rs on r.RecipeId = rs.RecipeId
group by r.RecipeName, ct.CuisineTypeName

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/

select distinct
    RecipeName = concat(
        upper(substring(r.RecipeName, len(r.RecipeName), 1)),
        lower(substring(reverse(r.RecipeName), 2, len(r.RecipeName)-1))
    ),
    RecipeImage = concat(
        'Recipe_',
        upper(substring(r.RecipeName, len(r.RecipeName), 1)),
        lower(substring(reverse(replace(r.RecipeName, ' ', '_')), 2, len(r.RecipeName)-1)),
        '.jpg'
    )
from CookBookRecipe cbr
join Recipe r on cbr.RecipeId = r.RecipeId

;with x as (
    select rs.RecipeId, Seq = max(rs.Seq)
    from RecipeInstruction rs 
    group by rs.RecipeId
)
select rs.InstructionDesc, SortPriority = 0
from x 
join RecipeInstruction rs 
on x.RecipeId = rs.RecipeId and x.Seq = rs.Seq
union select 'You have benn fooled!', 1
order by SortPriority



-- For site administration page:
-- 5 seperate reports
--     a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
;with x as(
    select RecipeStatus = 'Draft'
    union select 'Published'
    union select 'Archived'
)
select s.Username, x.RecipeStatus, RecipeCount = count(r.RecipeId)
from Staff s 
cross join x
left join Recipe r on r.StaffId = s.StaffId and r.RecipeStatus = x.RecipeStatus
group by s.Username, x.RecipeStatus
order by s.Username

--     b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
select s.Username, Count = count(r.RecipeId), AvgDaysToPublish = avg(datediff(day, r.DraftTime, PublishedTime))
from Staff s 
left join Recipe r on s.StaffId = r.StaffId
group by s.Username
--     c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
--         Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
select 
    s.Username, 
    TotalMeal = count(m.MealId), 
    ActiveMeals = sum(case m.Active when 1 then 1 else 0 end), 
    InactiveMeal = sum(case m.Active when 0 then 1 else 0 end)
from Staff s 
left join meal m 
    on s.StaffId = m.StaffId
group by s.Username

--     d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
--         Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
select 
    s.Username,
    Total = count(cb.CookBookId),
    Active = sum(case cb.Active when 1 then 1 else 0 end),
    Inactive = sum(case cb.Active when 0 then 1 else 0 end)
from Staff s 
left join CookBook cb 
    on s.StaffId = cb.StaffId
group by s.Username

--     e) List of archived recipes that were never published, and how long it took for them to be archived.
select r.RecipeName, r.DraftTime, r.ArchivedTime, DaysTillArchived = datediff(day, r.DraftTime, r.ArchivedTime)
from Recipe r 
where r.PublishedTime is null 
and r.ArchivedTime is not null



-- For user dashboard page:
--     a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
--         Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
;with x as(
    select s.StaffId 
    from Staff s 
    where s.Username = 'jacob123'
)
select x.StaffId, Entity = 'Recipe', Count = count(r.RecipeId)
from x  
join Recipe r on x.StaffId = r.StaffId
group by x.StaffId
union select x.StaffId, Entity = 'Meal', Count = count(m.MealId)
from x 
join Meal m on x.StaffId = m.StaffId
group by x.StaffId
union select x.StaffId, Entity = 'CookBook', Count = count(cb.CookBookId)
from x
join CookBook cb on x.StaffId = cb.StaffId
group by x.StaffId

--     b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
select 
    r.RecipeName, r.RecipeId,
    r.RecipeStatus, 
    HourDiffPrevStatus = datediff(
        hour, 
        case r.RecipeStatus when 'Published' then r.DraftTime else isnull(r.PublishedTime, r.DraftTime) end,
        isnull(r.ArchivedTime, r.PublishedTime)
    )
from Staff s  
join Recipe r on s.StaffId = r.StaffId  
where s.Username = 'jacob123'
and r.RecipeStatus <> 'Draft'

--     OPTIONAL CHALLENGE QUESTION
--     c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
--         Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
;with x as(
    select ct.CuisineTypeId, NumOfRecipes = count(*)
    from CuisineType ct 
    join Recipe r 
    on ct.CuisineTypeId = r.CuisineTypeId
    join Staff s 
    on r.StaffId = s.StaffId
    where s.UserName = 'jacob123'
    group by ct.CuisineTypeId
)
select ct.CuisineTypeName, NumOfRecipes = isnull(x.NumOfRecipes,0)
from CuisineType ct
left join x 
on x.CuisineTypeId = ct.CuisineTypeId
order by ct.CuisineTypeName
