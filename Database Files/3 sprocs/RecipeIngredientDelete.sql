create or alter proc dbo.RecipeIngredientDelete(
    @RecipeIngredientId int = 0,
    @Message varchar(500) = ''
)
as
begin
    declare @Return int = 0

    delete RecipeIngredient
    Where RecipeIngredientId = @RecipeIngredientId

    return @Return
end
go
