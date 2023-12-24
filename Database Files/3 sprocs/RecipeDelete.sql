create or alter procedure dbo.RecipeDelete(
    @RecipeId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

	if exists (select * from Recipe r where r.RecipeId = @RecipeId and (r.RecipeStatus = 'Published' or datediff(day, r.ArchivedTime, getdate()) <= 30))
    begin
        if (select r.RecipeStatus from Recipe r where r.RecipeId = @RecipeId) = 'Published'
        begin 
            select @Message = 'Cannot delete Recipe because it''s currently Published'
        end 
        else
        begin 
            select @Message = 'Cannot delete Recipe because it has ben Archived less then 30 days ago'
        end
        select @return = 1
        goto finished
    end

    begin try
    begin transaction
        delete CookBookRecipe where RecipeId = @RecipeId
        delete MealCourseRecipe where RecipeId = @RecipeId
        delete RecipeIngredient where RecipeId = @RecipeId
        delete RecipeInstruction where RecipeId = @RecipeId
        delete Recipe where RecipeId = @RecipeId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch

    finished:
    return @return
end
go

/*
declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
join RecipeInstruction rs on r.RecipeId = rs.RecipeId
join RecipeIngredient rg on r.RecipeId = rg.RecipeId
join MealCourseRecipe mcr on r.RecipeId = mcr.RecipeId
join CookBookRecipe cbr on r.RecipeId = cbr.RecipeId
exec RecipeDelete @RecipeId
*/