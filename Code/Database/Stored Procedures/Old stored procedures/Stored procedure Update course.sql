USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateCourse
           (@courseId int,
		   @courseName varchar(40),
           @description varchar(200))
as
 SET NOCOUNT ON
if (@courseName is not null)
UPDATE [dbo].[COURSE]
   SET [CourseName] = @courseName
   WHERE [CourseId]=@courseId

if(@description is not null)
UPDATE [dbo].[COURSE]
   SET [Description] = @description
   WHERE [CourseId]=@courseId

GO


