USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateUser
  (        @tagId int,
		   @firstName varchar(20),
           @lastName varchar(20),
           @userEMail varchar(30),
           @phoneNumber int,
           @password varchar(20))
AS
 SET NOCOUNT ON
IF (@firstName is not null)
UPDATE [dbo].[USER]
    set  [FirstName] =@firstName
 WHERE [TagId]=@tagId

IF (@lastName is not null)
UPDATE [dbo].[USER]
  set    [LastName] =@lastName
 WHERE [TagId]=@tagId
IF (@userEMail is not null)
UPDATE [dbo].[USER]
  set   [USEREMail] =@userEMail
 WHERE [TagId]=@tagId
 IF (@phoneNumber is not null)
UPDATE [dbo].[USER]
 set     [PhoneNumber] =@phoneNumber
 WHERE [TagId]=@tagId
 IF (@password is not null)
UPDATE [dbo].[USER]
   set   [Password] =@password
 WHERE [TagId]=@tagId