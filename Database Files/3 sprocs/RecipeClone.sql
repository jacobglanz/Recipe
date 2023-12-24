create or alter proc dbo.RecipeClone(
    @RecipeId int output,
    @Message varchar(500) = '' output
)
as
begin
    select @RecipeId = isnull(@RecipeId,0)
    declare
        @Return int = 0,
        @NewRecipeId int,
        @NewRecipeName varchar(100) = (select concat(RecipeName ,' - clone') from Recipe where RecipeId = @RecipeId)


    if (@RecipeId is null or exists (select * from Recipe where RecipeName = @NewRecipeName))
    begin
        select @Return = 1, @Message = case
            when @RecipeId is null then 'Please provide a RecipeId'
            else 'Recipe cloned already, you can clone the already cloned recipe'
        end
        goto finished
    end


    begin try
        begin transaction

        insert Recipe(StaffId, CuisineTypeId, RecipeName, Calories, DraftTime, PublishedTime, ArchivedTime)
        select StaffId, CuisineTypeId, RecipeName + ' - clone', Calories, DraftTime, PublishedTime, ArchivedTime
        from Recipe
        where RecipeId = @RecipeId
        select @NewRecipeId = scope_identity() --set Pk to newly created record's Pk

        insert RecipeIngredient(RecipeId, IngredientId, UnitOfMeasureId, Amount, Seq)
        select @NewRecipeId, IngredientId, UnitOfMeasureId, Amount, Seq
        from RecipeIngredient
        where RecipeId = @RecipeId

        insert RecipeInstruction(RecipeId, Seq, InstructionDesc)
        select @NewRecipeId, Seq, InstructionDesc
        from RecipeInstruction
        where RecipeId = @RecipeId

        exec RecipeGet @RecipeId = @NewRecipeId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch

    finished:
    return @Return
end
go

/*
declare @RecipeId int
select @RecipeId = RecipeId from Recipe where RecipeName = 'Chocolate Chip Cookies'
select @RecipeId
exec RecipeClone @RecipeId = @RecipeId
*/