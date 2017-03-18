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
        public virtual string AppointmentName { get; set; }
        public virtual string ConfirmationMessage { get; }
        public virtual string CompletedMessage { get; }
        public virtual void PerformTask(APPOINTMENT appointment)
        {
            //not implemented
        }
        public virtual SaveResult SaveChanges()
        {
            SaveResult result = new SaveResult { ErrorMessage = "", Result = 0 };
            return result;
        }
    }
    public class CreateJob : JobServiceBase
    {
        private IHandleAppointments _handler;

        public CreateJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Actiontype
        {
            get { return DbAction.Create; }
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
        public override void PerformTask(APPOINTMENT appointment)
        {
            _handler.Create(appointment);
        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChangesToAppointments();
            return result;
        }
    }
    public class DeleteJob : JobServiceBase
    {

        private IHandleAppointments _handler;
        public DeleteJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Actiontype
        {
            get { return DbAction.Delete; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to delete the appointment: " + AppointmentName +"!  Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "New Appointment Deleted Succesfully!"; }
        }
        public override void PerformTask(APPOINTMENT appointment)
        {
            var appointmentToDelete =_handler.GetAppointmentByName(AppointmentName);
            _handler.Delete(appointmentToDelete);
        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChangesToAppointments();
            return result;
        }
    }
    public class UpdateJob : JobServiceBase
    {

        private IHandleAppointments _handler;
        public UpdateJob(IHandleAppointments handler)
        {
            _handler = handler;
        }
        public override DbAction Actiontype
        {
            get { return DbAction.Update; }
            set { Actiontype = value; }
        }
        public override string ConfirmationMessage
        {
            get { return "You are about to update this appointment! Do you wish to continue?"; }
        }
        public override string CompletedMessage
        {
            get { return "New Appointment Updated Succesfully!"; }
        }
        public override void PerformTask(APPOINTMENT appointment)
        {
            var appointmentToUpdate = _handler.GetAppointmentByName(AppointmentName) as APPOINTMENT;

            appointmentToUpdate.CourseId = appointment.CourseId;
            appointmentToUpdate.AppointmentName = appointment.AppointmentName;
            appointmentToUpdate.UserName = appointment.UserName;
            appointmentToUpdate.Description = appointment.Description;
            appointmentToUpdate.Date = appointment.Date;
            appointmentToUpdate.StartTime = appointment.StartTime;
            appointmentToUpdate.EndTime = appointment.EndTime;
            appointmentToUpdate.Address = appointment.Address;
            appointmentToUpdate.PostalCode = appointment.PostalCode;
            appointmentToUpdate.IsObligatory = appointment.IsObligatory;
            appointmentToUpdate.IsCancelled = appointment.IsCancelled;
        }
        public override SaveResult SaveChanges()
        {

            SaveResult result = (SaveResult)_handler.SaveChangesToAppointments();
            return result;
        }
    }
}
