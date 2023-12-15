create or alter proc dbo.StaffGet(
    @StaffId int = 0,
    @All bit = 0,
    @IncludeBlank bit = 0,
    @Message varchar(500) = '' output
)
as
begin
    declare @Return int = 0

    select StaffId, FirstName, LastName, UserName--, StaffName = FirstName + ' ' + LastName
    from Staff
    where StaffId = @StaffId
    or @All = 1
    union select 0, '', '', ''--, ''
    where @IncludeBlank = 1
    order by StaffId

    return @Return
end
go

/*
exec StaffGet

exec StaffGet @all = 1

declare @StaffId int
select top 1 @StaffId = s.StaffId from Staff s
select @StaffId
exec StaffGet @StaffId = @StaffId
*/