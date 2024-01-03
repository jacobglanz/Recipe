create or alter procedure dbo.RecipeGet(
    @RecipeId int = 0,
    @CookbookId int = 0,
    @RecipeName varchar(75) = '',
    @All int = 0,
    @Message varchar(500) = ''
)
as
begin
    select @All = isnull(@All,0), @RecipeName = isnull(@RecipeName,'')

    if (@RecipeId > 0)
    begin
        select r.RecipeId, RecipeDesc = dbo.RecipeDesc(r.RecipeId), r.StaffId, r.CuisineTypeId,
            r.RecipeName, r.Calories, r.DraftTime, r.PublishedTime, r.ArchivedTime, r.RecipeStatus
        from Recipe r
        where r.RecipeId = @RecipeId
        group by r.RecipeId, r.StaffId, r.CuisineTypeId, r.RecipeName, r.Calories, r.DraftTime,
            r.PublishedTime, r.ArchivedTime, r.RecipeStatus
        order by r.PublishedTime desc, r.DraftTime desc, r.RecipeName
    end
    else
    begin
        select r.RecipeId, r.RecipeName, r.RecipeStatus, StaffName = concat(s.FirstName, ' ', s.LastName),
            r.Calories, IngredientsCount = count(rg.IngredientId)
        from Recipe r
        join Staff s
        on s.StaffId = r.StaffId
        left join RecipeIngredient rg
        on r.RecipeId = rg.RecipeId
        where @All = 1
        or r.RecipeName like '%'+ @RecipeName + '%'
        group by r.RecipeId, r.RecipeName, r.Calories, r.RecipeStatus, s.FirstName, s.LastName
        order by r.RecipeStatus desc, r.RecipeName
    end
end
go

/*
exec RecipeGet --no results

declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
exec RecipeGet @RecipeId = @RecipeId --should return 1 record

exec RecipeGet @All = 1
*/