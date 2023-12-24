create or alter proc dbo.CookbookAutoCreate(
    @StaffId int,
    @CookbookId int = 0 output,
    @Message varchar(500) = ''
)
as
begin
    declare @Return int = 0, @PricePerRecipe decimal(4,2) = 1.33, @RecipeCount int, @CookbookName varchar(75)
	select 
		@CookbookName = concat('Recipes by ', s.FirstName, ' ', s.LastName),
		@RecipeCount = count(r.RecipeId)
	from Staff s join Recipe r on s.StaffId = r.StaffId 
	where s.StaffId = @StaffId 
	group by s.StaffId, s.FirstName, s.LastName


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
        insert Cookbook(StaffId, CookbookName, Price, Active, CreatedDate)
        select
            @StaffId,
            @CookbookName,
            Price = case when @RecipeCount * @PricePerRecipe < 1000 then @RecipeCount * @PricePerRecipe else 999.99 end,
            Active = 1,
            CreatedDate = getdate()
        select @CookbookId = scope_identity()

        insert CookbookRecipe(CookbookId, RecipeId, Seq)
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

