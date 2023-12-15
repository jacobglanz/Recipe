create or alter procedure dbo.RecipeInstructionUpdate(
	@RecipeInstructionId int output,
	@RecipeId int,
	@Seq int,
	@InstructionDesc varchar(100),
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0

	select @RecipeInstructionId = isnull(@RecipeInstructionId,0)

	if @RecipeInstructionId = 0
	begin
		insert RecipeInstruction(RecipeId, Seq, InstructionDesc)
		values (@RecipeId, @Seq, @InstructionDesc)
		select @RecipeInstructionId = scope_identity()
	end
	else
	begin
		update RecipeInstruction set
		Seq = @Seq,
		InstructionDesc = @InstructionDesc
		where RecipeInstructionId = @RecipeInstructionId
	end

	return @Return
end