create or alter procedure dbo.CuisineTypeUpdate(
	@CuisineTypeId int output,
	@CuisineTypeName varchar(30),
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0
    select @CuisineTypeId = isnull(@CuisineTypeId,0)

	if @CuisineTypeId = 0
	begin
		insert CuisineType(CuisineTypeName)
		values (@CuisineTypeName)
        select @CuisineTypeId = scope_identity()
	end
	else
	begin
        update CuisineType set
        CuisineTypeName = @CuisineTypeName
	end

	return @Return
end
go 

/*
exec CuisineTypeUpdate @CuisineTypeId = null, @CuisineTypeName = 'Test Cuisine Type'
select * from CuisineType where CuisineTypeName = 'Test Cuisine Type'
delete CuisineType where CuisineTypeName = 'Test Cuisine Type'
*/