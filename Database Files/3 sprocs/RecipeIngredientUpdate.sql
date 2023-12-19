create or alter proc dbo.RecipeIngredientUpdate(
    @RecipeIngredientId int output,
    @RecipeId int,
    @IngredientId int,
    @UnitOfMeasureId int,
    @Amount decimal(10,2) output,
    @Seq int,
    @Message varchar(500) = ''
)
as
begin
    declare @Return int = 0

    select @RecipeIngredientId = isnull(@RecipeIngredientId,0), @UnitOfMeasureId = nullif(@UnitOfMeasureId,0)

    if @RecipeIngredientId = 0
    begin
        insert RecipeIngredient(RecipeId, IngredientId, UnitOfMeasureId, Amount, Seq)
        values (@RecipeId, @IngredientId, @UnitOfMeasureId, @Amount, @Seq)
        select @RecipeIngredientId = scope_identity()
    end
    else
    begin
        update RecipeIngredient set
        IngredientId = @IngredientId,
        UnitOfMeasureId = @UnitOfMeasureId,
        Amount = @Amount,
        Seq = @Seq
        where RecipeIngredientId = @RecipeIngredientId
    end

    return @Return
end
go
