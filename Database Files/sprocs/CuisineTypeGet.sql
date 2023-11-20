create or alter procedure dbo.CuisineTypeGet(@all int = 0, @CuisineTypeId int = 0, @CuisineTypeName varchar(30) = '')
as 
begin 
    select @CuisineTypeName = nullif(@CuisineTypeName, '')
    select ct.CuisineTypeId, ct.CuisineTypeName        
    from CuisineType ct
    where ct.CuisineTypeId = @CuisineTypeId
    or ct.CuisineTypeName like '%' + @CuisineTypeName + '%'
    or @all = 1
end 
go 

/*
exec CuisineTypeGet

exec CuisineTypeGet @all = 1

exec CuisineTypeGet @CuisineTypeName = ''--empty

exec CuisineTypeGet @CuisineTypeName = 'a'

declare @CuisineTypeId int
select top 1 @CuisineTypeId = ct.CuisineTypeId from CuisineType ct
exec CuisineTypeGet @CuisineTypeId = @CuisineTypeId
*/