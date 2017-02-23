CREATE TRIGGER LimitNumberOfsimultaneouslyAppointmentsPrHost ON [APPOINTMENT]
INSTEAD OF INSERT
AS
           
		DECLARE @AppointmentName varchar(40)
	    DECLARE @Date date
        DECLARE @StartTime time(7)
        DECLARE @EndTime time(7)
		DECLARE	@Description varchar(200)
		DECLARE	@UserName varchar(20)
        DECLARE @PostalCode int
	    DECLARE @Address varchar(50)
        DECLARE @CourseId int                                      
        DECLARE @IsCancelled bit 
		DECLARE @IsObligatory bit           

		SELECT @AppointmentName = AppointmentName FROM inserted
	    SELECT @Date = Date FROM inserted
        SELECT @StartTime = StartTime FROM inserted
        SELECT @EndTime = EndTime FROM inserted
		SELECT @Description = Description FROM inserted
		SELECT @UserName = UserName FROM inserted
        SELECT @PostalCode = PostalCode FROM inserted
	    SELECT @Address = Address FROM inserted
        SELECT @CourseId = CourseId FROM inserted                               
        SELECT @IsCancelled = IsCancelled FROM inserted
		SELECT @IsObligatory= IsObligatory FROM inserted
			
				
	    if(
			(SELECT COUNT(UserName)
			FROM APPOINTMENT
			where (Date = @Date and  (StartTime <= @StartTime and @StartTime < EndTime)))
			<10
		  )
		  INSERT INTO APPOINTMENT
		  VALUES
		  (
		 @CourseId  ,
		 @StartTime ,
         @EndTime ,
		 @PostalCode ,
		 @AppointmentName,
		 @Description,
		 @Address ,  
	     @Date,
         @IsCancelled,		
		 @UserName ,
		 @IsObligatory         	                                               
	      )
		  else 
		  RAISERROR('Too many appointments scheduled in the same timespan',16,1)

		
		
