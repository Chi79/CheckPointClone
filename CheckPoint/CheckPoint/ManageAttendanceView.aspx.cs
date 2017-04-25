using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointPresenters.Presenters;

namespace CheckPoint.Views
{
    public partial class ManageAttendanceView : ViewBase<ManageAttendancePresenter> ,IManageAttendanceView
    {
        public IEnumerable<object> CoursesAppliedToSetDataSource
        {
            set {CourseGridView.SetDataSource = value; }
        }

        public IEnumerable<object> CoursesAppliedToHeaderSetDataSource
        {
            set { CourseGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppointmentsAppliedToSetDataSource
        {
            set {  AppointmentGridView.SetDataSource = value; }
        }

        public IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource
        {
            set { AppointmentGridViewHeader.SetDataSource2 = value; }
        }

        public event EventHandler<EventArgs> AcceptAttendanceRequest;




        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO
        }

        protected void btnAcceptAttendeeRequest_Click(object sender, EventArgs e)
        {
            if(AcceptAttendanceRequest != null)
            {
                AcceptAttendanceRequest(this, EventArgs.Empty);
            }
        }

        public void BindData()
        {
            AppointmentGridView.BindData();
            AppointmentGridViewHeader.BindData();

            CourseGridView.DataBind();
            CourseGridViewHeader.BindData();
        }
    }
}