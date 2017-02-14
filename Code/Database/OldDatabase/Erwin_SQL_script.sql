
CREATE TABLE [READER]
( 
	[ReaderId]           int  NOT NULL ,
	CONSTRAINT [XPKREADER] PRIMARY KEY  CLUSTERED ([ReaderId] ASC)
)
go

CREATE TABLE [COURSE]
( 
	[CourseId]           int  NOT NULL  IDENTITY ( 1,1 ) ,
	[Name]               varchar(20)  NOT NULL ,
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
	[HostUserName]       Varchar(20)  NOT NULL ,
	[FirstName]          Varchar(20)  NOT NULL ,
	[LastName]           Varchar(20)  NOT NULL ,
	[Password]           Varchar(20)  NOT NULL ,
	[PhoneNumber]        int  NULL ,
	[HostEmail]          Varchar(30)  NOT NULL ,
	[StreetAddress]      varchar(50)  NULL ,
	[PostalCode]         int  NOT NULL ,
	CONSTRAINT [XPKHOST] PRIMARY KEY  CLUSTERED ([HostUserName] ASC),
	CONSTRAINT [XAK1HOST] UNIQUE ([HostEmail]  ASC),
	CONSTRAINT [R_30] FOREIGN KEY ([PostalCode]) REFERENCES [ADDRESS]([PostalCode]),		
	CONSTRAINT chk_HostEMail CHECK (HostEmail like '%@%.%'),
	CONSTRAINT chk_HostPassword CHECK (LEN([Password])>5),
    CONSTRAINT chk_HostPhoneNumber CHECK (LEN([PhoneNumber])>7)

)
go

CREATE TABLE [APPOINTMENT]
( 
	[AppointmentId]      int  NOT NULL  IDENTITY ( 1,1 ) ,
	[CourseId]           int  NULL ,
	[StartTime]           Time  NULL ,
	[EndTime]             Time  NULL ,
	[PostalCode]         int  NOT NULL ,
	[AppointmentName]    varchar(40)  NOT NULL ,
	[Description]        varchar(200)  NULL ,
	[StreetAddress]      varchar(50)  NULL ,
	[Date]               date  NOT NULL ,
	[IsPrivate]            bit  NULL ,
	[IsCancelled]        bit  NULL ,
	[HostUserName]       Varchar(20)  NULL ,
	CONSTRAINT [XPKAPPOINTMENT] PRIMARY KEY  CLUSTERED ([AppointmentId] ASC),
	CONSTRAINT [R_1] FOREIGN KEY ([CourseId]) REFERENCES [COURSE]([CourseId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_3] FOREIGN KEY ([PostalCode]) REFERENCES [ADDRESS]([PostalCode])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_23] FOREIGN KEY ([HostUserName]) REFERENCES [HOST]([HostUserName])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [READER_APPOINTMENT]
( 
	[ReaderId]           int  NOT NULL ,
	[AppointmentId]      int  NOT NULL ,
	CONSTRAINT [XPKREADER_APPOINTMENT] PRIMARY KEY  CLUSTERED ([ReaderId] ASC,[AppointmentId] ASC),
	CONSTRAINT [R_21] FOREIGN KEY ([ReaderId]) REFERENCES [READER]([ReaderId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_22] FOREIGN KEY ([AppointmentId]) REFERENCES [APPOINTMENT]([AppointmentId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [USER]
( 
	[TagId]              varchar(30)  NOT NULL ,
	[UserEmail]          varchar(30)  NOT NULL ,
	[PhoneNumber]        int  NULL ,
	[FirstName]          varchar(20)  NOT NULL ,
	[LastName]           varchar(20)  NOT NULL ,
	[Password]           char(20)  NOT NULL ,
	[UserName]           varchar(20)  NOT NULL ,
	[StreetAddress]      varchar(50)  NULL ,
	[PostalCode]         int  NOT NULL ,
	CONSTRAINT [XPKUSER] PRIMARY KEY  CLUSTERED ([UserName] ASC),
	CONSTRAINT [XAK1USER] UNIQUE ([TagId]  ASC,[UserEmail]  ASC),
	CONSTRAINT [R_19] FOREIGN KEY ([PostalCode]) REFERENCES [ADDRESS]([PostalCode]),
	CONSTRAINT chk_UserEMail CHECK (UserEMail like '%@%.%'),
	CONSTRAINT chk_UserPassword CHECK (LEN([Password])>5),
    CONSTRAINT chk_UserPhoneNumber CHECK (LEN([PhoneNumber])>7)

)
go

CREATE TABLE [ATTENDEE_STATUS]
( 
	[Description]        varchar(30)  NULL ,
	[StatusId]           int  NOT NULL ,
	CONSTRAINT [XPKAPPLICANT] PRIMARY KEY  CLUSTERED ([StatusId] ASC)
)
go

CREATE TABLE [ATTENDEE]
( 
	[AppointmentId]      int  NOT NULL ,
	[PersonalNote]       varchar(200)  NULL ,
	[UserName]           varchar(20)  NOT NULL ,
	[TimeAttended]       datetime  NULL ,
	[StatusId]           int  NOT NULL ,
	CONSTRAINT [XPKATTENDEE] PRIMARY KEY  CLUSTERED ([AppointmentId] ASC,[UserName] ASC),
	CONSTRAINT [R_15] FOREIGN KEY ([AppointmentId]) REFERENCES [APPOINTMENT]([AppointmentId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_18] FOREIGN KEY ([UserName]) REFERENCES [USER]([UserName])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT [R_29] FOREIGN KEY ([StatusId]) REFERENCES [ATTENDEE_STATUS]([StatusId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go
