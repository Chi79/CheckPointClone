USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateAppoitment
           (@appointmentName varchar(40),
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
INSERT INTO [dbo].[APPOINTMENT]
           ([CourseId]
           ,[FromTime]
           ,[ToTime]
           ,[PostalCode]
           ,[HostId]
           ,[AppointmentName]
           ,[Description]
           ,[Location]
           ,[Date]
           ,[Private])
     VALUES
           (@courseId
           ,@fromTime
           ,@toTime
           ,@postalCode
           ,@hostId
           ,@appointmentName
           ,@description
           ,@location
           ,@date
           ,@private)
GO


