﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;

namespace CheckPointCommon.ViewInterfaces
{
    public interface ICreateAppointmentView 
    {
        string Message { get; set; }

        string StartTime { get; }
        string EndTime { get; }
        string PostalCode { get; }
        string AppointmentName { get; }
        string Description { get; }
        string Address { get; }
        string Date { get; }
        string IsCancelled { get; set; }
        string IsObligatory { get; }
        string IsPrivate { get; }


        bool ContinueButtonVisible { set; }
        bool CreateButtonVisible { set; }
        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool MessagePanelVisible { set; }
        bool IsCancelledDropDownVisible { set; }
        bool IsCancelledLabelVisible { set; }


        void RedirectAfterClickEvent();
        void RedirectToHomePage();

        void RedirectToChangesSavedPage();

        event EventHandler<EventArgs> CreateNewAppointment;
        event EventHandler<EventArgs> Continue;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
     

    }
}
