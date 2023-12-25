create or alter procedure dbo.CookbookUpdate(
	@CookbookId int output,
	@StaffId int,
	@CookbookName varchar(50) output,
	@Price decimal(5,2) output,
	@Active bit = 0,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0
    select @CookbookId = isnull(@CookbookId,0), @Active = isnull(@Active,0), @StaffId = nullif(@StaffId,0)

	if(@Price >= 1000)
	begin
		select @Return = 1, @Message = 'Price should be less then $1,000'
		goto finished
	end

	if @CookbookId = 0
	begin
		insert Cookbook(StaffId, CookbookName, Price, Active, CreatedDate)
		values (@StaffId, @CookbookName, @Price, @Active, getdate())
		select @CookbookId = scope_identity()
	end
	else
	begin
		update Cookbook set
        StaffId = @StaffId,
        CookbookName = @CookbookName,
        Price = @Price,
        Active = @Active
        where CookbookId = @CookbookId
	end

	finished:
	return @Return
end
go

/*
declare
	@CookbookId int = 0,
	@StaffId int = (select top 1 StaffId from Staff),
	@CookbookName varchar(100) = concat('Name - ', getdate()),
	@Price decimal = 999.00,
	@Active bit = 1

exec CookbookUpdate @CookbookId = @CookbookId, @StaffId = @StaffId, @CookbookName = @CookbookName, @Price = @Price, @Active = @Active
select top 1 * from Cookbook order by CookbookId desc

delete Cookbook where CookbookName = @CookbookName
*/