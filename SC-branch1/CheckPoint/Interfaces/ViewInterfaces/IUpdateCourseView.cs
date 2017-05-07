using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IUpdateCourseView
    {

        string Message { get; set; }
        string CourseName { get; set; }
        string Description { get; set; }
        string IsPrivate { get; set; }
        string IsObligatory { get; set; }


        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool UpdateCourseButtonVisible { set; }
    




        void RedirectToManageCourseView();

        event EventHandler<EventArgs> UpdateCourseButtonClicked;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;


    }
}
