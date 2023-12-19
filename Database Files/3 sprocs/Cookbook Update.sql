create or alter procedure dbo.CookbookUpdate(
	@CookBookId int output,
	@StaffId int,
	@CookBookName varchar(50) output,
	@Price decimal output,
	@Active bit = 0,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0
    select @CookBookId = isnull(@CookBookId,0), @Active = isnull(@Active,0), @StaffId = nullif(@StaffId,0)

	if(@Price >= 1000)
	begin
		select @Return = 1, @Message = 'Price should be less then $1,000'
		goto finished
	end

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

	finished:
	return @Return
end
go

/*
declare
	@CookBookId int = 0,
	@StaffId int = (select top 1 StaffId from Staff),
	@CookBookName varchar(100) = concat('Na m e  - ', getdate()),
	@Price decimal = 999.00,
	@Active bit = 1

exec CookbookUpdate @CookBookId = @CookBookId, @StaffId = @StaffId, @CookBookName = @CookBookName, @Price = @Price, @Active = @Active
select top 1 * from CookBook order by CookBookId desc
*/