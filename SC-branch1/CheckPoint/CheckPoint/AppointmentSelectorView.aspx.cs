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
    public partial class AppointmentSelectorView : ViewBase<AppointmentSelectorPresenter> , IAppointmentSelectorView
    {
        public string Message
        {

            set { MessagePanel.Message = value; }

        }

        public bool MessagePanelVisible
        {

            set { MessagePanel.MessagePanelVisible = value; }

        }

        public bool ContinueButtonVisible
        {

            set { MessagePanel.ContinueButtonVisible = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { AppointmentGridView.SetDataSource = value; }

        }

        public IEnumerable<object> SetDataSource2
        {

            set { AppointmentGridViewHeader.SetDataSource2 = value; }

        }

        public int SelectedRowIndex
        {

            get { return AppointmentGridView.SelectedRowIndex; }
            set { AppointmentGridView.SelectedRowIndex = value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void HookUpEvents()
        {

            AppointmentGridView.RowSelected += GridView_RowSelected;
            AppointmentGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            AppointmentGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            AppointmentGridViewHeader.RowSelected += OnAppointmentGridViewHeader_RowSelected;

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

            AppointmentGridView.DataBind();
            AppointmentGridViewHeader.DataBind();

        }

        public void RedirectToManageCourseView()
        {

            Response.Redirect("ManageCourseView.aspx");

        }

        public void RedirectToAppointmentsView()
        {

            Response.Redirect("HostHomeView.aspx");

        }

        public object SelectedRowValueDataKey
        {

            get { return AppointmentGridView.SelectedRowValueDataKey; }

        }

        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> AddSelectedAppointmentToCourseButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;


        private void OnAppointmentGridViewHeader_RowSelected(object sender, EventArgs e)
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

        private void GridView_RowSelected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

        private void OnRowSelected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }


        protected void btnAddSelectedAppointmentToCourse_Click(object sender, EventArgs e)
        {
            if (AddSelectedAppointmentToCourseButtonClicked != null)
            {
                AddSelectedAppointmentToCourseButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}