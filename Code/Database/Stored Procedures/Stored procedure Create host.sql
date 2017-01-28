USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateHost
           (@hostEMail varchar(30),
           @firstName varchar(20),
           @lastName varchar(20),
		   @phonenumber int,
		   @password varchar(20))
as          
 SET NOCOUNT ON
INSERT INTO [dbo].[HOST]
           ([HostEMail]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[PhoneNumber])
     VALUES
	       (@hostEMail
           ,@firstName
           ,@lastName
           ,@password
           ,@phoneNumber)

GO


