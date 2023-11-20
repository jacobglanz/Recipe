create or alter procedure dbo.RecipeInstructionGet(@all int = 0, @RecipeInstructionId int = 0, @RecipeId int = 0)
as 
begin 
    select @RecipeId = 0 where @RecipeInstructionId <> 0
    select
        ri.RecipeInstructionId,
        ri.RecipeId,
        ri.Seq,
        ri.InstructionDesc
    from RecipeInstruction ri
    where ri.RecipeInstructionId = @RecipeInstructionId
    or ri.RecipeId = @RecipeId
    or @all = 1
end 
go 

/*
exec RecipeInstructionGet

exec RecipeInstructionGet @all = 1

declare @RecipeId int
select top 1 @RecipeId = ri.RecipeId from RecipeInstruction ri
exec RecipeInstructionGet @RecipeId = @RecipeId --get all RecipeInstruction for one RecipeId

declare @RecipeInstructionId int
select top 1 @RecipeInstructionId = ri.RecipeInstructionId from RecipeInstruction ri
exec RecipeInstructionGet @RecipeInstructionId = @RecipeInstructionId --get one RecipeInstruction

--needs to run together with the declare statements, assumes that there is more then 1 recipe, 
    --gets one RecipeInstruction even the RecipeId is specified
select top 1 @RecipeInstructionId = ri.RecipeInstructionId from RecipeInstruction ri where ri.RecipeId <> @RecipeId
exec RecipeInstructionGet @RecipeInstructionId = @RecipeInstructionId, @RecipeId = @RecipeId
*/