create or alter procedure dbo.StaffUpdate(
	@StaffId int output,
	@FirstName varchar(30),
	@LastName varchar(30),
	@UserName varchar(100),
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0
	select @StaffId = isnull(@StaffId,0)

	if (@StaffId = 0)
	begin
		insert Staff(FirstName, LastName, UserName)
		values (@FirstName, @LastName, @UserName)
        select @StaffId = scope_identity()
	end
	else
	begin
        update Staff set
		FirstName = @FirstName,
        LastName = @LastName,
        UserName = @UserName
        where StaffId = @StaffId
	end

	return @Return
end