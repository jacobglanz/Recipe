create or alter procedure dbo.RecipeDelete(@RecipeId int)
as
begin
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
end 
go 