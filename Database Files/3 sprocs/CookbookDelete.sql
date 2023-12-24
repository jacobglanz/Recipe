create or alter proc dbo.CookbookDelete(
    @CookbookId int = 0
)
as
begin
    begin try
        begin transaction
        delete CookbookRecipe where CookbookId = @CookbookId
        delete Cookbook where CookbookId = @CookbookId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch
end
go

