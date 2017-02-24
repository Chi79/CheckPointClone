USE [CheckPoint]
GO


INSERT INTO [dbo].[READER]
           ([ReaderId])
     VALUES
           (1),(2)
GO
INSERT INTO [dbo].[COURSE]
           ([Name]
           ,[Description]
           ,[IsPrivate])
     VALUES
           ('C#'
           ,'DesignPatterns'
           ,0)
		   ,('Software development'
		   ,'Agile development'
		   ,1)
GO

INSERT INTO [dbo].[CLIENT]
           ([Email]
           ,[PhoneNumber]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[UserName]
           ,[Address]
           ,[PostalCode]
           ,[ClientType])
     VALUES
           ('mliknes@hotmail.com'
           ,47882901
           ,'Morten'
           ,'Liknes'
           ,66666666
           ,'Morten'
           ,'GamleSyrevegen 44'
           ,4280
           ,1),
		   ('Tonje_@hotmail.co.uk'
           ,99297412
           ,'Chi'
           ,'Lam'
           ,66666666
           ,'Chi'
           ,'Oldacidroad 66'
           ,3917
           ,1),
		   ('Kevin.brueland@gmail.com'
           ,41283763
           ,'Kevin'
           ,'Brueland'
           ,66666666
           ,'Kevin'
           ,'TrippingRoad 99'
           ,3917
           ,1),
		   ('hans.p.halvorsen@usn.no'
           ,35575158
           ,'Hans Petter'
           ,'Halvorsen'
           ,66666666
           ,'HansPetter'
           ,'ScrummingRoad'
           ,3917
           ,0),
		   ('Olav.Dehli@usn.no'
           ,35575182
           ,'Olav'
           ,'Dælhli'
           ,66666666
           ,'Olav'
           ,'SQLroad'
           ,3917
           ,0)
GO



INSERT INTO [dbo].[CLIENT_TAG]
           ([TagId]
           ,[UserName])
     VALUES
           ('HexValue1'
           ,'Olav'),
		   ('HexValue2'
		   ,'HansPetter')
GO


INSERT INTO [dbo].[APPOINTMENT]
           ([CourseId]
           ,[StartTime]
           ,[EndTime]
           ,[PostalCode]
           ,[AppointmentName]
           ,[Description]
           ,[Address]
           ,[Date]
           ,[IsCancelled]
           ,[UserName]
           ,[IsObligatory])
     VALUES
         (  (Select CourseId
		    From [COURSE]
			where (Name = 'C#'))
           ,'08:00'
           ,'12:00'
           ,3917
           ,'Repository'
           ,'Data access'
           ,'Porsgrunn'
           ,'2017-03-01'
           ,0
           ,'Chi'
           ,1),
		   ((Select CourseId
		    From [COURSE]
			where (Name = 'Software development'))
           ,'12:00'
           ,'17:00'
           ,3917
           ,'How to be a Scrum Master'
           ,'Scrum4life'
           ,'Porsgrunn'
           ,'2017-03-05'
           ,0
           ,'Kevin'
           ,0)
GO
INSERT INTO [dbo].[READER_APPOINTMENT]
           ([ReaderId]
           ,[AppointmentId])
     VALUES
           (1
           ,
		   (Select AppointmentId
		      From [APPOINTMENT]
			  where(AppointmentName='Repository')))
		,(1,
		 (Select AppointmentId
		      From [APPOINTMENT]
			  where(AppointmentName='How to be a Scrum Master')))
		,
		(2,
		(Select AppointmentId
		 From [APPOINTMENT]
	     where(AppointmentName='Repository')))
GO
INSERT INTO [dbo].[ATTENDEE]
           ([AppointmentId]
           ,[PersonalNote]
           ,[TimeAttended]
           ,[StatusId]
           ,[TagId])
     VALUES
           (
		   (Select AppointmentId
		 From [APPOINTMENT]
	     where(AppointmentName='Repository'))
           ,'Install visual studio'
           ,Null
           ,0
           ,'HexValue1'),
		   (
		    (Select AppointmentId
		      From [APPOINTMENT]
			  where(AppointmentName='How to be a Scrum Master'))
           ,'Read about scrum'
           ,Null
           ,0
           ,'HexValue2'),
		   (
		    (Select AppointmentId
		      From [APPOINTMENT]
			  where(AppointmentName='How to be a Scrum Master'))
           ,'Chill'
           ,Null
           ,0
           ,'HexValue1')
GO