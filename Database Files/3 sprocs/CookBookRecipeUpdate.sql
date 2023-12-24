create or alter procedure dbo.CookbookRecipeUpdate(
	@CookbookRecipeId int output,
	@CookbookId int,
	@RecipeId int,
	@Seq int,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0

	select @CookbookRecipeId = isnull(@CookbookRecipeId,0)

	if @Seq is null
	begin
		select
			@Return = 1,
			@Message = (select concat('Recipe ', RecipeName, ' Seq Required' ) from Recipe where RecipeId = @RecipeId)
		goto finished
	end

	if @CookbookRecipeId = 0
	begin
		insert CookbookRecipe(CookbookId, RecipeId, Seq)
		values (@CookbookId, @RecipeId, @Seq)
		select @CookbookRecipeId = scope_identity()
	end
	else
	begin
        update CookbookRecipe set
        RecipeId = @RecipeId,
        Seq = @Seq
        where CookbookRecipeId = @CookbookRecipeId
	end

	finished:
	return @Return
end