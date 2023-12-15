create or alter proc dbo.MealDelete(
    @MealId int = 0,
    @Message varchar(500) = ''
)
as 
begin 
    declare @Return int

    begin try 
        begin transaction 
        delete MealCourseRecipe where MealCourseRecipeId in (
            select MealCourseRecipeId from MealCourseRecipe mcr
            join MealCourse mc on mc.MealCourseId = mcr.MealCourseId
            where mc.MealId = @MealId
        )
        delete MealCourse where MealId = @MealId
        delete Meal where MealId = @MealId
        commit 
    end try 
    begin catch 
        rollback;
        throw
    end catch

    return @Return
end 
go 

/*
declare @i int, @MealId int = (select top 1 MealId from Meal)
exec @i = MealDelete @MealId = @MealId
*/