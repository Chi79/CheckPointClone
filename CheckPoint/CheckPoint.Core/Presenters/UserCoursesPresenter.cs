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
    public class UserCoursesPresenter : PresenterBase
    {

        private readonly IUserCoursesView _view;
        private readonly IUserCoursesModel _model;

        public int OnViewCoursesButtonClicked { get; private set; }

        public UserCoursesPresenter(IUserCoursesView view, IUserCoursesModel model)
        {

            _view = view;
            _model = model;

        }

        public override void FirstTimeInit()
        {
            ResetSessionState();

            ShowData();
        }

        private void ShowData()
        {          

            _view.SetDataSource = _model.GetAllCoursesClientIsApprovedToAttend();

            _view.SetDataSource2 = _model.GetEmptyCourseList();

            _view.BindData();

        }
        public override void Load()
        {

            WireUpEvents();
        }


        private void ResetSessionState()
        {

            _model.ResetSessionState();

        }

        private void WireUpEvents()
        {

            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.RowSelected += OnRowSelected;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;
            _view.FindAppointmentsButtonClicked += OnFindAppointmentsButtonClicked;
            _view.FindCoursesButtonClicked += OnFindCoursesButtonClicked;
            _view.ViewAppointmentsButtonClicked += OnViewAppointmentsButtonClicked;

        }

        private void OnViewAppointmentsButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToViewAppointments();
        }

        private void OnFindCoursesButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToFindCoursesView();
        }

        private void OnFindAppointmentsButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToFindAppointmentsView();
        }

        private void OnManageAttendanceButtonClicked(object sender, EventArgs e)
        {
            //todo
        }

        private void OnRowSelected(object sender, EventArgs e)
        {
            SaveRowIndexToSession();

            GetSelectedCourseIdFromGrid();
        }

        private void GetSelectedCourseIdFromGrid()
        {
            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {
                SaveSelectedCourseIdToSession();

            }
        }

        private void SaveSelectedCourseIdToSession()
        {

            int selectedCourseId = (int)_view.SelectedRowValueDataKey;

            _model.SetSessionCourseId(selectedCourseId);

        }

        private void SaveRowIndexToSession()
        {

            int rowSelected = _view.SelectedRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }

        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
