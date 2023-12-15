create or alter proc dbo.CuisineTypeDelete(
    @CuisineTypeId int
)
as
begin
    declare @Return int = 0

    declare @tRecipes table(RecipeId int)
    insert @tRecipes (RecipeId)
    select RecipeId
    from Recipe where CuisineTypeId = @CuisineTypeId

    begin try
    begin transaction
        delete CookBookRecipe where RecipeId in (select RecipeId from @tRecipes)
        delete MealCourseRecipe where RecipeId in (select RecipeId from @tRecipes)
        delete RecipeInstruction where RecipeId in (select RecipeId from @tRecipes)
        delete RecipeIngredient where RecipeId in (select RecipeId from @tRecipes)
        delete Recipe where RecipeId in (select RecipeId from @tRecipes)
        delete CuisineType where CuisineTypeId = @CuisineTypeId
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
    exec CuisineTypeDelete @CuisineTypeId = 126
*/
