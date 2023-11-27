create or alter procedure dbo.RecipeUpdate(
    @RecipeId int output,
    @StaffId int,
    @CuisineTypeId int,
    @RecipeName varchar(75),
    @Calories int,
    @DraftTime datetime output,
    @PublishedTime datetime output,
    @ArchivedTime datetime output,
    @RecipeStatus varchar(9),
    @Message varchar(500) = '' output
) 
as 
begin 
    declare @return int = 0
    
    select @RecipeId = isnull(@RecipeId, 0)

    select @DraftTime = DraftTime, @PublishedTime = PublishedTime, @ArchivedTime = ArchivedTime
    from Recipe 
    Where RecipeId = @RecipeId


    if (@RecipeStatus = 'Draft') select @DraftTime = getdate(), @ArchivedTime = null, @PublishedTime = null
    if (@RecipeStatus = 'Published') select @DraftTime = isnull(@DraftTime, getdate()), @PublishedTime = getdate(), @ArchivedTime = null
    if (@RecipeStatus = 'Archived') select @DraftTime = isnull(@DraftTime, getdate()), @ArchivedTime = getdate()


    if (@RecipeId = 0)
    begin 
        insert Recipe(StaffId, CuisineTypeId, RecipeName, Calories, DraftTime, PublishedTime, ArchivedTime)
        values (@StaffId, @CuisineTypeId, @RecipeName, @Calories, @DraftTime, @PublishedTime, @ArchivedTime)
    end 

    else 
    begin 
        update Recipe set 
        StaffId = @StaffId,
        CuisineTypeId = @CuisineTypeId,
        RecipeName = @RecipeName,
        Calories = @Calories,
        DraftTime = @DraftTime,
        PublishedTime = @PublishedTime,
        ArchivedTime = @ArchivedTime
        where RecipeId = @RecipeId
    end 

    return @return
end 
