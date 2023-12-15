create or alter procedure dbo.CuisineTypeGet(
    @CuisineTypeId int = 0,
    @all int = 0,
    @IncludeBlank bit = 0,
    @Message varchar(500) = ''
)
as
begin
    select ct.CuisineTypeId, ct.CuisineTypeName
    from CuisineType ct
    where ct.CuisineTypeId = @CuisineTypeId
    or @all = 1
    union select 0, ' '
    where @IncludeBlank = 1
    order by ct.CuisineTypeName
end
go

/*
exec CuisineTypeGet

exec CuisineTypeGet @all = 1, @IncludeBlank = 1

exec CuisineTypeGet @CuisineTypeName = ''--empty

exec CuisineTypeGet @CuisineTypeName = 'a'

declare @CuisineTypeId int
select top 1 @CuisineTypeId = ct.CuisineTypeId from CuisineType ct
exec CuisineTypeGet @CuisineTypeId = @CuisineTypeId
*/