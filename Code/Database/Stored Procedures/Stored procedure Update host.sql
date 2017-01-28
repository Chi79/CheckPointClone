USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateHost
           (@hostEMail varchar(30),
		   @newEMail varchar(20),
           @firstName varchar(20),
           @lastName varchar(20),
		   @phoneNumber int,
		   @password varchar(20))
as
 SET NOCOUNT ON
if (@hostEMail is not null and @newEMail is not null)
UPDATE [dbo].[HOST]
   SET [HostEMail] = @newEMail
 WHERE [HostEmail]=@hostEMail
 
if (@firstName is not null)
UPDATE [dbo].[HOST]
   SET [FirstName] = @firstName
 WHERE [HostEmail]=@hostEMail

if (@lastName is not null)
UPDATE [dbo].[HOST]
   SET [LastName] = @lastName
 WHERE [HostEmail]=@hostEMail

 if (@phoneNumber is not null)
UPDATE [dbo].[HOST]
   SET [PhoneNumber] = @phoneNumber
 WHERE [HostEmail]=@hostEMail

 if (@password is not null)
UPDATE [dbo].[HOST]
   SET [Password] = @password
 WHERE [HostEmail]=@hostEMail