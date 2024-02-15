create or alter procedure dbo.IngredientGet(
    @IngredientId int = 0,
    @IngredientName varchar(30) = '',
    @All int = 0,
    @IncludeBlank bit = 0)
as
begin
    select i.IngredientId, i.IngredientName
    from Ingredient i
    where i.IngredientId = @IngredientId
    or @All = 1
    or IngredientName like '%' + @IngredientName + '%'
    union select 0, ' '
    where @IncludeBlank = 1
    order by i.IngredientId
end
go

/*
exec IngredientGet

exec IngredientGet @all = 1, @IncludeBlank = 1

declare @IngredientId int
select top 1 @IngredientId = i.IngredientId from Ingredient i
exec IngredientGet @IngredientId = @IngredientId, @IncludeBlank = 1

exec IngredientGet @IngredientName = 'bak'
*/
