create or alter procedure dbo.CookbookRecipeDelete(
	@CookbookRecipeId int,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0

	delete CookbookRecipe where CookbookRecipeId = @CookbookRecipeId

	return @Return
end