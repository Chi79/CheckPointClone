USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateHost
           (@hostId int,
		   @hostEMail varchar(30),
		   @firstName varchar(20),
           @lastName varchar(20),
		   @phoneNumber int,
		   @password varchar(20))
as
 SET NOCOUNT ON
if (@hostEMail is not null)
UPDATE [dbo].[HOST]
   SET [HostEMail] = @hostEMail
 WHERE [HostId]=@hostId
 
if (@firstName is not null)
UPDATE [dbo].[HOST]
   SET [FirstName] = @firstName
 WHERE [HostId]=@hostId

if (@lastName is not null)
UPDATE [dbo].[HOST]
   SET [LastName] = @lastName
 WHERE [HostId]=@hostId

 if (@phoneNumber is not null)
UPDATE [dbo].[HOST]
   SET [PhoneNumber] = @phoneNumber
 WHERE [HostId]=@hostId

 if (@password is not null)
UPDATE [dbo].[HOST]
   SET [Password] = @password
 WHERE [HostId]=@hostId