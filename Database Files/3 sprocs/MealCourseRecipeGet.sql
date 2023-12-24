create or alter procedure dbo.MealCourseRecipeGet(
	@All int = 0, 
	@MealCourseRecipeId int = 0)
as
begin
    select mcr.MealCourseRecipeId, mcr.MealCourseId, mcr.RecipeId, mcr.MainDish
    from MealCourseRecipe mcr
    where mcr.MealCourseRecipeId = @MealCourseRecipeId
    or @All = 1
end 
go

/*
exec MealCourseRecipeGet

exec MealCourseRecipeGet @all = 1

declare @MealCourseRecipeId int
select top 1 @MealCourseRecipeId = mcr.MealCourseRecipeId from MealCourseRecipe mcr 
exec MealCourseRecipeGet @MealCourseRecipeId = @MealCourseRecipeId
*/
