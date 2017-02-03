USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateReader
(@readerId int)
as
INSERT INTO [dbo].[READER]
           ([ReaderId])
     VALUES
           (@readerId)
GO


