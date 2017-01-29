USE [CheckpointDatabase]
GO
CREATE PROCEDURE ValidateLogin
(@eMail varchar(30),
@password varchar(20),
@isUser BIT OUTPUT,
@isHost BIT OUTPUT)
AS

SELECT @isHost=(SELECT CASE WHEN EXISTS	(SELECT* FROM [HOST] WHERE HostEMail = @eMail AND Password = @password)
THEN CAST(1 AS BIT)
ELSE CAST(0 AS BIT)END)

SELECT @isUser =(SELECT CASE WHEN EXISTS (SELECT * FROM [USER] WHERE UserEMail = @email AND Password = @password)
								  THEN CAST(1 AS BIT)
								  ELSE CAST(0 AS BIT) END)



