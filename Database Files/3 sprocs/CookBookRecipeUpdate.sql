create or alter procedure dbo.CookBookRecipeUpdate(
	@CookBookRecipeId int output,
	@CookBookId int,
	@RecipeId int,
	@Seq int,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0

	select @CookBookRecipeId = isnull(@CookBookRecipeId,0)

	if @CookBookRecipeId = 0
	begin
		insert CookBookRecipe(CookBookId, RecipeId, Seq)
		values (@CookBookId, @RecipeId, @Seq)
		select @CookBookRecipeId = scope_identity()
	end
	else
	begin
        update CookBookRecipe set
        RecipeId = @RecipeId,
        Seq = @Seq
        where CookBookRecipeId = @CookBookRecipeId
	end

	return @Return
end