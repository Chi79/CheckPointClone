USE [CheckpointDatabase]
GO
CREATE PROCEDURE GetAppointmentDetailsFromHostId
(
@hostId int
)
AS

SELECT*
  FROM [dbo].[APPOINTMENT]
  WHERE [HostId] = @hostId
GO


