using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class AppointmentSelectorPresenter : PresenterBase
    {
        private readonly IAppointmentSelectorView _view;
        private readonly IAppointmentSelectorModel _model;

        public AppointmentSelectorPresenter(IAppointmentSelectorView view, IAppointmentSelectorModel model)
        {
            _model = model;
            _view = view;
        }

        private void OnAddSelectedAppointmentToCourseButtonClicked(object sender, EventArgs e)
        {

            bool RowSelected = CheckRowIsSelected();

            if (RowSelected)
            {

                AddSelectedAppointmentToCourse();

                SetAppointmentAddedStatus();

                _view.RedirectToManageCourseView();

            }
            else
            {

                _view.Message = "No appointment has been selected!";

            }
        }

        private void AddSelectedAppointmentToCourse()
        {

            _model.AddSelectedAppointmentToCourse();


        }

        private void SetAppointmentAddedStatus()
        {

            _model.SetNewAppointmentAddedToCourseStatus();

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
 
            _view.AddSelectedAppointmentToCourseButtonClicked += OnAddSelectedAppointmentToCourseButtonClicked;

        }

        public override void FirstTimeInit()
        {

            CheckNavigationIsValid();

        }

        private void CheckNavigationIsValid()
        {

            bool NavigtionIsValid = (bool)_model.GetValidNavigationStatus();

            if(NavigtionIsValid)
            {

                ResetSessionState();

                ShowData();

            }
            else
            {

                _view.RedirectToAppointmentsView();

            }

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
