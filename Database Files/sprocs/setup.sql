/*
  Get(@all int = 0, @ Id int = 0)
as 
begin 
    select
        
    from 
    where @
    or @all = 1
end 
go 

SELECT COLUMN_NAME, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = '';

exec StaffGet

exec StaffGet @all = 1

exec StaffGet @UserName = ''--empty

exec StaffGet @UserName = 'j'

declare @StaffId int
select top 1 @StaffId = s.StaffId from Staff s
exec StaffGet @StaffId = @StaffId
*/
