create or alter procedure dbo.RecipeGet(@RecipeId int = 0, @All int = 0, @RecipeName varchar(75) = '')
as
begin
    select @RecipeName = nullif(@RecipeName, '')
    select
        r.RecipeId,
        RecipeDesc = dbo.RecipeDesc(r.RecipeId),
        r.StaffId,
        r.CuisineTypeId, 
        r.RecipeName, 
        r.Calories, 
        r.Calories, 
        r.DraftTime, 
        r.PublishedTime, 
        r.ArchivedTime, 
        r.RecipeStatus, 
        r.RecipeImage
    from Recipe r
    where r.RecipeId = @RecipeId
    or r.RecipeName like '%' + @RecipeName + '%'
    or @All = 1
    order by r.PublishedTime desc, r.DraftTime desc, r.RecipeName
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