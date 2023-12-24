create or alter procedure dbo.RecipeInstructionGet(
    @RecipeId int = 0,
    @Message varchar(500) = ''
)
as
begin
    declare @Return int = 0

    select RecipeInstructionId, RecipeId, Seq, InstructionDesc
    from RecipeInstruction
    where RecipeId = @RecipeId
    order by RecipeId, Seq

    return @Return
end
go


/*
exec RecipeInstructionGet

declare @RecipeId int
select top 1 @RecipeId = ri.RecipeId from RecipeInstruction ri
exec RecipeInstructionGet @RecipeId = @RecipeId --get all RecipeInstruction for one RecipeId
*/