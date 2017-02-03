USE [CheckpointDatabase]
GO
CREATE PROCEDURE FillAttendeStatus
as
INSERT INTO [dbo].[ATTENDEE_STATUS]
           ([Description]
           ,[StatusId])
     VALUES
	      ('Has requested to attend',0),
		  ('Is an attende not obligatory',1),
		   ('Is an attende obligatory',2),           
		   ('Has attended not obligatory',3),
		   ('Has attended Obligatory',4)		  

GO


