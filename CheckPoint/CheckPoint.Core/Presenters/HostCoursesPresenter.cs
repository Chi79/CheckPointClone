﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class HostCoursesPresenter : PresenterBase
    {
        private readonly IHostCoursesView _view;
        private readonly IHostCoursesModel _model;
        private readonly IShowCourses _displayService;
        private readonly ISessionService _sessionService;


        public HostCoursesPresenter(IHostCoursesView coursesView, IHostCoursesModel coursesModel, 
                                    IShowCourses displayService, ISessionService sessionService)
        {
            _view = coursesView;
            _model = coursesModel;
            _displayService = displayService;
            _sessionService = sessionService;

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.ViewAppointmentsButtonClicked += OnViewAppointmentsButtonClicked;
            _view.ManageCourseButtonClicked += OnManageCourseButtonClicked;
            _view.CreateCourseButtonClicked += OnCreateCourseButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;

        }


        private void OnViewAppointmentsButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToAppointmentsView();
        }

        private void OnCreateReportButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        private void OnManageAttendanceButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        private void OnManageCourseButtonClicked(object sender, EventArgs e)
        {

            int noAppointmentSelected = -1;
            if (_sessionService.SessionCourseId == noAppointmentSelected)
            {
                _view.Message = "No course has been selected!";
            }
            else
            {
                _view.RedirectToManageCourse();
            }

        }

        private void OnCreateCourseButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCreateCourse();
        }

        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            _view.SetDataSource = _displayService.GetAllCoursesFor<COURSE>(_sessionService.LoggedInClient);
            _view.SetDataSource2 = _displayService.GetEmptyList<COURSE>();
            _sessionService.SessionRowIndex = -1;
            _sessionService.SessionCourseId = -1;
            _view.BindData();
        }
        private void FetchData()
        {
            var courses = _displayService.GetCoursesCached<COURSE>();

        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _sessionService.SessionRowIndex = _view.SelectedRowIndex;
            GetSelectedCourseIdFromGrid();
        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var courses = _displayService.GetCoursesSortedByPropertyAscending<object>(_sessionService.ColumnName);
            _view.SetDataSource = courses;
            _view.SetDataSource2 = _displayService.GetEmptyList<COURSE>();
            _view.BindData();

            GetSelectedCourseIdFromGrid();
        }
        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var courses = _displayService.GetCoursesSortedByPropertyDescending<object>(_sessionService.ColumnName);
            _view.SetDataSource = courses;
            _view.SetDataSource2 = _displayService.GetEmptyList<COURSE>();
            _view.BindData();

            GetSelectedCourseIdFromGrid();
        }
        private void GetSelectedCourseIdFromGrid()
        {

            int noIndexIsSelected = -1;
            if (_sessionService.SessionRowIndex != noIndexIsSelected)
            {
                CheckCourseIdIsNotNull();
            }
        }
        private void CheckCourseIdIsNotNull()
        {
            var courseId = _view.SelectedRowValueDataKey;
            if (courseId != null)
            {
                var selectedCourseId = _view.SelectedRowValueDataKey;
                _sessionService.SessionCourseId = (int)selectedCourseId;
                _view.Message = selectedCourseId.ToString();
            }
        }
    }
}
