USE [CheckpointDatabase]
GO
CREATE PROCEDURE GetAttendanceOnAppointment
(
@appointmentId int,
@numberAttended int output
)
AS
select @numberAttended = count ([AppointmentId])
from [ATTENDEE]
where [HasAttended] = 1 and [AppointmentId] = @appointmentId
go


