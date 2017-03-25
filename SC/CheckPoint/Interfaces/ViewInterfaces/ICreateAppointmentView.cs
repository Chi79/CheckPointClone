using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface ICreateAppointmentView
    {
  
        string StartTime { get; }
        string EndTime { get; }
        string PostalCode { get; }
        string AppointmentName {get;}
        string Description { get; }
        string Address { get; }
        string Date { get; }
        string UserName { get; }
        string IsCancelled { get; }
        string IsObligatory { get; }
        bool ContinueButtonVisible { set; }
        bool CreateButtonVisible { set; }
        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool BackToHomePageButtonVisible { set; }
        bool AddAnotherAppointmentButtonVisible { set; }

        void RedirectAfterClickEvent();
        void RedirectToHomePage();
        void RedirectToViewCourses();

        int JobState { get; set; }
        string Message { get;  set; }

        bool IsAppointmentBeingAddedToCourse { get; set; }
        int SessionCourseId { get; }
        bool BackToViewCoursesButtonVisible { set; }

        event EventHandler<EventArgs> CreateNewAppointment;
        event EventHandler<EventArgs> Continue;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> BackToHomePageClicked;

        event EventHandler<EventArgs> BackToViewCoursesButtonClicked;
        event EventHandler<EventArgs> AddAnotherAppointmentButtonClicked;
    }
}
