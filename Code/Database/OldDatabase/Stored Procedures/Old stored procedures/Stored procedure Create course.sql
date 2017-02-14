USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateCourse
           (@courseName varchar(40),
           @description varchar(200))
as
 SET NOCOUNT ON
INSERT INTO [dbo].[COURSE]
           ([CourseName]
           ,[Description])
     VALUES
           (@courseName
           ,@description)
GO


