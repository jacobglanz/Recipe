create or alter procedure dbo.MealGet(@all int = 0, @MealId int = 0, @MealName varchar(30) = '')
as 
begin 
    select @MealName = nullif(@MealName, '')
    select
        m.MealId,
        m.StaffId,
        m.MealName,
        MealCalories = dbo.MealCalories(m.MealId),
        m.Active,
        m.CreatedDate,
        m.MealImage
    from Meal m
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
