create or alter procedure dbo.RecipeUpdate(
    @RecipeId int output,
    @StaffId int,
    @CuisineTypeId int,
    @RecipeName varchar(75),
    @Calories int,
    @DraftTime datetime output,
    @PublishedTime datetime output,
    @ArchivedTime datetime output,
    @RecipeStatus varchar(9) output,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0, @PreviousRecipeStatus varchar(9) = ''
    select @RecipeId = isnull(@RecipeId, 0), @DraftTime = isnull(@DraftTime,getdate())

    if (@RecipeId = 0)
    begin
        insert Recipe(StaffId, CuisineTypeId, RecipeName, Calories, DraftTime, PublishedTime, ArchivedTime)
        values (@StaffId, @CuisineTypeId, @RecipeName, @Calories, @DraftTime, @PublishedTime, @ArchivedTime)
        select @RecipeId = scope_identity() --set Pk to newly created record's Pk
    end
    else
    begin

    select @DraftTime = DraftTime, @PublishedTime = PublishedTime, @ArchivedTime = ArchivedTime, @PreviousRecipeStatus = RecipeStatus
    from Recipe
    Where RecipeId = @RecipeId

    if(@RecipeStatus <> @PreviousRecipeStatus)
    begin
        if (@RecipeStatus = 'Draft') select @DraftTime = getdate(), @ArchivedTime = null, @PublishedTime = null
        if (@RecipeStatus = 'Published') select  @PublishedTime = getdate(), @ArchivedTime = null
        if (@RecipeStatus = 'Archived') select @ArchivedTime = getdate()
    end

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

	finished:
    return @return
end
