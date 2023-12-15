create or alter proc dbo.UnitOfMeasureDelete(
    @UnitOfMeasureId int
)
as
begin
    declare @return int

    begin try
        begin transaction
        update RecipeIngredient set
        UnitOfMeasureId = null
        where UnitOfMeasureId = @UnitOfMeasureId
        delete UnitOfMeasure where UnitOfMeasureId = @UnitOfMeasureId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch

    return @Return
end


