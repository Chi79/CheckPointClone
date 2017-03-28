﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class UserHomePresenter : PresenterBase
    {
        private readonly IUserHomeModel _model;
        private readonly IUserHomeView _view;
        private readonly IShowAppointments _displayService;

        public UserHomePresenter(IUserHomeModel userHomeModel, IUserHomeView userHomeView, 
                                 IShowAppointments displayService)
        {
            _view = userHomeView;
            _model = userHomeModel;
            _displayService = displayService;

            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.RowSelected += OnRowSelected;
            _view.CreateAppointmentButtonClicked += OnCreateAppointmentButtonClicked;
            _view.ManageCoursesButtonClicked += OnManageCoursesButtonClicked;
            _view.ManageAppointmentButtonClicked += OnManageAppointmentButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;

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

            int noAppointmentSelected = -1;
            if (_view.SessionAppointmentId == noAppointmentSelected)
            {
                _view.Message = "No appointment has been selected!";
            }
            else
            {
                _view.RedirectToManageAppointment();
            }

        }

        private void OnManageCoursesButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        private void OnCreateAppointmentButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCreateAppointment();
        }

        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            _view.SetDataSource = _displayService.GetAllAppointmentsFor<APPOINTMENT>(_view.LoggedInClient);
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.SessionRowIndex = -1;
            _view.SessionAppointmentId = -1;
            _view.BindData();
        }
        private void FetchData()
        {
            var appointments = _displayService.GetAppointmentsCached<APPOINTMENT>();

        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _view.SessionRowIndex = _view.SelectedRowIndex;
            GetSelectedAppointmentIdFromGrid();
        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyAscending<object>(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.BindData();

            GetSelectedAppointmentIdFromGrid();
        }
        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyDescending<object>(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.BindData();

            GetSelectedAppointmentIdFromGrid();
        }
        private void GetSelectedAppointmentIdFromGrid()
        {
            int noIndexSelected = -1;
            if (_view.SessionRowIndex != noIndexSelected)
            {
                var selectedAppointmentId = _view.SelectedRowValueDataKey;
                _view.SessionAppointmentId = (int)selectedAppointmentId;
                _view.Message = selectedAppointmentId.ToString();
            }
        }
    }
}
