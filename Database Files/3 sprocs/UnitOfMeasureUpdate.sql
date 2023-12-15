create or alter procedure dbo.UnitOfMeasureUpdate(
	@UnitOfMeasureId int output,
	@UnitName varchar(30),
	@Abbreviation varchar(5),
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0
	select @UnitOfMeasureId = isnull(@UnitOfMeasureId,0)

	if (@UnitOfMeasureId = 0)
	begin
		insert UnitOfMeasure(UnitName, Abbreviation)
		values (@UnitName, @Abbreviation)
	select @UnitOfMeasureId = scope_identity()
	end
	else
	begin
		update UnitOfMeasure set
        UnitName = @UnitName,
        Abbreviation = @Abbreviation
        where UnitOfMeasureId = @UnitOfMeasureId
	end

	return @Return
end