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
        public virtual DbAction Actiontype { get; set; }
        public virtual string ItemName { get; set; }
        public virtual string ConfirmationMessage { get; }
        public virtual string CompletedMessage { get; }
        public virtual int ItemId { get; set; }
        public virtual int CourseId { get; set; }



        public virtual void PerformTask(object appointment)
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
        public override DbAction Actiontype
        {
            get { return DbAction.CreateAppointment; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to add this appointment! Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get  { return "New Appointment Added Succesfully!"; }
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

    public class AddExistingAppointmentToCourseJob : JobServiceBase
    {

        private IHandleAppointments _handler;
        public AddExistingAppointmentToCourseJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Actiontype
        {
            get { return DbAction.AddExistingAppointmentToCourse; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to add this appointment to the course! Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Appointment Added Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {
            var appointmentToUpdate = _handler.GetAppointmentById(ItemId) as APPOINTMENT;
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
        public override DbAction Actiontype
        {
            get { return DbAction.AddNewAppointmentToCourse; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to add this appointment to the course! Do you wish to continue?"; }
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
        public override DbAction Actiontype
        {
            get { return DbAction.DeleteAppointment; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to delete the appointment with Id number: " + ItemId +"!  Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Appointment Deleted Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {
            var appointmentToDelete = _handler.GetAppointmentById(ItemId);
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
        public override DbAction Actiontype
        {
            get { return DbAction.UpdateAppointment; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to update this appointment! Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Appointment Updated Succesfully!"; }
        }

        public override void PerformTask(object appointment)
        {
            var appointmentToUpdate = _handler.GetAppointmentById(ItemId) as APPOINTMENT;
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
        public override DbAction Actiontype
        {
            get { return DbAction.CreateCourse; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to add this course! Do you wish to continue?"; }
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
        public override DbAction Actiontype
        {
            get { return DbAction.DeleteCourse; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to delete the course with Id number: " + ItemId + "!  Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Course Deleted Succesfully!"; }
        }

        public override void PerformTask(object course)
        {
            var courseToDelete = _handler.GetCourseByName(ItemName);
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
        public override DbAction Actiontype
        {
            get { return DbAction.UpdateCourse; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to update this course! Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "Course Updated Succesfully!"; }
        }

        public override void PerformTask(object course)
        {
            var courseToUpdate = _handler.GetCourseById(ItemId) as COURSE;
            var newCourse = course as COURSE;

            courseToUpdate.Name = newCourse.Name;
            courseToUpdate.UserName = newCourse.UserName;
            courseToUpdate.Description = newCourse.Description;
            courseToUpdate.IsPrivate = newCourse.IsPrivate;
        }

        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChanges();
            return result;
        }
    }
}

