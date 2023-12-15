create or alter procedure dbo.MealGet(
    @all int = 0,
    @MealId int = 0,
    @MealName varchar(30) = ''
)
as
begin
    select @MealName = nullif(@MealName, '')
    select
        m.MealId,
        [Meal Name] = m.MealName,
        [User] = s.FirstName + ' ' + s.LastName,
        [Num Calories] = dbo.MealCalories(m.MealId),
        [Num Courses] = dbo.MealCourseCount(m.MealId),
        [Num Recipes] = dbo.MealRecipeCount(m.MealId)

    from Meal m
    join Staff s
    on m.StaffId = s.StaffId
    where m.MealId = @MealId
    or m.MealName like '%' + @MealName + '%'
    or @all = 1
end
go

/*
exec MealGet

exec MealGet @all = 1

exec MealGet @MealName = ''--empty

exec MealGet @MealName = 'a'

declare @MealId int
select top 1 @MealId = m.MealId from Meal m
exec MealGet @MealId = @MealId
*/
