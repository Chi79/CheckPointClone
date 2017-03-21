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
        public IEnumerable<object> ApplicantsGridviewSource
        {
            set
            { dgvApplicants.DataSource = value; }
        }

        public IEnumerable<object> AppointmentsGridviewSource
        {
            set { dgvAppointments.DataSource = value; ; }
        }

        public event EventHandler<EventArgs> AcceptAttendeeForAppointment;




        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO
        }

        protected void btnAcceptAttendeeRequest_Click(object sender, EventArgs e)
        {
            if(AcceptAttendeeForAppointment != null)
            {
                AcceptAttendeeForAppointment(this, EventArgs.Empty);
            }
        }
    }
}