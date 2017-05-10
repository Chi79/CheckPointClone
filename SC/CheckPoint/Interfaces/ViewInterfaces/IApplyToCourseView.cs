using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IApplyToCourseView

    {


        bool BtnNoVisible { set; }

        bool BtnYesVisible { set; }
        bool BtnCancelVisible { set; }

        bool BtnApplyToCourseVisible { set; }

        bool BtnContinueVisible { set; }


        bool AppliedToAttendCourseMessageVisible { set; }

        string Message { set; }      

        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }



        IEnumerable<object> SetDataSourceAppointmentHeader { set; }

        bool MessagePanelVisible { set; }

        IEnumerable<object> SetDataSourceAppointmentData { set; }



        void BindData();


        void RedirectToFindPublicCourses();


        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;

        event EventHandler<EventArgs> ApplyToCourse_Click;    
        event EventHandler<EventArgs> Cancel_Click;
        event EventHandler<EventArgs> Yes_Click;
        event EventHandler<EventArgs> No_Click;
        event EventHandler<EventArgs> Continue_Click;


    }
}
