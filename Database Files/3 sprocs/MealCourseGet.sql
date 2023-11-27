create or alter procedure dbo.MealCourseGet(@all int = 0, @MealCourseId int = 0)
as
begin
    select mc.MealCourseId, mc.MealId, mc.CourseId
    from MealCourse mc
    where mc.MealCourseId = @MealCourseId
    or @all = 1
end 
go

/*
exec MealCourseGet

exec MealCourseGet @all = 1

declare @MealCourseId int
select top 1 @MealCourseId = mc.MealCourseId from MealCourse mc
exec MealCourseGet @MealCourseId = @MealCourseId
*/
