create or alter procedure dbo.CookbookGet(
    @CookbookId int = 0,
    @All int = 0
)
as
begin
    declare @Return int = 0
    select @CookbookId = isnull(@CookbookId,0), @All = isnull(@All,0)

    if (@All = 1)
    begin
        select
            cb.CookbookId,
            cb.CookbookName,
            Author = s.FirstName + ' ' + s.LastName,
            NumRecipes = dbo.CookbookRecipeCount(CookbookId),
            cb.Price
        from Cookbook cb
        join Staff s
        on cb.StaffId = s.StaffId
        order by cb.CookbookName
    end
    else
    begin
        select
            cb.CookbookId,
            cb.StaffId,
            cb.CookbookName,
            cb.Price,
            cb.Active,
            cb.CreatedDate
        from Cookbook cb
            join Staff s
            on cb.StaffId = s.StaffId
        where cb.CookbookId = @CookbookId
        order by cb.Active desc, cb.CreatedDate desc
    end

    return @Return
end
go

/*
exec CookbookGet

exec CookbookGet @All = 1

declare @CookbookId int
select top 1 @CookbookId = cb.CookbookId from Cookbook cb
exec CookbookGet @CookbookId = @CookbookId
*/
