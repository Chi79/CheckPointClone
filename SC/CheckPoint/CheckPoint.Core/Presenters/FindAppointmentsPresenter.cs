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
    public class FindAppointmentsPresenter : PresenterBase
    {
        private readonly IFindAppointmentsView _view;
        private readonly IFindAppointmentsModel _model;

        public FindAppointmentsPresenter(IFindAppointmentsView view, IFindAppointmentsModel model)
        {

            _view = view;
            _model = model;

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
            _view.FindCoursesButtonClicked += OnFindCoursesButtonClicked;
            _view.ApplyToAttendAppointmentButtonClicked += OnApplyToAttendAppointmentButtonClicked;

        }

        private void OnApplyToAttendAppointmentButtonClicked(object sender, EventArgs e)
        {
           


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
    }
}
