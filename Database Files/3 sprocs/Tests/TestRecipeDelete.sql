declare @RecipeId int 

select top 1 @RecipeId = r.RecipeId 
from Recipe r 
left join CookBookRecipe cbr on r.RecipeId = cbr.RecipeId
left join MealCourseRecipe mcr on r.RecipeId = mcr.RecipeId
where cbr.CookBookRecipeId is null 
and mcr.MealCourseRecipeId is null 

select * from Recipe where RecipeId = @RecipeId

exec RecipeDelete @RecipeId = @RecipeId

select * from Recipe where RecipeId = @RecipeId