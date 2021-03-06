﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class AddSelectedAppointmentToCoursePresenter : PresenterBase
    {

        private IAddSelectedAppointmentToCourseView _view;
        private IAddSelectedAppointmentToCourseModel _model;

        public AddSelectedAppointmentToCoursePresenter(IAddSelectedAppointmentToCourseView view,
                                                       IAddSelectedAppointmentToCourseModel model)
        {
            _view = view;
            _model = model;

        }

        public override void FirstTimeInit()
        {

            CheckIsAppointmentSelected();

        }

        public override void Load()
        {

            WireUpEvents();

        }

        private void CheckIsAppointmentSelected()
        {

            int noAppointmentSelected = -1;

            if(_model.GetSessionAppointmentId() == noAppointmentSelected)
            {

                _view.RedirectBackToHostHomeView();

            }
            else
            {

                ConfrimAction();

            }

        }

        private void ConfrimAction()
        {

            DisplaySelectedAppointmentData();

            SetFieldsToReadOnly();

            ConfirmAction();

            DisplayDesicionButtons();


        }


        private void WireUpEvents()
        {

            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;

        }


        private void OnNoButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectBackToHostHomeView();

        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCourseSelectorView();

        }

        private void ShowMessagePanel()
        {

            _view.MessagePanelVisible = true;

        }

        private void HideMessagePanel()
        {

            _view.MessagePanelVisible = false;

        }

        private void ConfirmAction()
        {

            ShowMessagePanel();

            _view.Message = "Do you wish to add this appointment to a course?";


        }

        private void DisplaySelectedAppointmentData()
        {

            var selectedAppointment = _model.GetSelectedAppointmentById() as APPOINTMENT;

            _view.AppointmentName = selectedAppointment.AppointmentName;
            _view.Description = selectedAppointment.Description;
            _view.Date = selectedAppointment.Date.ToString("MM/dd/yyyy");
            _view.StartTime = selectedAppointment.StartTime.ToString();
            _view.EndTime = selectedAppointment.EndTime.ToString();
            _view.Address = selectedAppointment.Address;
            _view.PostalCode = selectedAppointment.PostalCode.ToString();
            _view.IsObligatory = selectedAppointment.IsObligatory.ToString();
            _view.IsCancelled = selectedAppointment.IsCancelled.ToString();
            _view.IsPrivate = selectedAppointment.IsPrivate.ToString();

        }

        private void SetFieldsToReadOnly()
        {
            _view.AppointmentNameReadOnly = true;
            _view.AppointmentDescriptionReadOnly = true;
            _view.DateReadOnly = true;
            _view.StartTimeReadOnly = true;
            _view.EndTimeReadOnly = true;
            _view.IsCancelledEnabled = false;
            _view.IsObligatoryEnabled = false;
            _view.PostalCodeReadOnly = true;
            _view.AddressReadOnly = true;
            _view.IsPrivateEnabled = false;
        }

        private void DisplayDesicionButtons()
        {
            _view.YesButtonVisible = true;
            _view.NoButtonVisible = true;
        }

    }
}
