using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface ICreateCourseView
    {
        //TODO
        int CourseId { get; set; }
        string CourseName { get; }
        string Description { get; }
        string UserName { get; }
        string IsPrivate { get; }

        bool AddingAppointmentToCourse { get; set; }

        bool ContinueButtonVisible { set; }
        bool CreateButtonVisible { set; }
        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool CreateCourseButtonVisible { set; }
        bool BackToHomePageButtonVisible { set; }

        bool AddNewAppointmentToCourseButtonVisible { set; }
        bool AddExistingAppointmentToCourseButtonVisible { set; }


        void RedirectAfterClickEvent();
        void RedirectToHomePage();

        void RedirectToAddNewAppointmentToCourse();
        void RedirectToAddExistingAppointmentToCourse();

        int JobState { get; set; }
        string Message { get; set; }

        event EventHandler<EventArgs> CreateNewCourse;
        event EventHandler<EventArgs> Continue;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> BackToHomePageClicked;

        event EventHandler<EventArgs> AddNewAppontmentToCourseClicked;
        event EventHandler<EventArgs> AddExistingAppontmentToCourseClicked;
    }
}
