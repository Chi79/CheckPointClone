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
    public partial class FindAppointmentsView : ViewBase<FindAppointmentsPresenter> , IFindAppointmentsView
    {
        public string Message
        {

            set { MessagePanel.Message = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { UserAppointmentGridView.SetDataSource = value; }

        }

        public IEnumerable<object> SetDataSource2
        {
            set { UserAppointmentGridViewHeader.SetDataSource2 = value; }
        }

        public int SelectedRowIndex
        {

            get { return UserAppointmentGridView.SelectedRowIndex; }
            set { UserAppointmentGridView.SelectedRowIndex = value; }

        }

        public object SelectedRowValueDataKey
        {

            get { return UserAppointmentGridView.SelectedRowValueDataKey; }

        }

        public bool MessagePanelVisible
        {

            set { MessagePanel.MessagePanelVisible = value; }

        }

        public bool ContinueButtonVisible
        {

            set { MessagePanel.ContinueButtonVisible = value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void HookUpEvents()
        {

            UserAppointmentGridView.RowSelected += OnRowSelected;
            UserAppointmentGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            UserAppointmentGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            UserAppointmentGridViewHeader.RowSelected += OnAppointmentGridViewHeader_Selected;

            MessagePanel.ReloadPage += OnMessagePanel_ReloadPage;

        }

        private void OnMessagePanel_ReloadPage(object sender, EventArgs e)
        {

            if(ContinueButtonClicked != null)
            {
                ContinueButtonClicked(this, EventArgs.Empty);
            }

        }

        public void BindData()
        {

            UserAppointmentGridViewHeader.DataBind();
            UserAppointmentGridView.DataBind();

        }


        public void RedirectToFindCoursesView()
        {

            Response.Redirect("FindCoursesView.aspx");

        }

        public void RedirectToApplyToAppointmentView()
        {

            Response.Redirect("ApplyToAttendAppointmentView.aspx");
        }


        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;

        public event EventHandler<EventArgs> FindCoursesButtonClicked;
        public event EventHandler<EventArgs> ApplyToAttendAppointmentButtonClicked;

        public event EventHandler<EventArgs> ContinueButtonClicked;

        private void OnAppointmentGridViewHeader_Selected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

        private void OnSortColumnsByPropertyDescending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyDescending != null)
            {
                SortColumnsByPropertyDescending(this, EventArgs.Empty);
            }
        }

        private void OnSortColumnsByPropertyAscending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyAscending != null)
            {
                SortColumnsByPropertyAscending(this, EventArgs.Empty);
            }
        }

        private void OnRowSelected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }


        protected void btnFindCourses_Click1(object sender, EventArgs e)
        {
            if (FindCoursesButtonClicked != null)
            {
                FindCoursesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnApplyToAttendSelectedAppointment_Click(object sender, EventArgs e)
        {
            if(ApplyToAttendAppointmentButtonClicked != null)
            {
                ApplyToAttendAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}