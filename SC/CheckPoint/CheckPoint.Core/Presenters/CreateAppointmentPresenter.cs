using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointCommon.Structs;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class CreateAppointmentPresenter : PresenterBase
    {
        private readonly ICreateAppointmentView _view;
        private readonly ICreateAppointmentModel<APPOINTMENT, AppointmentDTO> _model;
        private readonly IHandleAppointments<APPOINTMENT, SaveResult> _appointmentHandler;

        private AppointmentDTO _appointmentDTO = new AppointmentDTO();
        private APPOINTMENT _validatedAppointment;

        public CreateAppointmentPresenter(ICreateAppointmentView createAppointmentView, 
                                          ICreateAppointmentModel<APPOINTMENT, AppointmentDTO> createAppointmentModel,
                                           IHandleAppointments<APPOINTMENT, SaveResult> appointmentHandler)
        {

            _view = createAppointmentView;
            _model = createAppointmentModel;
            _appointmentHandler = appointmentHandler;

            _view.CreateNewAppointment += OnCreateNewAppointmentButtonCLicked;
            _view.Continue += OnContinueEvent;
        }

        private void OnContinueEvent(object sender, EventArgs e)
        {
            _view.RedirectAfterClickEvent();
        }

        private void OnCreateNewAppointmentButtonCLicked(object sender, EventArgs e)
        {
            CreateAppointmentDTOFromInput();

            bool appointmentDataIsValid = ValidateDTO();
            if(appointmentDataIsValid)
            {
                SaveAppointmentToDatabase(_validatedAppointment);
            }
        }
        private void CreateAppointmentDTOFromInput()
        {
            _appointmentDTO.CourseId = _view.CourseId;
            _appointmentDTO.AppointmentName = _view.AppointmentName;
            _appointmentDTO.Description = _view.Description;
            _appointmentDTO.Date = _view.Date;
            _appointmentDTO.StartTime = _view.StartTime;
            _appointmentDTO.EndTime = _view.EndTime;
            _appointmentDTO.UserName = _view.UserName;
            _appointmentDTO.Address = _view.Address;
            _appointmentDTO.PostalCode = _view.PostalCode;
            _appointmentDTO.IsObligatory = Convert.ToBoolean(_view.IsObligatory);
            _appointmentDTO.IsCancelled = Convert.ToBoolean(_view.IsCancelled);
        }
        private bool ValidateDTO()
        {

            bool AppointmentFieldsAreValid = _appointmentDTO.IsValid(_appointmentDTO);
            if(AppointmentFieldsAreValid)
            {
                _validatedAppointment = _model.ConvertAppointmentDTOToAppointment(_appointmentDTO);
                return true;
            }
            else
            {
                List<string >validationMessages = _appointmentDTO.GetBrokenBusinessRules().ToList();
                DisplayValidationMessage(validationMessages);
                return false;
            }
        }
        private void DisplayValidationMessage(List<string> validationMessages)
        {
            _view.Message = string.Empty;

            foreach (string message in validationMessages)
            {
                _view.Message += message;
            }
        }
        private void SaveAppointmentToDatabase(APPOINTMENT validatedAppointment)
        {
            _appointmentHandler.Create(validatedAppointment);

            bool saveCompleted = AttemptSaveChangesToDb();
            if(saveCompleted)
            {
                _view.Message = "New Appointment Saved Succesfully!";
                SetButtonVisiblity();
            }
        }

        private bool AttemptSaveChangesToDb()
        {
            SaveResult saveResult = _appointmentHandler.SaveChangesToAppointments();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _view.Message = "Failed to Save Appointment " + saveResult.ErrorMessage; 
                return false;
            }
            return true;
        }

        private void SetButtonVisiblity()
        {
            _view.CreateButtonVisible = false;
            _view.ContinueButtonVisible = true;
        }
    }
}
