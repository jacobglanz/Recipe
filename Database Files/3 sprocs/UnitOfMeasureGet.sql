create or alter procedure dbo.UnitOfMeasureGet(
    @all int = 0,
    @UnitOfMeasureId int = 0,
    @IncludeBlank bit = 0,
    @UnitName varchar(30) = ''
)
as
begin
    select @UnitName = nullif(@UnitName, '')
    select
        uom.UnitOfMeasureId,
        uom.UnitName,
        uom.Abbreviation
    from UnitOfMeasure uom
    where uom.UnitOfMeasureId = @UnitOfMeasureId
    or uom.UnitName like '%' + @UnitName + '%'
    or @all = 1
    union select 0, ' ', ' '
    where @IncludeBlank = 1
    order by uom.UnitName
end

/*
exec UnitOfMeasureGet

exec UnitOfMeasureGet @all = 1, @IncludeBlank = 1

exec UnitOfMeasureGet @UnitName = ''--empty

exec UnitOfMeasureGet @UnitName = 'il'

declare @UnitOfMeasureId int
select top 1 @UnitOfMeasureId = uom.UnitOfMeasureId from UnitOfMeasure uom
exec UnitOfMeasureGet @UnitOfMeasureId = @UnitOfMeasureId
*/