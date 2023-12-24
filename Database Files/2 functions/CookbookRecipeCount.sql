create or alter function dbo.CookbookRecipeCount(
    @CookbookId int
)
returns int
begin
    declare @Value int = 0

    select @Value = count(*)
    from Cookbook b
	join CookbookRecipe r
	on b.CookbookId = r.CookbookId
	where b.CookbookId = @CookbookId

    return @Value
end
go

select *, dbo.CookbookRecipeCount(CookbookId) from Cookbook