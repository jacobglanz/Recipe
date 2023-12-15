create or alter proc dbo.CookbookDelete(
    @CookbookId int = 0
)
as
begin
    begin try
        begin transaction
        delete CookBookRecipe where CookBookId = @CookbookId
        delete CookBook where CookBookId = @CookbookId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch
end
go


-- exec CookbookDelete @CookbookId = 106