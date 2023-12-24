create or alter procedure dbo.RecipeInstructionDelete(
	@RecipeInstructionId int,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0

	delete RecipeInstruction 
	where RecipeInstructionId = @RecipeInstructionId

	return @Return
end