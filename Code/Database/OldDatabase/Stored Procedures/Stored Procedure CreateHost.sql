USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateHost
(
            @hostUserName varchar(20),
            @firstName varchar(20),
            @lastName varchar(20),
            @password varchar(20),
            @phoneNumber int,
            @hostEmail varchar(30),
            @streetAddress varchar(50),
            @postalCode int
)
AS

INSERT INTO [dbo].[HOST]
           ([HostUserName]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[PhoneNumber]
           ,[HostEmail]
           ,[StreetAddress]
           ,[PostalCode])
     VALUES
(
            @hostUserName,
            @firstName ,
            @lastName ,
            @password ,
            @phoneNumber ,
            @hostEmail ,
            @streetAddress ,
            @postalCode 
)
GO


