create or alter procedure dbo.CookBookGet(@all int = 0, @CookBookId int = 0, @CookBookName varchar(50) = '')
as 
begin 
    select  
        cb.CookBookId,
        cb.StaffId,
        cb.CookBookName,
        cb.Price,
        cb.Active,
        cb.CreatedDate
    from CookBook cb
    where cb.CookBookId = @CookBookId
    or (cb.CookBookName like '%' + @CookBookName + '%' and @CookBookName <> '')
    or @all = 1
    order by cb.Active desc, cb.CreatedDate desc
end 
go
/*
exec CookBookGet

exec CookBookGet @all = 1

exec CookBookGet @CookBookName = ''--empty

exec CookBookGet @CookBookName = 'm'

declare @CookBookId int
select top 1 @CookBookId = cb.CookBookId from CookBook cb
exec CookBookGet @CookBookId = @CookBookId
*/
