using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointCommon.Structs;

namespace CheckPointPresenters.Presenters
{
    public class CreateAppointmentPresenter : PresenterBase
    {
        private readonly ICreateAppointmentView _view;
        private readonly ICreateAppointmentModel<APPOINTMENT, AppointmentDTO> _model;
        private readonly IUnitOfWork _uOW;

        private AppointmentDTO _appointmentDTO = new AppointmentDTO();
        private APPOINTMENT _newAppointment;

        private string _errorMessage = null;
        private List<string> _validationErrorMessage;

        public CreateAppointmentPresenter(ICreateAppointmentView createAppointmentView, 
                                          ICreateAppointmentModel<APPOINTMENT, AppointmentDTO> createAppointmentModel,
                                          IUnitOfWork unitOfWork)
        {

            _view = createAppointmentView;
            _model = createAppointmentModel;
            _uOW = unitOfWork;

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
            _appointmentDTO.FillPropertyList(_appointmentDTO);

            bool appointmentDataIsValid = AppointmentToCreateIsValid();
            if(appointmentDataIsValid)
            {
                _newAppointment = _model.ConvertAppointmentDTOToAppointment(_appointmentDTO);
                SaveAppointmentToDatabase(_newAppointment);
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
        private bool AppointmentToCreateIsValid()
        {
            bool AppointmentFieldsAreValid = _appointmentDTO.IsValid(_appointmentDTO);
            if(AppointmentFieldsAreValid)
            {
                _newAppointment = _model.ConvertAppointmentDTOToAppointment(_appointmentDTO);
                return true;
            }
            else
            {
                _validationErrorMessage = _appointmentDTO.GetBrokenBusinessRules().ToList();
                DisplayValidationMessage();
                return false;
            }
        }
        private void DisplayValidationMessage()
        {
            _view.Message = string.Empty;

            foreach (string message in _validationErrorMessage)
            {
                _view.Message += message;
            }
        }
        private void SaveAppointmentToDatabase(APPOINTMENT newAppointment)
        {
            _uOW.APPOINTMENTs.Add(newAppointment);

            bool saveCompleted = AttemptSaveToDb();
            if(saveCompleted)
            {
                _view.Message = "New Appointment Saved Succesfully!";
                SetButtonVisiblity();
            }
            else
            {
                _view.Message = "Failed to Save Appointment" + _errorMessage;
            }
        }

        private bool AttemptSaveToDb()
        {
            SaveResult saveResult = _uOW.Complete();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _errorMessage = saveResult.ErrorMessage;
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
