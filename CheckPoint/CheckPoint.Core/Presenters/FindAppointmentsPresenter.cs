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
            _view.ContinueButtonClicked += OnContinueButtonClicked;
        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {

            HideMessagePanel();

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

            bool rowIsSelected = CheckRowIsSelected();
            if(rowIsSelected)
            {

                CheckUserHasValidTagId();
                

            }
            else
            {

                ShowMessagePanel();

                _view.Message = " <br /> <br />No appointment has been selected! <br /> <br /> Please click a row to select the appointment you wish to attend <br />";

                ContinueButtonShow();

            }

        }

        public void CheckUserHasValidTagId()
        {

            bool userHasValidTagId = _model.GetLoggedInClientTagId() != null;
            if(userHasValidTagId)
            {

                _view.RedirectToApplyToAppointmentView();

            }
            else
            {

                ShowMessagePanel();

                _view.Message = " <br /> <br />User needs a valid tagId to attend appointments! <br /> <br />You will receive an email once your account has been assigned with a tagId. <br />";

                ContinueButtonShow();

            }

        }

        private void ShowMessagePanel()
        {

            _view.MessagePanelVisible = true;

        }

        private void HideMessagePanel()
        {

            _view.MessagePanelVisible = false;

        }

        private void ContinueButtonShow()
        {

            _view.ContinueButtonVisible = true;

        }

        private void ContinueButtonHide()
        {

            _view.ContinueButtonVisible = false;

        }

    }
}
