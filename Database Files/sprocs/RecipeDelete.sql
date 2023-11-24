create or alter procedure dbo.RecipeDelete(@RecipeId int,
    @Message varchar(500) = '' output)
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