
declare @CuisineTypeId int, @RecipeId int, @StaffId int, @RecipeName varchar(75), @RecipeStatus varchar(9)

select top 1 @RecipeId = RecipeId, @RecipeName = RecipeName from Recipe order by RecipeId desc 
select top 1 @StaffId = StaffId from Staff
select top 1 @CuisineTypeId = CuisineTypeId from CuisineType

--draft
exec RecipeUpdate 
    @RecipeId = @RecipeId, 
    @StaffId = @StaffId, 
    @CuisineTypeId = @CuisineTypeId, 
    @RecipeName = @RecipeName, 
    @Calories = 250, 
    @RecipeStatus = 'draft'
select top 1 * from Recipe where RecipeId = @RecipeId

--published
exec RecipeUpdate 
    @RecipeId = @RecipeId, 
    @StaffId = @StaffId, 
    @CuisineTypeId = @CuisineTypeId, 
    @RecipeName = @RecipeName, 
    @Calories = 250, 
    @RecipeStatus = 'published'
select top 1 * from Recipe where RecipeId = @RecipeId

--archived
exec RecipeUpdate 
    @RecipeId = @RecipeId, 
    @StaffId = @StaffId, 
    @CuisineTypeId = @CuisineTypeId, 
    @RecipeName = @RecipeName, 
    @Calories = 250, 
    @RecipeStatus = 'archived'
select top 1 * from Recipe where RecipeId = @RecipeId