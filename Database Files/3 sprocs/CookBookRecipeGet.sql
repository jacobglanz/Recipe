create or alter procedure dbo.CookBookRecipeGet(@all int = 0, @CookBookRecipeId int = 0, @CookBookId int = 0)
as
begin
    select @CookBookId = 0 where @CookBookRecipeId <> 0
    select
        cbr.CookBookRecipeId,
        cbr.CookBookId,
        cbr.RecipeId,
        cbr.Seq
    from CookBookRecipe cbr
    where cbr.CookBookRecipeId = @CookBookRecipeId
    or cbr.CookBookId = @CookBookId
    or @all = 1
    order by cbr.CookBookId, cbr.Seq
end
go 

/*
exec CookBookRecipeGet

exec CookBookRecipeGet @all = 1

declare @CookBookRecipeId int
select top 1 @CookBookRecipeId = cbr.CookBookRecipeId from CookBookRecipe cbr
exec CookBookRecipeGet @CookBookRecipeId = @CookBookRecipeId
*/
