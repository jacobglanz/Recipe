create or alter procedure dbo.RecipeIngredientGet(
    @RecipeId int = 0,
    @Message varchar(500) = ''
)
as
begin
    declare @Return int = 0

    select
        ri.RecipeIngredientId,
        ri.RecipeId,
        ri.IngredientId,
        ri.UnitOfMeasureId,
        ri.Amount,
        ri.Seq
    from RecipeIngredient ri
    where ri.RecipeId = @RecipeId
    order by ri.RecipeId, ri.Seq

    return @Return
end
go

/*
exec RecipeIngredientGet

declare @RecipeId int
select top 1 @RecipeId = ri.RecipeId from RecipeIngredient ri
exec RecipeIngredientGet @RecipeId = @RecipeId --get all RecipeIngredient for one RecipeId
*/