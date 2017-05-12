using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.Enums;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.Structs;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Services
{
    public class JobServiceBase
    {
        public virtual DbAction Jobtype { get; set; }
        public virtual string ItemName { get; set; }
        public virtual string ConfirmationMessage { get; }
        public virtual string CompletedMessage { get; }
        public virtual int AppointmentId { get; set; }
        public virtual int? CourseId { get; set; }



        public virtual void PerformTask(object obj)
        {
            //not implemented
        }

        public virtual void PerformTask(IEnumerable<object> obj)
        {
            //not implemented
        }
        public virtual SaveResult SaveChanges()
        {
            SaveResult result = new SaveResult { ErrorMessage = "", Result = 0 };
            return result;
        }
    }
    public class CreateAppointmentJob : JobServiceBase
    {
        private IHandleAppointments _handler;

        public CreateAppointmentJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.CreateAppointment; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to add this appointment!  <br /> <br />  Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "New Appointment Added Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {
            _handler.Create(appointment);
        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }

    public class ChangeAppointmentCourseIdJob : JobServiceBase
    {

        private IHandleAppointments _handler;
        public ChangeAppointmentCourseIdJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.ChangeAppointmentCourseId; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to add this appointment to the course! <br /> <br /> Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Appointment Added Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {
            var appointmentToUpdate = _handler.GetAppointmentById(AppointmentId) as APPOINTMENT;
            appointmentToUpdate.CourseId = this.CourseId;
        }

        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }


    public class AddAppointmentToCourseJob : JobServiceBase
    {
        private IHandleAppointments _handler;

        public AddAppointmentToCourseJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.AddNewAppointmentToCourse; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to add this appointment to the course! <br /> <br /> Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "New Appointment Added To Course Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {

            var appointmentToCreate = appointment as APPOINTMENT;
            appointmentToCreate.CourseId = this.CourseId;

            _handler.Create(appointment);

        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }

    public class DeleteAppointmentJob : JobServiceBase
    {

        private IHandleAppointments _handler;
        public DeleteAppointmentJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.DeleteAppointment; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "<br />You are about to delete the appointment with Id number: " + AppointmentId + "! <br /> <br />  Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Appointment Deleted Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {
            var appointmentToDelete = _handler.GetAppointmentById(AppointmentId);
            _handler.Delete(appointmentToDelete);
        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }
    public class UpdateAppointmentJob : JobServiceBase
    {

        private IHandleAppointments _handler;
        public UpdateAppointmentJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.UpdateAppointment; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "<br />You are about to update this appointment! <br /> <br /> Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Appointment Updated Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {
            var appointmentToUpdate = _handler.GetAppointmentById(AppointmentId) as APPOINTMENT;
            var newAppointment = appointment as APPOINTMENT;

            appointmentToUpdate.AppointmentName = newAppointment.AppointmentName;
            appointmentToUpdate.UserName = newAppointment.UserName;
            appointmentToUpdate.Description = newAppointment.Description;
            appointmentToUpdate.Date = newAppointment.Date;
            appointmentToUpdate.StartTime = newAppointment.StartTime;
            appointmentToUpdate.EndTime = newAppointment.EndTime;
            appointmentToUpdate.Address = newAppointment.Address;
            appointmentToUpdate.PostalCode = newAppointment.PostalCode;
            appointmentToUpdate.IsObligatory = newAppointment.IsObligatory;
            appointmentToUpdate.IsCancelled = newAppointment.IsCancelled;

        }

        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }
    public class CreateCourseJob : JobServiceBase
    {
        private IHandleCourses _handler;

        public CreateCourseJob(IHandleCourses handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.CreateCourse; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "<br />You are about to add this course! <br /> <br /> Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "New Course Added Succesfully!"; }
        }

        public override void PerformTask(object course)
        {
            _handler.Create(course);
        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }

    public class DeleteCourseJob : JobServiceBase
    {

        private IHandleCourses _handler;
        public DeleteCourseJob(IHandleCourses handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.DeleteCourse; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "<br />You are about to delete the course with Id number: " + CourseId + "! <br /> <br /> All associated appointments will be removed! <br /> <br />  Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Course Deleted Succesfully!"; }
        }

        public override void PerformTask(object course)
        {

            var courseToDelete = _handler.GetCourseById((int)CourseId);
            _handler.Delete(courseToDelete);

        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }

    }
    public class UpdateCourseJob : JobServiceBase
    {

        private IHandleCourses _handler;
        public UpdateCourseJob(IHandleCourses handler)
        {
            _handler = handler;
        }
        public override DbAction Jobtype
        {
            get { return DbAction.UpdateCourse; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "<br />You are about to update this course! <br /> <br /> Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Course Updated Succesfully!"; }
        }

        public override void PerformTask(object course)
        {
            var courseToUpdate = _handler.GetCourseById((int)CourseId) as COURSE;
            var newCourse = course as COURSE;

            courseToUpdate.Name = newCourse.Name;
            courseToUpdate.UserName = newCourse.UserName;
            courseToUpdate.Description = newCourse.Description;
            courseToUpdate.IsPrivate = newCourse.IsPrivate;
            courseToUpdate.IsObligatory = newCourse.IsObligatory;
        }

        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }
    public class CreateAttendeeJob : JobServiceBase
    {
        private IHandleAttendee _handler;

        public CreateAttendeeJob(IHandleAttendee handler)
        {
            _handler = handler;
        }

        public override DbAction Jobtype
        {
            get { return DbAction.CreateAttendee; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "<br /><br />You have requested to become an attendee for this appointment! <br /> <br /> Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "<br />Thank you! Your request has now been sent..<br /><br /> Once your request is approved, the appointment will appear in your 'My Appointments' page.<br/>"; }
        }

        public override void PerformTask(object attendee)
        {
            _handler.Create(attendee);
        }

        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }

    }
    public class CreateMultipleAttendeesJob : JobServiceBase
    {
        private IHandleAttendee _handler;

        public CreateMultipleAttendeesJob(IHandleAttendee handler)
        {
            _handler = handler;
        }

        public override DbAction Jobtype
        {
            get { return DbAction.CreateMultipleAttendees; }
            set { Jobtype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "<br /><br />You have requested to become an attendee to this course! <br /> <br /> Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "<br />Thank you! Your request has now been sent..<br /><br /> Once your request has been approved, the course will appear in your 'My Course' page.<br/>"; }
        }

        public override void PerformTask(IEnumerable<object> attendees)
        {
            var attendeesToBeCreated = new List<ATTENDEE>();
                       
           foreach(ATTENDEE attendee in attendees)
            {
               if(!CheckIfAttendeeExists(attendee))
                {
                    attendeesToBeCreated.Add(attendee);
                }
            }            
            _handler.CreateRange<ATTENDEE>(attendeesToBeCreated as IEnumerable<ATTENDEE>);
        }

        private bool CheckIfAttendeeExists(ATTENDEE attendee)
        {
            return _handler.CheckIfAttendeeExists(attendee);
        }
 

        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }

    }
}
    



