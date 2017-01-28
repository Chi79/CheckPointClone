CREATE TABLE [USER]
( 
	[TagId]              int  NOT NULL ,
	[UserEMail]          varchar(30) UNIQUE NOT NULL ,
	[PhoneNumber]        int  NULL ,
	[FirstName]          varchar(20)  NOT NULL ,
	[LastName]           varchar(20)  NOT NULL ,
	[Password]           char(20)  NOT NULL ,
	CONSTRAINT [XPKUSER] PRIMARY KEY  CLUSTERED ([TagId] ASC)
)
go

CREATE TABLE [COURSE]
( 
	[CourseId]           int  NOT NULL  IDENTITY ( 1,1 ) ,
	[CourseName]         varchar(20)  NOT NULL ,
	[Description]        varchar(200)  NULL ,
	CONSTRAINT [XPKCOURSE] PRIMARY KEY  CLUSTERED ([CourseId] ASC)
)
go

CREATE TABLE [ADDRESS]
( 
	[PostalCode]         int  NOT NULL ,
	[City]               varchar(25)  NOT NULL ,
	CONSTRAINT [XPKADDRESS] PRIMARY KEY  CLUSTERED ([PostalCode] ASC)
)
go

CREATE TABLE [HOST]
( 
	[HostEMail]          varchar(30) UNIQUE NOT NULL ,
	[HostId]             int  NOT NULL  IDENTITY ( 1,1 ) ,
	[FirstName]           varchar(20)  NOT NULL ,
	[LastName]           varchar(20)  NOT NULL ,
	[Password]           varchar(20)  NOT NULL ,
	[PhoneNumber]        int  NULL ,
	CONSTRAINT [XPKHOST] PRIMARY KEY  CLUSTERED ([HostId] ASC)
)
go

CREATE TABLE [APPOINTMENT]
( 
	[AppointmentId]      int  NOT NULL  IDENTITY ( 1,1 ) ,
	[CourseId]           int  NULL ,
	[FromTime]           Time  NULL ,
	[ToTime]             Time  NULL ,
	[PostalCode]         int  NOT NULL ,
	[AppointmentName]    varchar(40)  NOT NULL ,
	[Description]        varchar(200)  NULL ,
	[Location]           varchar(40)  NULL ,
	[Date]               date  NOT NULL ,
	[Private]            bit  NULL ,
	[HostId]             int  NOT NULL ,
	CONSTRAINT [XPKAPPOINTMENT] PRIMARY KEY  CLUSTERED ([AppointmentId] ASC),
	CONSTRAINT [R_3] FOREIGN KEY ([PostalCode]) REFERENCES [ADDRESS]([PostalCode])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_16] FOREIGN KEY ([HostId]) REFERENCES [HOST]([HostId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_1] FOREIGN KEY ([CourseId]) REFERENCES [COURSE]([CourseId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [ATTENDEE]
( 
	[TagId]              int  NOT NULL ,
	[HasAttended]        bit  NULL ,
	[AppointmentId]      int  NOT NULL ,
	[PersonalNote]       varchar(100)  NULL ,
	CONSTRAINT [XPKATTENDEE] PRIMARY KEY  CLUSTERED ([TagId] ASC,[AppointmentId] ASC),
	CONSTRAINT [R_5] FOREIGN KEY ([TagId]) REFERENCES [USER]([TagId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_15] FOREIGN KEY ([AppointmentId]) REFERENCES [APPOINTMENT]([AppointmentId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go
