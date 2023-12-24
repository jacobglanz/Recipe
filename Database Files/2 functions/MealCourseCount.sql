create or alter function dbo.MealCourseCount(
    @MealId int
)
returns int
begin
    declare @Value int = 0

    select @Value = count(*)
    from Meal m
    join MealCourse mc
    on m.MealId = mc.MealId
    where m.MealId = @MealId

    return @Value
end
go

select top 20 *, dbo.MealCourseCount(MealId) from Meal