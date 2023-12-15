create or alter procedure dbo.RecipeGet(
    @RecipeId int = 0,
    @CookBookId int = 0,
    @All int = 0,
    @RecipeName varchar(75) = '',
    @Message varchar(500) = ''
)
as
begin
    select @RecipeName = isnull(@RecipeName, ''), @All = isnull(@All,0), @CookBookId = isnull(@CookBookId,0)

    if (@All = 0 and @RecipeName = '' and @CookBookId = 0)
    begin
        select r.RecipeId, RecipeDesc = dbo.RecipeDesc(r.RecipeId), r.StaffId, r.CuisineTypeId,
            r.RecipeName, r.Calories, r.DraftTime, r.PublishedTime, r.ArchivedTime, r.RecipeStatus
        from Recipe r
        where r.RecipeId = @RecipeId
        group by r.RecipeId, r.StaffId, r.CuisineTypeId, r.RecipeName, r.Calories, r.DraftTime,
            r.PublishedTime, r.ArchivedTime, r.RecipeStatus
        order by r.PublishedTime desc, r.DraftTime desc, r.RecipeName
    end

    else if (@All = 1 or @RecipeName <> '')
    begin
        select r.RecipeId, r.RecipeName, r.RecipeStatus, StaffName = concat(s.FirstName, ' ', s.LastName),
            r.Calories, IngredientsCount = count(rg.IngredientId)
        from Recipe r
        join Staff s
        on s.StaffId = r.StaffId
        left join RecipeIngredient rg
        on r.RecipeId = rg.RecipeId
        where @All = 1
        or r.RecipeName like '%' + @RecipeName + '%'
        group by r.RecipeId, r.RecipeName, r.Calories, r.RecipeStatus, s.FirstName, s.LastName
        order by r.RecipeStatus desc, r.RecipeName
    end
end
go

/*
exec RecipeGet --no results
exec RecipeGet @RecipeName = '' --no results

declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
exec RecipeGet @RecipeId = @RecipeId --should return 1 record

exec RecipeGet @RecipeName = 'er'

exec RecipeGet @All = 1
*/