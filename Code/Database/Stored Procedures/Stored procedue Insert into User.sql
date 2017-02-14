USE [CheckpointDatabase]
GO

CREATE PROCEDURE InsertIntoUser
           @tagId int,
		   @firstName varchar(20),
           @lastName varchar(20),
           @userEMail varchar(30),
           @phoneNumber int,
           @password varchar(20)
as
 SET NOCOUNT ON
INSERT INTO [dbo].[USER]
           ([TagId]
           ,[UserEMail]
           ,[PhoneNumber]
           ,[FirstName]
           ,[LastName]
           ,[Password])
     VALUES
           (@tagId,
		   @userEMail,
		   @phoneNumber,
		   @firstName,
		   @lastName,
           @password)
GO


