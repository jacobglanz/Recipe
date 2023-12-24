create or alter procedure dbo.MealCourseGet(
	@All int = 0, 
	@MealCourseId int = 0)
as
begin
    select mc.MealCourseId, mc.MealId, mc.CourseId
    from MealCourse mc
    where mc.MealCourseId = @MealCourseId
    or @All = 1
end 
go

/*
exec MealCourseGet

exec MealCourseGet @all = 1

declare @MealCourseId int
select top 1 @MealCourseId = mc.MealCourseId from MealCourse mc
exec MealCourseGet @MealCourseId = @MealCourseId
*/
