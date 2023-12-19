create or alter proc dbo.CookbookCreateOfStaffRecipes(
    @StaffId int,
    @CookbookId int = 0 output,
    @Message varchar(500) = ''
)
as
begin
    declare
        @Return int = 0,
        @PricePerRecipe decimal(4,2) = 1.33,
        @RecipeCount int = (select count(*) from Recipe where StaffId = @StaffId),
        @CookBookName varchar(75) = (select concat('Recipes by ', FirstName, ' ', LastName) from Staff where StaffId = @StaffId)


    if (@StaffId is null or @RecipeCount = 0)
    begin
        select @Return = 1, @Message =  case
            when @StaffId is null then 'Please provide a RecipeId'
            when @RecipeCount = 0 then 'User doesn''t have recipes'
        end
        --if already exists then say this user has already a cook book
        goto finished
    end

    begin try
        begin transaction
        insert Cookbook(StaffId, CookBookName, Price, Active, CreatedDate)
        select
            @StaffId,
            @CookBookName,
            Price = case when @RecipeCount * @PricePerRecipe < 1000 then @RecipeCount * @PricePerRecipe else 999.99 end,
            Active = 1,
            CreatedDate = getdate()
        select @CookbookId = scope_identity()

        insert CookBookRecipe(CookBookId, RecipeId, Seq)
        select @CookbookId, RecipeId, row_number() over (order by RecipeName)
        from Recipe
        where StaffId = @StaffId

        exec CookbookGet @CookbookId = @CookbookId
        commit
    end try
    begin catch
        rollback;
        throw
    end catch

    finished:
    return @Return
end
go

