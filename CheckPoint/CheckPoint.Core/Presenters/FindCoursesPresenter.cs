using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;
using CheckPointPresenters.Bases;

namespace CheckPointPresenters.Presenters
{
    public class FindCoursesPresenter : PresenterBase
    {

        private readonly IFindCoursesView _view;
        private readonly IFindCoursesModel _model;

        public FindCoursesPresenter(IFindCoursesView view, IFindCoursesModel model)
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

        public void WireUpEvents()
        {

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;

            _view.ApplyToAttendCourseButtonClicked += OnApplyToAttendCourseButtonClicked;
            _view.FindPublicAppointmentsButtonClicked += OnFindPublicAppointmentsButtonClicked;
            _view.ContinueButtonClicked += OnContinueButtonClicked;
        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {

            HideMessagePanel();

        }

        private void OnFindPublicAppointmentsButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToFindAppointmentsView();

        }

        private void OnApplyToAttendCourseButtonClicked(object sender, EventArgs e)
        {

            bool rowIsSelected = CheckRowIsSelected();
            if (rowIsSelected)
            {

                CheckUserHasValidTagId();


            }
            else
            {

                ShowMessagePanel();

                _view.Message = " <br /> <br />No course has been selected! <br /> <br /> Please click a row to select the course you wish to attend.<br />";

                ContinueButtonShow();

            }
        }

        public override void FirstTimeInit()
        {

            ResetSessionState();

            ShowData();

        }

        private void ShowData()
        {

            _view.SetDataSource = _model.GetAllPublicCourses();

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

        }

        private void ResetSessionState()
        {

            _model.ResetNewAppointmentAddedToCourseStatus();

            _model.ResetSessionState();

        }

        private void FetchData()
        {

            var courses = _model.GetPublicCachedCourses();

        }


        private void OnRowSelected(object sender, EventArgs e)
        {

            SaveRowIndexToSession();

            GetSelectedCourseIdFromGrid();

        }

        private void SaveRowIndexToSession()
        {

            int rowSelected = _view.SelectedRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var courses = _model.GetPublicCoursesSortedByPropertyAsc();

            _view.SetDataSource = courses;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedCourseIdFromGrid();

        }

        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var courses = _model.GetPublicCoursesSortedByPropertyDesc();

            _view.SetDataSource = courses;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedCourseIdFromGrid();

        }

        private void GetSelectedCourseIdFromGrid()
        {

            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {

                CheckCourseIdIsNotNull();

            }
        }

        private void CheckCourseIdIsNotNull()
        {
            var courseId = _view.SelectedRowValueDataKey;

            if (courseId != null)
            {

                StoreSelectedCourseIdToSession();

                _view.Message = _model.GetSessionCourseId().ToString();

            }
        }

        private void StoreSelectedCourseIdToSession()
        {

            var selectedCourseId = _view.SelectedRowValueDataKey;

            _model.SetSessionCourseId((int)selectedCourseId);

        }
        public void CheckUserHasValidTagId()
        {

            bool userHasValidTagId = _model.GetLoggedInClientTagId() != null;
            if (userHasValidTagId)
            {

                _view.RedirectToApplyToCourseView();

            }
            else
            {

                ShowMessagePanel();

                _view.Message = " <br /> <br /> User needs a valid tagId to attend appointments! <br /> <br /> You will receive an email once your account has been assigned with a tagId. <br />";
              
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

