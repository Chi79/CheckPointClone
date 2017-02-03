USE [CheckpointDatabase]
GO
CREATE PROCEDURE UpdateAppointment
(          @appointmentId int,
           @appointmentName varchar(40),
		   @description varchar(200),
		   @date date,
		   @fromTime time(7),
           @toTime time(7),
		   @postalCode int,
		   @location varchar(40),
		   @hostId int,		   
		   @courseId int,
		   @private bit)
as
 SET NOCOUNT ON
If @courseID is not null
UPDATE [dbo].[APPOINTMENT]
 SET [CourseId] = @courseId
  WHERE 
 (@appointmentId = [AppointmentID])

  If @fromTime is not Null
UPDATE [dbo].[APPOINTMENT]
 SET [FromTime] = @fromTime
  WHERE 
 (@appointmentId = [AppointmentID])

  If @toTime is not null
UPDATE [dbo].[APPOINTMENT]
 SET [ToTime] = @toTime
  WHERE 
 (@appointmentId = [AppointmentID])
   
     If @postalCode is not null
UPDATE [dbo].[APPOINTMENT]
 SET [PostalCode] = @postalCode
  WHERE 
 (@appointmentId = [AppointmentID])

      If @hostId is not null
UPDATE [dbo].[APPOINTMENT]
 SET [HostId] = @hostId
  WHERE 
 (@appointmentId = [AppointmentID])

      If @appointmentName is not null
UPDATE [dbo].[APPOINTMENT]
 SET [AppointmentName] = @appointmentName
  WHERE 
 (@appointmentId = [AppointmentID])

      If @description is not null
UPDATE [dbo].[APPOINTMENT]
 SET [Description] = @description
  WHERE 
 (@appointmentId = [AppointmentID])

      If @location is not null
UPDATE [dbo].[APPOINTMENT]
 SET [Location] = @location
  WHERE 
 (@appointmentId = [AppointmentID])

      If @date is not null
UPDATE [dbo].[APPOINTMENT]
 SET [Date] = @date
  WHERE 
 (@appointmentId = [AppointmentID])

      If @private is not null
UPDATE [dbo].[APPOINTMENT]
 SET [Private] = @private
  WHERE 
 (@appointmentId = [AppointmentID])
 
GO


