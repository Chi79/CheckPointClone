USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateCourse
           (@name varchar(40),
           @description varchar(200))
as
 SET NOCOUNT ON
INSERT INTO [dbo].[COURSE]
           ([Name]
           ,[Description])
     VALUES
           (@name
           ,@description)
GO


