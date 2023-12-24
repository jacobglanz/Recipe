create or alter proc dbo.StaffDelete(
    @StaffId int,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @Return int = 0

    begin try 
        begin transaction 

        declare @tRecipe table(RecipeId int)
        declare @tMeal table(MealId int)
        
        insert @tRecipe(RecipeId) 
        select RecipeId from Recipe where StaffId = @StaffId
        insert @tMeal(MealId)
        select MealId from Meal where StaffId = @StaffId

        delete CookbookRecipe where CookbookRecipeId in (
            select distinct cbr.CookbookRecipeId from CookbookRecipe cbr
            join Cookbook cb on cb.CookbookId = cbr.CookbookId
            left join @tRecipe r on r.RecipeId = cbr.RecipeId
            where cb.StaffId = @StaffId or r.RecipeId is not null
        )
        delete Cookbook where StaffId = @StaffId
        delete RecipeInstruction where RecipeId in (select RecipeId from @tRecipe)
        delete RecipeIngredient where RecipeId in (select RecipeId from @tRecipe)
        delete MealCourseRecipe where MealCourseRecipeId in (
            select MealCourseRecipeId from MealCourseRecipe mcr
            join MealCourse mc on mc.MealCourseId = mcr.MealCourseId
            left join @tRecipe r on mcr.RecipeId = r.RecipeId
            left join @tMeal m on mc.MealId = m.MealId
            where m.MealId is not null or r.RecipeId is not null
        )
        delete MealCourse where MealId in (select MealId from @tMeal) 
        delete Meal where MealId in (select MealId from @tMeal) 
        delete Recipe where StaffId = @StaffId
        delete Staff where StaffId = @StaffId
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
declare @StaffId int = (select top 1 StaffId from Staff)
select * from Staff where StaffId = @StaffId
exec StaffDelete @StaffId = @StaffId
*/