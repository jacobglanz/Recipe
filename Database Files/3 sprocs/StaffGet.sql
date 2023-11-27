create or alter procedure dbo.StaffGet(@all int = 0, @StaffId int = 0, @UserName varchar(100) = '')
as
begin
    select @UserName = nullif(@UserName, '')
    select
        s.StaffId,
        s.FirstName,
        s.LastName,
        s.StaffName,
        s.UserName
    from Staff s
    where s.StaffId = @StaffId
    or s.UserName like '%' + @UserName + '%'
    or @all = 1
end 
go 

/*
exec StaffGet

exec StaffGet @all = 1

exec StaffGet @UserName = ''--empty

exec StaffGet @UserName = 'j'

declare @StaffId int
select top 1 @StaffId = s.StaffId from Staff s
exec StaffGet @StaffId = @StaffId
*/