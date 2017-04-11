using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;


namespace CheckPointPresenters.Presenters
{
    public class HostHomePresenter : PresenterBase
    {

        private readonly IHostHomeView _view;
        private readonly IHostHomeModel _model;


        public HostHomePresenter(IHostHomeView hostHomeView, IHostHomeModel hostHomeModel)
        {

            _view = hostHomeView;
            _model = hostHomeModel;

        }

        private void OnAddSelectedAppointmentToCourseButtonClicked(object sender, EventArgs e)
        {

            bool RowSelected = CheckRowIsSelected();

            if(RowSelected)
            {

                _view.RedirectToAddSelectedAppointmenToCourseView();

            }
            else
            {

                _view.Message = "No appointment has been selected!";

            }  
        }

        private void OnViewCoursesButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesView();

        }

        private void OnCreateReportButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

        }

        private void OnManageAttendanceButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

        }

        private void OnManageAppointmentButtonClicked(object sender, EventArgs e)
        {

            bool RowSelected = CheckRowIsSelected();

            if (RowSelected)
            {

                _view.RedirectToManageAppointment();

            }
            else
            {

                _view.Message = "No appointment has been selected!";

            }
        }

        private void OnCreateAppointmentButtonClicked(object sender, EventArgs e)
        {

           _view.RedirectToCreateAppointment();

        }

        public override void Load()
        {

            FetchData();
 
            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.CreateAppointmentButtonClicked += OnCreateAppointmentButtonClicked;
            _view.ManageAppointmentButtonClicked += OnManageAppointmentButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;
            _view.ViewCoursesButtonClicked += OnViewCoursesButtonClicked;
            _view.AddSelectedAppointmentToCourseButtonClicked += OnAddSelectedAppointmentToCourseButtonClicked;

        }

        public override void FirstTimeInit()
        {
 
            _view.SetDataSource = _model.GetAllAppointmentsForClient();

            _view.SetDataSource2 = _model.GetEmptyList();

            _model.ResetSessionState();

            _view.BindData();

        }


        private void FetchData()
        {

            var appointments = _model.GetCachedAppointments();

        }

        private bool CheckRowIsSelected()
        {
            int unAssigned = -1;

            if (_model.GetSessionRowIndex() == unAssigned)
            {

                return false;

            }
            else
            {

                return true;

            }
        }

        private void OnRowSelected(object sender, EventArgs e)
        {

            int rowIndex = _view.SelectedRowIndex;
            _model.SetSessionRowIndex(rowIndex);

            GetSelectedAppointmentIdFromGrid();    

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

            int unAssigned = -1;

            if (_model.GetSessionRowIndex() != unAssigned)
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
    }
}
