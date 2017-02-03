USE [CheckpointDatabase]
GO
CREATE PROCEDURE CreateAppointment
           (
		    @AppointmentName varchar(40),
		    @Date date,
            @FromTime time(7),
            @ToTime time(7),
			@Description varchar(200),
			@HostUserName varchar(20),
            @PostalCode int,
			@StreetAddress varchar(50),
            @CourseId int,                                  
            @Private bit,
            @IsCancelled bit            
			)
as


INSERT INTO [dbo].[APPOINTMENT]
           ([CourseId]
           ,[FromTime]
           ,[ToTime]
           ,[PostalCode]
           ,[AppointmentName]
           ,[Description]
           ,[StreetAddress]
           ,[Date]
           ,[Private]
           ,[IsCancelled]
           ,[HostUserName])
     VALUES
           (
		    @CourseId,
            @FromTime,
            @ToTime,
            @PostalCode,
            @AppointmentName,
            @Description,
            @StreetAddress,
            @Date,
            @Private,
            @IsCancelled,
            @HostUserName)
GO


