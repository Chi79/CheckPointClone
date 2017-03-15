USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateAttendee
           (
		   @userName varchar(20),
		   @appointmentId int,
           @timeAttended datetime,                      
           @statusId int,
		   @personalNote varchar(200)
		   )
		   ------is Appointment cancelled??
		   ------is the appointment active?
as
INSERT INTO [dbo].[ATTENDEE]
           ([AppointmentId]
           ,[PersonalNote]
           ,[UserName]
           ,[TimeAttended]
           ,[StatusId])
     VALUES
        (
		@appointmentId,
		   @personalNote,
		   @userName,		   
           @timeAttended,                      
           @statusId		   
		)
GO

