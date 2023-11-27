create or alter procedure dbo.RecipeIngredientGet(@all int = 0, @RecipeIngredientId int = 0, @RecipeId int = 0)
as 
begin 
    select @RecipeId = 0 where @RecipeIngredientId <> 0
    select
        ri.RecipeIngredientId,
        ri.RecipeId,
        ri.IngredientId,
        ri.UnitOfMeasureId,
        ri.Amount,
        ri.Seq
    from RecipeIngredient ri 
    where ri.RecipeIngredientId = @RecipeIngredientId
    or ri.RecipeId = @RecipeId
    or @all = 1
    order by ri.RecipeId, ri.Seq
end 
go 

/*
exec RecipeIngredientGet

exec RecipeIngredientGet @all = 1

declare @RecipeId int
select top 1 @RecipeId = ri.RecipeId from RecipeIngredient ri
exec RecipeIngredientGet @RecipeId = @RecipeId --get all RecipeIngredient for one RecipeId

declare @RecipeIngredientId int
select top 1 @RecipeIngredientId = ri.RecipeIngredientId from RecipeIngredient ri
exec RecipeIngredientGet @RecipeIngredientId = @RecipeIngredientId --get one RecipeIngredient

--needs to run together with the declare statements, assumes that there is more then 1 recipe, 
    --gets one RecipeIngredient even the RecipeId is specified
select top 1 @RecipeIngredientId = ri.RecipeIngredientId from RecipeIngredient ri where ri.RecipeId <> @RecipeId
exec RecipeIngredientGet @RecipeIngredientId = @RecipeIngredientId, @RecipeId = @RecipeId
*/