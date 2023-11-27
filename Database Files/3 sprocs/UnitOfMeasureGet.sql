create or alter procedure dbo.UnitOfMeasureGet(@all int = 0, @UnitOfMeasureId int = 0, @UnitName varchar(30) = '')
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
end 

/*
exec UnitOfMeasureGet

exec UnitOfMeasureGet @all = 1

exec UnitOfMeasureGet @UnitName = ''--empty

exec UnitOfMeasureGet @UnitName = 'il'

declare @UnitOfMeasureId int
select top 1 @UnitOfMeasureId = uom.UnitOfMeasureId from UnitOfMeasure uom
exec UnitOfMeasureGet @UnitOfMeasureId = @UnitOfMeasureId
*/