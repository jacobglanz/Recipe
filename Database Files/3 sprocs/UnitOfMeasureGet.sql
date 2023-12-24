create or alter procedure dbo.UnitOfMeasureGet(
    @All int = 0,
    @UnitOfMeasureId int = 0,
    @IncludeBlank bit = 0
)
as
begin
    select
        uom.UnitOfMeasureId,
        uom.UnitName,
        uom.Abbreviation
    from UnitOfMeasure uom
    where uom.UnitOfMeasureId = @UnitOfMeasureId
    or @All = 1
    union select 0, ' ', ' '
    where @IncludeBlank = 1
    order by uom.UnitOfMeasureId
end
go

/*
exec UnitOfMeasureGet

exec UnitOfMeasureGet @All = 1, @IncludeBlank = 1

exec UnitOfMeasureGet @UnitName = ''--empty

exec UnitOfMeasureGet @UnitName = 'il'

declare @UnitOfMeasureId int
select top 1 @UnitOfMeasureId = uom.UnitOfMeasureId from UnitOfMeasure uom
exec UnitOfMeasureGet @UnitOfMeasureId = @UnitOfMeasureId
*/