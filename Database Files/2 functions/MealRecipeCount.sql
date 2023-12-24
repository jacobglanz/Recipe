create or alter function dbo.MealRecipeCount(
    @MealId int
)
returns int
begin
    declare @Value int = 0

    select @Value = count(*)
    from Meal m
    join MealCourse mc
    on m.MealId = mc.MealId
    join MealCourseRecipe mcr
    on mcr.MealCourseId = mc.MealCourseId
    where m.MealId = @MealId

    return @Value
end
go

select top 20 *, dbo.MealRecipeCount(MealId) from Meal