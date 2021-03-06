﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IDeleteCourseView
    {
        string Message { get; set; }
        bool CourseNameReadonly { set; }
        bool DescriptionReadonly { set; }
        bool IsPrivateEnabled { set; }
        bool IsObligatoryEnabled { set; }

        string CourseName { set; }
        string Description { set; }
        string IsPrivate { set; }
        string IsObligatory{ set; }


        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }
        bool DeleteCourseButtonVisible { set; }
        bool MessagePanelVisible { set; }
        bool ContinueButtonVisible { set; }
   


        void RedirectToCoursesPage();
        void RedirectToAppointmentsView();
        void RedirectToManageCourseView();
        void RedirectAfterClick();

        void RedirectToChangesSavedCoursePage();

        void RedirectToInvalidNavigationView();

        event EventHandler<EventArgs> DeleteCourseButtonClicked;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> ContinueButtonClicked;


    }
}
