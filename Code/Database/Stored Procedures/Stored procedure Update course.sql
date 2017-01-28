USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateCourse
           (@courseId int,
		   @name varchar(40),
           @description varchar(200))
as
 SET NOCOUNT ON
if (@name is not null)
UPDATE [dbo].[COURSE]
   SET [Name] = @name
   WHERE [CourseId]=@courseId

if(@description is not null)
UPDATE [dbo].[COURSE]
   SET [Description] = @description
   WHERE [CourseId]=@courseId

GO


