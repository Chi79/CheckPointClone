using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageSingleAppointmentView
    {
        //TODO
        string SelectedAppointmentName { get; set; }

        bool AddAppointmentToCourseStatus { get; set; }
        int SessionCourseId { get; }

        int AppointmentId { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }
        string PostalCode { get; set; }
        string AppointmentName { get; set; }
        string Description { get; set; }
        string Address { get; set; }
        string Date { get; set; }
        string UserName { get; }
        string IsCancelled { get; set; }
        string IsObligatory { get; set; }

        void RedirectAfterClickEvent();

        void RedirectToHostHomeView();

        string Message { get; set; }

        bool ContinueButtonVisible { set; }
        bool UpdateButtonVisible { set; }
        bool DeleteButtonVisible { set; }

        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool BackToHomePageButtonVisible { set; }

        bool AddAppointmentToCourseButtonVisible { set; }

        bool AppointmentNameReadOnly { set; }
        bool DateReadOnly   { set; } 
        bool AppointmentDescriptionReadOnly { set; }
        bool StartTimeReadOnly { set; }
        bool EndDateReadOnly { set; }
        bool IsCancelledReadOnly { set; }
        bool IsObligatoryReadOnly { set; }
        bool PostalCodeReadOnly { set; }
        bool AddressReadOnly { set; }
        bool EndTimeReadOnly { set; }

        int JobState { get; set; }

        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;

        event EventHandler<EventArgs> AddAppointmentToCourseButtonClicked;

        event EventHandler<EventArgs> UpdateAppointment;
        event EventHandler<EventArgs> DeleteAppointment;
        event EventHandler<EventArgs> ReloadPage;
        event EventHandler<EventArgs> BackToHomePage;

    }
}
