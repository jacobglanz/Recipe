
declare @CuisineTypeId int, @StaffId int, @RecipeName varchar(75) = 'New Recepe created now'

select top 1 @StaffId = StaffId from Staff
select top 1 @CuisineTypeId = CuisineTypeId from CuisineType

--draft
exec RecipeUpdate 
    @RecipeId = 0, 
    @StaffId = @StaffId, 
    @CuisineTypeId = @CuisineTypeId, 
    @RecipeName = @RecipeName, 
    @Calories = 250, 
    @RecipeStatus = 'draft'
select top 1 * from Recipe where RecipeName = @RecipeName
delete Recipe where RecipeName = @RecipeName

--published
exec RecipeUpdate 
    @RecipeId = 0, 
    @StaffId = @StaffId, 
    @CuisineTypeId = @CuisineTypeId, 
    @RecipeName = @RecipeName, 
    @Calories = 250, 
    @RecipeStatus = 'published'
select top 1 * from Recipe where RecipeName = @RecipeName
delete Recipe where RecipeName = @RecipeName

--archived
exec RecipeUpdate 
    @RecipeId = 0, 
    @StaffId = @StaffId, 
    @CuisineTypeId = @CuisineTypeId, 
    @RecipeName = @RecipeName, 
    @Calories = 250, 
    @RecipeStatus = 'archived'
select top 1 * from Recipe where RecipeName = @RecipeName
delete Recipe where RecipeName = @RecipeName
