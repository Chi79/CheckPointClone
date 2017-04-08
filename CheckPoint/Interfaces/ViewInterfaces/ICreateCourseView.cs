using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface ICreateCourseView
    {

        string Message { get; set; }
        string CourseName { get; }
        string Description { get; }
        string IsPrivate { get; }
        string IsObligatory { get; }


        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool CreateCourseButtonVisible { set; }
        bool BackToCoursesPageButtonVisible { set; }


        void RedirectToCoursesPage();

        event EventHandler<EventArgs> CreateNewCourse;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> BackToCoursesPageClicked;

    }
}
