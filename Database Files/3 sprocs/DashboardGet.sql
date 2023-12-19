create or alter proc dbo.DashboardGet(
    @Message varchar(500) = ''
)
as
begin
    declare @Return int = 0

    select RecordType = 'Recipes', Count = count(*) from Recipe
    union select 'Meals', count(*) from Meal
    union select 'CookBooks', count(*) from CookBook
    order by RecordType desc

    return @Return
end
go

-- exec DashboardGet