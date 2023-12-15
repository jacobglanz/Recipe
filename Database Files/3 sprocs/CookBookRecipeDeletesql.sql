create or alter procedure dbo.CookBookRecipeDelete(
	@CookBookRecipeId int,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0

	delete CookBookRecipe where CookBookRecipeId = @CookBookRecipeId

	return @Return
end