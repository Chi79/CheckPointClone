using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageSingleAppointmentView 
    {
        string Message { get; set; }

        string StartTime { get; set; }
        string EndTime { get; set; }
        string PostalCode { get; set; }
        string AppointmentName { get; set; }
        string Description { get; set; }
        string Address { get; set; }
        string Date { get; set; }
        string IsCancelled { get; set; }
        string IsObligatory { get; set; }
        string IsPrivate { get; set; }


        void RedirectAfterClickEvent();

        void RedirectToHostHomeView();

        void RedirectToViewCourses();


        bool ContinueButtonVisible { set; }
        bool UpdateButtonVisible { set; }
        bool DeleteButtonVisible { set; }
        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool BackToHomePageButtonVisible { set; }
        bool AddAppointmentToCourseButtonVisible { set; }
        bool BackToCoursesButtonVisible { set; }
        bool SelectAnotherAppointmentButtonVisible { set; }

        bool AppointmentNameReadOnly { set; }
        bool DateReadOnly   { set; } 
        bool AppointmentDescriptionReadOnly { set; }
        bool StartTimeReadOnly { set; }
        bool EndDateReadOnly { set; }
        bool IsCancelledEnabled { set; }
        bool IsObligatoryEnabled { set; }
        bool IsPrivateEnabled { set; }
        bool PostalCodeReadOnly { set; }
        bool AddressReadOnly { set; }
        bool EndTimeReadOnly { set; }


        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> AddAppointmentToCourseButtonClicked;
        event EventHandler<EventArgs> BackToCoursesButtonClicked;
        event EventHandler<EventArgs> SelectAnotherAppointmentButtonClicked;
        event EventHandler<EventArgs> UpdateAppointment;
        event EventHandler<EventArgs> DeleteAppointment;
        event EventHandler<EventArgs> ReloadPage;
        event EventHandler<EventArgs> BackToHomePage;

    }
}
