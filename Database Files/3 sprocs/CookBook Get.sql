create or alter procedure dbo.CookBookGet(
    @CookBookId int = 0,
    @all int = 0
)
as
begin
    declare @Return int = 0
    select @CookBookId = isnull(@CookBookId,0), @all = isnull(@all,0)

    if (@all = 1)
    begin
        select
            cb.CookBookId,
            cb.CookBookName,
            Author = s.FirstName + ' ' + s.LastName,
            [Num Recipes] = dbo.CookbookRecipeCount(cb.CookBookId),
            cb.Price
        from CookBook cb
            join Staff s
            on cb.StaffId = s.StaffId
        order by cb.CookBookName
    end
    else
    begin
        select
            cb.CookBookId,
            cb.StaffId,
            cb.CookBookName,
            cb.Price,
            cb.Active,
            cb.CreatedDate
        from CookBook cb
            join Staff s
            on cb.StaffId = s.StaffId
        where cb.CookBookId = @CookBookId
        order by cb.Active desc, cb.CreatedDate desc
    end

    return @Return
end
go
/*
exec CookBookGet

exec CookBookGet @all = 1

declare @CookBookId int
select top 1 @CookBookId = cb.CookBookId from CookBook cb
exec CookBookGet @CookBookId = @CookBookId
*/
