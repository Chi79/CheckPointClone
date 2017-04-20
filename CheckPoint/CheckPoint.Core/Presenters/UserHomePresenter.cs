using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;


namespace CheckPointPresenters.Presenters
{
    public class UserHomePresenter : PresenterBase
    {
        private readonly IUserHomeModel _model;
        private readonly IUserHomeView _view;

        public UserHomePresenter(IUserHomeModel userHomeModel, IUserHomeView userHomeView)
        {

            _view = userHomeView;
            _model = userHomeModel;

        }


        private void OnManageAttendanceButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

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
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;

            _view.FindAppointmentsButtonClicked += OnFindAppointmentsButtonClicked;
            _view.FindCoursesButtonClicked += OnFindCoursesButtonClicked;
            _view.ViewCoursesButtonClicked += OnViewCoursesButtonClicked;

        }

        private void OnViewCoursesButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToViewCourses();

        }

        private void OnFindCoursesButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToFindCoursesView();

        }

        private void OnFindAppointmentsButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToFindAppointmentsView();

        }

        public override void FirstTimeInit()
        {

            ResetSessionState();
            ShowData();

        }

        private void ShowData()
        {

            _view.SetDataSource = _model.GetAllAppointmentsForClient();

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
    }
}
