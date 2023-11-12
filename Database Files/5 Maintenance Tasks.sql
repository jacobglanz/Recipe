use HeartyHearthDB
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.

--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
-- SM No need to use "left join".

delete cbr
from Staff s 
left join Recipe r 
	on s.StaffId = r.StaffId
left join CookBook cb 
	on s.StaffId = cb.StaffId
left join CookBookRecipe cbr 
	on cb.CookBookId = cbr.CookBookId
	or r.RecipeId = cbr.RecipeId
where s.UserName = 'Jacob123'
--or this one
delete cbr
from CookBookRecipe cbr 
join Recipe r 
on cbr.RecipeId = r.RecipeId
join CookBook cb 
on cbr.CookBookId = cb.CookBookId
where (select s.StaffId from Staff s where s.UserName = 'Jacob123') in (cb.StaffId, r.StaffId)

delete cb 
from Staff s 
join CookBook cb 
on s.StaffId = cb.StaffId
where s.UserName = 'Jacob123'

delete mcr 
from Staff s 
left join Recipe r 
	on s.StaffId = r.StaffId
left join Meal m 
	on s.StaffId = m.StaffId
left join MealCourse mc 
	on m.MealId = mc.MealId
left join MealCourseRecipe mcr 
	on mcr.RecipeId = r.RecipeId
	or mc.MealCourseId = mcr.MealCourseId
where s.UserName = 'Jacob123'

delete mc 
from MealCourse mc 
join Meal m 
on mc.MealId = m.MealId
join Staff s 
on m.StaffId = s.StaffId
where s.UserName = 'Jacob123'

delete m 
from Meal m 
join Staff s 
on m.StaffId = s.StaffId
where s.UserName = 'Jacob123'

delete rs 
from RecipeInstruction rs 
join Recipe r 
on rs.RecipeId = r.RecipeId
join Staff s 
on r.StaffId = s.StaffId
where s.UserName = 'Jacob123'

delete rg 
from RecipeIngredient rg 
join Recipe r 
on rg.RecipeId = r.RecipeId
join Staff s 
on r.StaffId = s.StaffId
where s.UserName = 'Jacob123'

delete r 
from Recipe r 
join Staff s 
	on r.StaffId = s.StaffId
where s.UserName = 'Jacob123'

delete s 
from Staff s 
where s.UserName = 'Jacob123'

--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) and want to make a modified version. 
	--Write the SQL that clones a specific recipe, add " - clone" to its name.
insert Recipe(StaffId, CuisineTypeId, RecipeName, Calories)
select r.StaffId, r.CuisineTypeId, RecipeName = concat(r.RecipeName, ' - clone'), r.Calories
from Recipe r 
where r.RecipeName = 'Chocolate Chip Cookies'

insert RecipeIngredient(RecipeId, IngredientId, Amount, UnitOfMeasureId, Seq)
select 
	RecipeId = (select RecipeId from Recipe where RecipeName = 'Chocolate Chip Cookies - clone'),
	rg.IngredientId, 
	rg.Amount, 
	rg.UnitOfMeasureId, 
	rg.Seq
from Recipe r 
join RecipeIngredient rg on r.RecipeId = rg.RecipeId
where r.RecipeName = 'Chocolate Chip Cookies'

insert RecipeInstruction(RecipeId, InstructionDesc, Seq)
select 
	RecipeId = (select RecipeId from Recipe where RecipeName = 'Chocolate Chip Cookies - clone'),
	rs.InstructionDesc,
	rs.Seq
from Recipe r 
join RecipeInstruction rs on r.RecipeId = rs.RecipeId
where r.RecipeName = 'Chocolate Chip Cookies'

/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.
Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/
insert CookBook(StaffId, CookBookName, Price, Active)
select 
	s.StaffId, 
	CookBookName = concat('Recipes by ', s.FirstName, ' ', s.LastName),
	Price = (select count(*) from Recipe r where r.StaffId = s.StaffId) * 1.33,
	Active = 1
from Staff s 
where s.UserName = 'jacob123'

insert CookBookRecipe(CookBookId, RecipeId, Seq)
select 
	CookBookId = (select cb.CookBookId from CookBook cb where cb.CookBookName = concat('Recipes by ', s.FirstName, ' ', s.LastName)), 
	r.RecipeId,
	Seq = ROW_NUMBER() over (order by r.RecipeName)
from Staff s 
join Recipe r on s.StaffId = r.StaffId
where s.UserName = 'jacob123'

/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
--the calorie count for Sugar went up by 1 per Teaspoon, and 48 per cup
update r 
set r.Calories += (
    case uom.UnitName
    when 'Teaspoon' then 1
    when 'Cup' then 48
    end 
    * rg.Amount
)
from Recipe r 
    join RecipeIngredient rg on r.RecipeId = rg.RecipeId
    join Ingredient i on rg.IngredientId = i.IngredientId
    join UnitOfMeasure uom on rg.UnitOfMeasureId = uom.UnitOfMeasureId
where i.IngredientName = 'Sugar'

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
;with x as(
	select AvgHoursInDraft = avg(datediff(hour, r.DraftTime, PublishedTime)) 
	from Recipe r
)
select 
	s.FirstName, 
	s.LastName, 
	EmailAddress = lower(concat(substring(s.FirstName,1,1), s.LastName, '@heartyhearth.com')),
	Alert = concat('Your recipe ', r.RecipeName, ' is sitting in draft for ', datediff(hour, r.DraftTime, getdate()), ' hours, That is ', 
		datediff(hour, r.DraftTime, getdate()) - x.AvgHoursInDraft, ' hours more than the average ', 
		x.AvgHoursInDraft, ' hours all other recipes took to be published.')
from Recipe r 
join Staff s 
	on r.StaffId = s.StaffId
join x 
	on datediff(hour, r.DraftTime, getdate()) > x.AvgHoursInDraft
where r.RecipeStatus = 'Draft'

/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and recieve a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/

;with x as(
	select Count = count(*), AvgPrice = convert(decimal(10,2),avg(cb.Price),2), DiscountedPrice = convert(decimal(10,2),sum(cb.Price) * 0.75)
	from CookBook cb 
)
select EmailBody = concat('Order cookbooks from HeartyHearth.com! We have ', x.Count, ' books for sale, average price is $', x.AvgPrice, '. You can order them all and recieve a 25% discount, for a total of $', x.DiscountedPrice,
'. Click <a href = "www.heartyhearth.com/order/', newid(),'">here</a> to order.')
from x 
