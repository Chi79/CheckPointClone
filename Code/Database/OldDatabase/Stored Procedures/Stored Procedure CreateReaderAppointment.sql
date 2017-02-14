USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateReaderAppointment
(
           @readerId int,
            @appointmentId int
)
AS
INSERT INTO [dbo].[READER_APPOINTMENT]
           ([ReaderId]
           ,[AppointmentId])
     VALUES
    (          
	  @readerId ,
      @appointmentId 
	)

GO


