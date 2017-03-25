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
        bool ContinueButtonVisible { set; }
        bool CreateButtonVisible { set; }
        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        void RedirectAfterClickEvent();
        void RedirectToHomePage();
        int JobState { get; set; }
        string Message { get; set; }

        event EventHandler<EventArgs> CreateNewCourse;
        event EventHandler<EventArgs> Continue;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> BackToHomePageClicked;
    }
}
