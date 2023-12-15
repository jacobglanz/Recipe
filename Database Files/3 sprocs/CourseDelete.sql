create or alter proc dbo.CourseDelete(
    @CourseId int
)
as
begin
    declare @Return int
    select @CourseId = isnull(@CourseId,0)

    begin try
    begin transaction
        delete mcr
        from MealCourseRecipe mcr
        join MealCourse mc
        on mc.MealCourseId = mcr.MealCourseId
        where mc.CourseId = @CourseId

        delete MealCourse
        where CourseId = @CourseId

        delete Course
        where CourseId = @CourseId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch

    return @Return
end