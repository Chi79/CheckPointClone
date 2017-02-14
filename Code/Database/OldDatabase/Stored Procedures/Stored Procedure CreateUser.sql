USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateUser
(
           @userName varchar(20),                     
           @firstName varchar(20),
           @lastName varchar(20),
		   @tagId int,
		   @userEmail varchar(30),
		   @phoneNumber int,
           @password char(20),          
           @streetAddress varchar(50),
           @postalCode int

)

AS
INSERT INTO [dbo].[USER]
           ([TagId]
           ,[UserEmail]
           ,[PhoneNumber]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[UserName]
           ,[StreetAddress]
           ,[PostalCode])
     VALUES
	 (
           @tagId,
           @userEmail,
           @phoneNumber,
           @firstName ,
           @lastName ,
           @password ,
           @userName ,
           @streetAddress ,
           @postalCode
      )
GO


