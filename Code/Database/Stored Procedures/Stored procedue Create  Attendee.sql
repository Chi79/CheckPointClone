USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateAttendee
           (@tagId int,
		    @appointmentId int,
           @hasAttended bit,          
           @personalNote varchar(100))
as
 SET NOCOUNT ON
INSERT INTO [dbo].[ATTENDEE]
           ([TagId]
           ,[HasAttended]
           ,[AppointmentId]
           ,[PersonalNote])
     VALUES
           (@tagId
           ,@hasAttended
           ,@appointmentId
           ,@personalNote)
GO


