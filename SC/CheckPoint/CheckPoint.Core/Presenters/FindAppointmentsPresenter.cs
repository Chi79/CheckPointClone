using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.CacheInterfaces;
using CheckPointPresenters.Bases;
using CheckPointModel.DTOs;
using CheckPointCommon.Enums;
using CheckPointDataTables.Tables;


namespace CheckPointPresenters.Presenters
{
    public class FindAppointmentsPresenter : PresenterBase
    {
        private readonly IFindAppointmentsView _view;
        private readonly IFindAppointmentsModel _model;

        private AttendeeDTO _dTO;
        public FindAppointmentsPresenter(IFindAppointmentsView view,IFindAppointmentsModel model)
        {

            _view = view;
            _model = model;

        }




        private bool CheckRowIsSelected()
        {
            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() == noRowSelected)
            {

                return false;

            }
            else
            {

                return true;

            }
        }


        public override void Load()
        {

            FetchData();

            WireUpEvents();
        }

        private void WireUpEvents()
        {

            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.RowSelected += OnRowSelected;
            _view.FindCoursesButtonClicked += OnFindCoursesButtonClicked;
            _view.ApplyToAttendAppointmentButtonClicked += OnApplyToAttendAppointmentButtonClicked;

        }



        private void OnFindCoursesButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToFindCoursesView();

        }

 

        public override void FirstTimeInit()
        {

            ResetSessionState();

            ShowData();

        }

        private void ShowData()
        {

            _view.SetDataSource = _model.GetAllPublicAppointments();

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

        }

        private void ResetSessionState()
        {

            _model.ResetSessionState();

        }

        private void FetchData()
        {

            var appointments = _model.GetCachedAppointments();

        }


        private void OnRowSelected(object sender, EventArgs e)
        {

            SaveRowIndexToSession();

            GetSelectedAppointmentIdFromGrid();

        }

        private void SaveRowIndexToSession()
        {

            int rowSelected = _view.SelectedRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }


        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsSortedByPropertyAsc();

            _view.SetDataSource = apps;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }



        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsSortedByPropertyDesc();

            _view.SetDataSource = apps;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }


        private void GetSelectedAppointmentIdFromGrid()
        {

            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {

                SaveSelectedAppointmentIdToSession();

                _view.Message = _model.GetSessionAppointmentId().ToString();

            }
        }

        private void SaveSelectedAppointmentIdToSession()
        {

            int selectedAppointmentId = (int)_view.SelectedRowValueDataKey;

            _model.SetSessionAppointmentId(selectedAppointmentId);

        }
        private void OnApplyToAttendAppointmentButtonClicked(object sender, EventArgs e)
        {
            PrepareJobType();       

            CreateAttendee();
        }

        private void CreateAttendee()
        {
          

            CreateAttendeeDTOFromInput();

            bool validDTO = ValidateDTO();
            if(validDTO)
            {
                var attendee = ConvertDTOToAttendee();
                _model.PerformJob(attendee);
                CheckChangesSaved();
            }
            else
            {
                _view.Message = "Faild to apply to Appointment";
            }

        }

        private void CheckChangesSaved()
        {

            bool UpdateSuccessful = _model.UpdateDatabaseWithChanges();
            if (UpdateSuccessful)
            {

                _view.Message = _model.GetJobCompletedMessage();
                

            

            }
            else
            {
                _view.Message = "Failed to save changes!" + _model.GetUpdateErrorMessage();
            }

        }

        public ATTENDEE ConvertDTOToAttendee()
        {
            return _model.ConvertToAttendee(_dTO) as ATTENDEE;
        }

        public void PrepareJobType()
        {
            _model.PrepareCreateAttendee();
        }
        public void CreateAttendeeDTOFromInput()
        {
            SaveSelectedAppointmentIdToSession();

            _dTO = new AttendeeDTO
            {
                AppointmentId = (int)_model.GetSessionAppointmentId(),
                TagId = _model.GetLoggedInClientTagId(),
                StatusId = (int)AttendeeStatus.RequestedToAttend               
            };                            

        }

        private bool ValidateDTO()
        {

            bool attendeeDataIsValid = _dTO.IsValid(_dTO);
            if (attendeeDataIsValid)
            {

                return true;

            }
            else
            {

                return false;

            }

        }




    }
}
