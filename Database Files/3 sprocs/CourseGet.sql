create or alter procedure dbo.CourseGet(@all int = 0,
    @CourseId int = 0,
    @Coursename varchar(30) = '')
as
begin
    select @Coursename = nullif(@Coursename, '')
    select
        c.CourseId,
        c.CourseName,
        c.Seq
    from Course c
    where c.CourseId = @CourseId
        or c.CourseName like '%' + @Coursename + '%'
        or @all = 1
end 
go

/*
exec CourseGet

exec CourseGet @all = 1

exec CourseGet @Coursename = ''--empty

exec CourseGet @Coursename = 'a'

declare @CourseId int
select top 1 @CourseId = c.CourseId from Course c
exec CourseGet @CourseId = @CourseId
*/
