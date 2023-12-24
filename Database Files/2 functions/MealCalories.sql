create or alter function dbo.MealCalories(@MealId int)
returns int 
begin 
    declare @value int

    select @value = sum(r.Calories) --should return null when sum is 0
    from MealCourse mc 
    join MealCourseRecipe mcr 
        on mc.MealCourseId = mcr.MealCourseId
    join Recipe r 
        on mcr.RecipeId = r.RecipeId
    where mc.MealId = @MealId
    
    return @value
end 
go 

select top 20 *, dbo.MealCalories(MealId) from Meal