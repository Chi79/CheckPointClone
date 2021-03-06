﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageCourseView
    {

        bool MessagePanelVisible { set; }
        bool ContinueButtonVisible { set; }
        bool RemoveSelectedAppointmentButtonVisible { set; }   
        string Message { set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }


        void BindData();

        void RedirectToCourseSelectorView();
        void RedirectToAppointmentSelectorView();
        void RedirectToAppointmentsView();
        void RedirectToCoursesView();
        void RedirectToUpdateCourseView();
        void RedirectToDeleteCourseView();
    
        void ReloadPageAfterEditing();



        IEnumerable<object> SetDataSourceAppointmentHeader { set; }
        IEnumerable<object> SetDataSourceAppointmentData { set; }
        object SelectedRowValueDataKey { get; }
        int SelectedRowIndex { get; set; }


        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> ViewAppointementsButtonClicked;
        event EventHandler<EventArgs> ViewCoursesButtonClicked;

        event EventHandler<EventArgs> RemoveSelectedAppointmentButtonClicked;
        event EventHandler<EventArgs> MoveSelectedAppointmentToAnotherCourseButtonClicked;
        event EventHandler<EventArgs> AddAnotherAppointmentToThisCourseButtonClicked;
        event EventHandler<EventArgs> UpdateCourseButtonClicked;
        event EventHandler<EventArgs> DeleteCourseButtonClicked;

        event EventHandler<EventArgs> ContinueButtonClicked;

    }
}
