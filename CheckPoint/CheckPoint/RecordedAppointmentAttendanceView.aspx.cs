using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointPresenters.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views
{
    public partial class RecordedAppointmentAttendanceView : ViewBase<RecordedAppointmentAttendancePresenter>, IRecordedAppointmentAttendanceView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource
        {
            set { AppointmentRecordsGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppointmentsAppliedToSetDataSource
        {
            set { AppointmentRecordsGridView.SetDataSource = value; }
        }
        public IEnumerable<object> AppliedAttendeesHeaderSetDataSource
        {
            set { ClientGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppliedAttendeesSetDataSource
        {
            set { ClientGridView.SetDataSource = value; }
        }

        public void BindAppointmentData()
        {
            AppointmentRecordsGridViewHeader.BindData();
            AppointmentRecordsGridView.BindData();
        }

        public void BindAttendeeData()
        {
            ClientGridViewHeader.BindData();
            ClientGridView.BindData();
        }


        public event EventHandler<EventArgs> ViewCompletedAppointmentsButtonClicked; 

        public void RedirectToCompletedAppointmentsView()
        {
            Response.Redirect("ExpiredAppointmentsView.aspx");
        }

        protected void btnViewCompletedAppointments_Click(object sender, EventArgs e)
        {

            if(ViewCompletedAppointmentsButtonClicked != null)
            {
                ViewCompletedAppointmentsButtonClicked(this, EventArgs.Empty);
            }
           
        }
    }
}