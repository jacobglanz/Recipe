create or alter procedure dbo.RecipeDelete(
    @RecipeId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

    begin try
    begin transaction
        delete CookBookRecipe where RecipeId = @RecipeId
        delete MealCourseRecipe where RecipeId = @RecipeId
        delete RecipeIngredient where RecipeId = @RecipeId
        delete RecipeInstruction where RecipeId = @RecipeId
        delete Recipe where RecipeId = @RecipeId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch

    finished:
    return @return
end
go

/*
declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
join RecipeInstruction rs on r.RecipeId = rs.RecipeId
join RecipeIngredient rg on r.RecipeId = rg.RecipeId
join MealCourseRecipe mcr on r.RecipeId = mcr.RecipeId
join CookBookRecipe cbr on r.RecipeId = cbr.RecipeId
exec RecipeDelete @RecipeId
*/