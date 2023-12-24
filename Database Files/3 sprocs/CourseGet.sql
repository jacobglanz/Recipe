create or alter procedure dbo.CourseGet(
    @CourseId int = 0,
	@All int = 0
	)
as
begin
    select
        c.CourseId,
        c.CourseName,
        c.Seq
    from Course c
    where c.CourseId = @CourseId
    or @All = 1
end 
go

/*
exec CourseGet

exec CourseGet @all = 1

declare @CourseId int
select top 1 @CourseId = c.CourseId from Course c
exec CourseGet @CourseId = @CourseId
*/
