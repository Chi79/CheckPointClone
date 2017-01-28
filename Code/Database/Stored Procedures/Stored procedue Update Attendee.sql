USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateAttendee
@tagId int,
@appointmentId int,
@hasAttended bit,
@personalNote varchar(100)

as
 SET NOCOUNT ON
if (@hasAttended is not null)
UPDATE [dbo].[ATTENDEE]
set [HasAttended]= @hasAttended
where [AppointmentId]=@appointmentId and [TagId]=@tagId

if (@personalNote is not null)
UPDATE [dbo].[ATTENDEE]
set [PersonalNote]= @personalNote
where [AppointmentId]=@appointmentId and [TagId]=@tagId

GO


