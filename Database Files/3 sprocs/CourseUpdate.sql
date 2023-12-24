create or alter procedure dbo.CourseUpdate(
	@CourseId int output,
	@CourseName varchar(30),
	@Seq int,
	@Message varchar(500) = '' output
)
as
begin
	declare @Return int = 0
	select @CourseId = isnull(@CourseId,0)
	
	if (@CourseId = 0)
	begin
		insert Course(CourseName, Seq)
		values (@CourseName, @Seq)
		select @CourseId = scope_identity()
	end
	else
	begin
		update Course set 
		CourseName = @CourseName,
		Seq = @Seq
		where CourseId = @CourseId
	end
	
	return @Return
end

