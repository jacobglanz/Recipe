create or alter procedure dbo.IngredientGet(
    @IngredientId int = 0,
    @all int = 0,
    @IncludeBlank bit = 0,
    @IngredientName varchar(30) = '')
as
begin
    select i.IngredientId, i.IngredientName
    from Ingredient i
    where i.IngredientId = @IngredientId
    or (@IngredientName <> '' and i.IngredientName like '%' + @IngredientName + '%')
    or @all = 1
    union select 0, ' '
    where @IncludeBlank = 1
    order by i.IngredientName
end
go

/*
exec IngredientGet

exec IngredientGet @all = 1, @IncludeBlank = 1

exec IngredientGet @IngredientName = ''--empty

exec IngredientGet @IngredientName = 'er'

declare @IngredientId int
select top 1 @IngredientId = i.IngredientId from Ingredient i
exec IngredientGet @IngredientId = @IngredientId
*/
