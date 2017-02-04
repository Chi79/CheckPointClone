USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateAttendee
@userName varchar(20),
@appointmentId int,
@statusId int,
@personalNote varchar(200)

as
 SET NOCOUNT ON
if (@hasAttended is not null)
UPDATE [dbo].[ATTENDEE]
set [StatusId]= @statusId
where [AppointmentId]=@appointmentId and [UserName]=@userName

if (@personalNote is not null)
UPDATE [dbo].[ATTENDEE]
set [PersonalNote]= @personalNote
where [AppointmentId]=@appointmentId and [UserName]=@userName

GO


