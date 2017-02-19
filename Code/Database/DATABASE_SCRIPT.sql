
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
	[IsPrivate]          bit  NULL ,
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

CREATE TABLE [CLIENT_TYPE]
( 
	[ClientType]         int  NOT NULL ,
	[Description]        varchar(30)  NOT NULL ,
	CONSTRAINT [XPKCLIENT_TYPE] PRIMARY KEY  CLUSTERED ([ClientType] ASC)
)
go

CREATE TABLE [CLIENT]
( 
	[Email]              varchar(30)  NOT NULL ,
	[PhoneNumber]        int  NULL ,
	[FirstName]          varchar(20)  NOT NULL ,
	[LastName]           varchar(20)  NOT NULL ,
	[Password]           char(20)  NOT NULL ,
	[UserName]           varchar(20)  NOT NULL ,
	[Address]      varchar(50)  NULL ,
	[PostalCode]         int  NOT NULL ,
	[ClientType]         int  NOT NULL ,
	CONSTRAINT [XPKCLIENT] PRIMARY KEY  CLUSTERED ([UserName] ASC),
	CONSTRAINT [XAK1CLIENT] UNIQUE ([Email]  ASC),
	CONSTRAINT [R_19] FOREIGN KEY ([PostalCode]) REFERENCES [ADDRESS]([PostalCode]),
CONSTRAINT [R_31] FOREIGN KEY ([ClientType]) REFERENCES [CLIENT_TYPE]([ClientType]),
	CONSTRAINT chk_Email CHECK (Email like '%@%.%'),
	CONSTRAINT chk_Password CHECK (LEN([Password])>5),
    CONSTRAINT chk_PhoneNumber CHECK (LEN([PhoneNumber])>7)

)
go

CREATE TABLE [APPOINTMENT]
( 
	[AppointmentId]      int  NOT NULL  IDENTITY ( 1,1 ) ,
	[CourseId]           int  NOT NULL ,
	[StartTime]           Time  NULL ,
	[EndTime]             Time  NULL ,
	[PostalCode]         int  NOT NULL ,
	[AppointmentName]    varchar(40)  NOT NULL ,
	[Description]        varchar(200)  NULL ,
	[Address]      varchar(50)  NULL ,
	[Date]               date  NOT NULL ,
	[IsCancelled]        bit  NULL ,
	[UserName]           varchar(20)  NOT NULL ,
	[IsObligatory]       bit  NULL ,
	CONSTRAINT [XPKAPPOINTMENT] PRIMARY KEY  CLUSTERED ([AppointmentId] ASC),
	CONSTRAINT [R_1] FOREIGN KEY ([CourseId]) REFERENCES [COURSE]([CourseId]),
CONSTRAINT [R_3] FOREIGN KEY ([PostalCode]) REFERENCES [ADDRESS]([PostalCode]),
CONSTRAINT [R_32] FOREIGN KEY ([UserName]) REFERENCES [CLIENT]([UserName])

)
go

CREATE TABLE [READER_APPOINTMENT]
( 
	[ReaderId]           int  NOT NULL ,
	[AppointmentId]      int  NOT NULL ,
	CONSTRAINT [XPKREADER_APPOINTMENT] PRIMARY KEY  CLUSTERED ([ReaderId] ASC,[AppointmentId] ASC),
	CONSTRAINT [R_21] FOREIGN KEY ([ReaderId]) REFERENCES [READER]([ReaderId]),
CONSTRAINT [R_22] FOREIGN KEY ([AppointmentId]) REFERENCES [APPOINTMENT]([AppointmentId])

)
go

CREATE TABLE [ATTENDEE_STATUS]
( 
	[Description]        varchar(30)  NULL ,
	[StatusId]           int  NOT NULL ,
	CONSTRAINT [XPKAPPLICANT] PRIMARY KEY  CLUSTERED ([StatusId] ASC)
)
go

CREATE TABLE [CLIENT_TAG]
( 
	[TagId]              varchar(30)  NOT NULL ,
	[UserName]           varchar(20)  NOT NULL ,
	CONSTRAINT [XPKCLIENT_TAG] PRIMARY KEY  CLUSTERED ([TagId] ASC),
	CONSTRAINT [R_36] FOREIGN KEY ([UserName]) REFERENCES [CLIENT]([UserName]),
CONSTRAINT [R_38] FOREIGN KEY ([UserName]) REFERENCES [CLIENT]([UserName])

)
go

CREATE TABLE [ATTENDEE]
( 
	[AppointmentId]      int  NOT NULL ,
	[PersonalNote]       varchar(200)  NULL ,
	[TimeAttended]       datetime  NULL ,
	[StatusId]           int  NOT NULL ,
	[TagId]              varchar(30)  NOT NULL ,
	CONSTRAINT [XPKATTENDEE] PRIMARY KEY  CLUSTERED ([AppointmentId] ASC,[TagId] ASC),
	CONSTRAINT [R_15] FOREIGN KEY ([AppointmentId]) REFERENCES [APPOINTMENT]([AppointmentId]),
CONSTRAINT [R_29] FOREIGN KEY ([StatusId]) REFERENCES [ATTENDEE_STATUS]([StatusId]),
CONSTRAINT [R_34] FOREIGN KEY ([TagId]) REFERENCES [CLIENT_TAG]([TagId])

)
go
INSERT INTO CLIENT_TYPE
VALUES(0,'User'),(1,'Host')

INSERT INTO ATTENDEE_STATUS
     VALUES
	       ('Has requested to attend',0),
		   ('Is an attende not obligatory',1),
		   ('Is an attende obligatory',2),           
		   ('Has attended not obligatory',3),
		   ('Has attended Obligatory',4),
		   ('Is invited to appointment',5)
		  
