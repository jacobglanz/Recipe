create or alter procedure dbo.CookbookRecipeGet(
    @All int = 0,
    @CookbookRecipeId int = 0,
    @CookbookId int = 0
)
as
begin
    select
        cbr.CookbookRecipeId,
        cbr.CookbookId,
        cbr.RecipeId,
        cbr.Seq
    from CookbookRecipe cbr
    where cbr.CookbookRecipeId = @CookbookRecipeId
    or cbr.CookbookId = @CookbookId
    or @All = 1
    order by cbr.CookbookId, cbr.Seq
end
go

/*
exec CookbookRecipeGet

exec CookbookRecipeGet @All = 1

declare @CookbookRecipeId int
select top 1 @CookbookRecipeId = cbr.CookbookRecipeId from CookbookRecipe cbr
exec CookbookRecipeGet @CookbookRecipeId = @CookbookRecipeId
*/
