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
    public partial class UserAttendanceHistoryView : ViewBase<UserAttendanceHistoryPresenter>, IUserAttendanceHistoryView
    {
        public override void HookUpEvents()
        {
           AppointmentGridView.RowSelected += OnAppointmentRowSelected;
        }

        public IEnumerable<object> AppointmentsHistorySetDataSource
        {
            set
            {
                AppointmentGridView.SetDataSource = value;
            }
        }

        public IEnumerable<object> AppointmentsHistoryHeaderSetDataSource
        {
            set
            {
                AppointmentGridViewHeader.SetDataSource2 = value;
            }
        }

        public IEnumerable<object> AttendanceHistoryHeaderSetDataSource
        {
            set { AttendeeGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AttendanceHistorySetDataSource
        {
            set { AttendeeGridView.SetDataSource = value; }
        }

        public int SelectedAppointmentRowIndex
        {
            get
            {
                return AppointmentGridView.SelectedRowIndex;
            }

            set
            {
                AppointmentGridView.SelectedRowIndex = value;
            }
        }

        public object SelectedAppointmentRowValueDataKey
        {
            get
            {
                return AppointmentGridView.SelectedRowValueDataKey;
            }
        }

        public bool ShowAttendeeGridView
        {
            get
            {
                return AttendeeGridView.Visible;
            }

            set
            {
                AttendeeGridView.Visible = value;
            }
        }

        public bool ShowAttendeeGridViewHeader
        {
            get
            {
                return AttendeeGridViewHeader.Visible;
            }

            set
            {
                AttendeeGridViewHeader.Visible = value;
            }
        }

        public bool ShowAttendeeHeader
        {
            set { AttendeeHeader.Visible = value; }
        }

        public void BindAppointmentData()
        {
            AppointmentGridViewHeader.BindData();
            AppointmentGridView.BindData();
        }

        public void BindAttendeeData()
        {
            AttendeeGridViewHeader.BindData();
            AttendeeGridView.BindData();
        }

        public event EventHandler<EventArgs> AppointmentRowSelected;

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }
        

        private void OnAppointmentRowSelected(object sender, EventArgs e)
        {
            if(AppointmentRowSelected != null)
            {
                AppointmentRowSelected(this, EventArgs.Empty);
            }
        }

       
    }
}