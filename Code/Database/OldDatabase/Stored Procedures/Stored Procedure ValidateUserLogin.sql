USE [CheckpointDatabase]
GO
CREATE PROCEDURE ValidateUserLogin
(@userName varchar(30),
@password varchar(20),
@isUser BIT OUTPUT)
AS

SELECT @isUser=(SELECT CASE WHEN EXISTS	(SELECT* FROM [USER] WHERE UserName = @userName AND Password = @password)
THEN CAST(1 AS BIT)
ELSE CAST(0 AS BIT)END)