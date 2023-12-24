create or alter procedure dbo.CuisineTypeGet(
    @CuisineTypeId int = 0,
    @All int = 0,
    @IncludeBlank bit = 0,
    @Message varchar(500) = ''
)
as
begin
    select ct.CuisineTypeId, ct.CuisineTypeName
    from CuisineType ct
    where ct.CuisineTypeId = @CuisineTypeId
    or @All = 1
    union select 0, ' '
    where @IncludeBlank = 1
    order by ct.CuisineTypeName
end
go

/*
exec CuisineTypeGet

exec CuisineTypeGet @All = 1, @IncludeBlank = 1

declare @CuisineTypeId int
select top 1 @CuisineTypeId = ct.CuisineTypeId from CuisineType ct
exec CuisineTypeGet @CuisineTypeId = @CuisineTypeId
*/