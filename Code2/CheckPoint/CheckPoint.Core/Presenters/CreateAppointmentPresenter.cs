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
using CheckPointModel.Entities;
using CheckPointCommon.Structs;

namespace CheckPointPresenters.Presenters
{
    public class CreateAppointmentPresenter : PresenterBase
    {
        private readonly ICreateAppointmentView _createAppointmentView;
        private readonly ICreateAppointmentModel<APPOINTMENT, AppointmentModel> _createAppointmentModel;
        private readonly IUnitOfWork _unitOfWork;

        private AppointmentModel _appointmentModel = new AppointmentModel();
        private APPOINTMENT _newAppointment;

        private string _errorMessage = null;
        private List<string> _validationErrorMessage;

        public CreateAppointmentPresenter(ICreateAppointmentView createAppointmentView, 
                                          ICreateAppointmentModel<APPOINTMENT, AppointmentModel> createAppointmentModel,
                                          IUnitOfWork unitOfWork)
        {

            _createAppointmentView = createAppointmentView;
            _createAppointmentModel = createAppointmentModel;
            _unitOfWork = unitOfWork;

            _createAppointmentView.CreateNewAppointment += OnCreateNewAppointmentButtonCLicked;
        }

        private void OnCreateNewAppointmentButtonCLicked(object sender, EventArgs e)
        {
            CreateAppointmentModelFromInput();
            _appointmentModel.FillPropertyList(_appointmentModel);

            bool appointmentDataIsValid = AppointmentToCreateIsValid();
            if(appointmentDataIsValid)
            {
                _newAppointment = _createAppointmentModel.ConvertAppointmentModelToAppointment(_appointmentModel);
                SaveAppointmentToDatabase(_newAppointment);
            }
        }
        private void CreateAppointmentModelFromInput()
        {
            _appointmentModel.CourseId = Convert.ToInt32(_createAppointmentView.CourseId);
            _appointmentModel.AppointmentName = _createAppointmentView.AppointmentName;
            _appointmentModel.Description = _createAppointmentView.Description;
            _appointmentModel.Date = _createAppointmentView.Date;
            _appointmentModel.StartTime = _createAppointmentView.StartTime;
            _appointmentModel.EndTime = _createAppointmentView.EndTime;
            _appointmentModel.UserName = _createAppointmentView.UserName;
            _appointmentModel.Address = _createAppointmentView.Address;
            _appointmentModel.PostalCode = _createAppointmentView.PostalCode;
            _appointmentModel.IsObligatory = Convert.ToBoolean(_createAppointmentView.IsObligatory);
            _appointmentModel.IsCancelled = Convert.ToBoolean(_createAppointmentView.IsCancelled);
        }
        private bool AppointmentToCreateIsValid()
        {
            bool AppointmentFieldsAreValid = _appointmentModel.IsValid(_appointmentModel);
            if(AppointmentFieldsAreValid)
            {
                _newAppointment = _createAppointmentModel.ConvertAppointmentModelToAppointment(_appointmentModel);
                return true;
            }
            else
            {
                _validationErrorMessage = _appointmentModel.GetBrokenBusinessRules().ToList();
                DisplayValidationMessage();
                return false;
            }
        }
        private void DisplayValidationMessage()
        {
            _createAppointmentView.Message = string.Empty;

            foreach (string message in _validationErrorMessage)
            {
                _createAppointmentView.Message += message;
            }
        }
        private void SaveAppointmentToDatabase(APPOINTMENT newAppointment)
        {
            _unitOfWork.APPOINTMENTs.Add(newAppointment);
            bool saveCompleted = AttemptSaveToDb();
            if(saveCompleted)
            {
                _createAppointmentView.Message = "New Appointment Saved Succesfully!";
            }
            else
            {
                _createAppointmentView.Message = "Failed to Save Appointment" + _errorMessage;
            }
        }
        private bool AttemptSaveToDb()
        {
            SaveResult saveResult = _unitOfWork.myComplete();
            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _errorMessage = saveResult.ErrorMessage;
                return false;
            }
            return true;
        }
    }
}
