USE [CheckpointDatabase]
GO
CREATE PROCEDURE ValidateHostLogin
(@hostUserName varchar(30),
@password varchar(20),
@isHost BIT OUTPUT)
AS

SELECT @isHost=(SELECT CASE WHEN EXISTS	(SELECT* FROM [HOST] WHERE HostUserName = @hostUserName AND Password = @password)
THEN CAST(1 AS BIT)
ELSE CAST(0 AS BIT)END)





