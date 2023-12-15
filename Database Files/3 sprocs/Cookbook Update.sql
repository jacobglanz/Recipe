create or alter procedure dbo.CookbookUpdate(
	@CookBookId int output,
	@StaffId int,
	@CookBookName varchar(50) output,
	@Price decimal(5,2) output,
	@Active bit = 0,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0
    select @CookBookId = isnull(@CookBookId,0), @Active = isnull(@Active,0), @StaffId = nullif(@StaffId,0)

	if @CookBookId = 0
	begin
		insert Cookbook(StaffId, CookBookName, Price, Active, CreatedDate)
		values (@StaffId, @CookBookName, @Price, @Active, getdate())
		select @CookBookId = scope_identity()
	end
	else
	begin
		update CookBook set
        StaffId = @StaffId,
        CookBookName = @CookBookName,
        Price = @Price,
        Active = @Active
        where CookBookId = @CookBookId
	end

	return @Return
end
