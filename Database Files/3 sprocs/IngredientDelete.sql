create or alter proc dbo.IngredientDelete(
    @IngredientId int
)
as
begin
    declare @Return int = 0

    begin try
        begin transaction
        delete RecipeIngredient where IngredientId = @IngredientId
        delete Ingredient where IngredientId = @IngredientId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch

    return @Return
end