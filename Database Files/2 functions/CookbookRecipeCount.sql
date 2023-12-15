create or alter function dbo.CookbookRecipeCount(
    @CookBookId int
)
returns int
begin
    declare @Value int = 0

    select @Value = count(*)
    from Recipe r
    where r.RecipeId in (
        select cbr.RecipeId
        from CookBookRecipe cbr
        where cbr.CookBookId = @CookBookId
    )

    return @Value
end
go

-- select *, dbo.CookbookRecipeCount(CookBookId) from CookBook