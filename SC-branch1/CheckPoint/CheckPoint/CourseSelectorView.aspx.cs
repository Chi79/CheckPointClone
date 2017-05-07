using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPointPresenters.Bases;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Presenters;

namespace CheckPoint.Views
{
    public partial class CourseSelectorView : ViewBase<CourseSelectorPresenter>, ICourseSelectorView
    {

        public string Message
        {

            set { MessagePanel.Message = value; }

        }

        public IEnumerable<object> SetDataSource
        {
            set { CourseGridView.SetDataSource = value; }
        }

        public IEnumerable<object> SetDataSource2
        {
            set { CourseGridViewHeader.SetDataSource2 = value; }
        }

        public int SelectedRowIndex
        {
            get { return CourseGridView.SelectedRowIndex; }
            set { CourseGridView.SelectedRowIndex = value; }
        }

        public object SelectedRowValueDataKey
        {

            get { return CourseGridView.SelectedRowValueDataKey; }

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
            CourseGridView.RowSelected += OnRowSelected;
            CourseGridViewHeader.RowSelected += OnCourseGridViewHeader_RowSelected;
            CourseGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            CourseGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;

            MessagePanel.ReloadPage += OnMessagePanel_ReloadPage;
        }

        public void BindData()
        {
            CourseGridView.DataBind();
            CourseGridViewHeader.DataBind();
        }


        public void RedirectToAppointmentsView()
        {
            Response.Redirect("HostHomeView.aspx");
        }

        public void RedirectToManageCourseView()
        {
            Response.Redirect("ManageCourseView.aspx");
        }

        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> RowSelected;
  
        public event EventHandler<EventArgs> AddAppointmentToSelectedCourseButtonClicked;
        public event EventHandler<EventArgs> CancelButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;


        private void OnSortColumnsByPropertyAscending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyAscending != null)
            {
                SortColumnsByPropertyAscending(this, EventArgs.Empty);
            }
        }

        private void OnSortColumnsByPropertyDescending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyDescending != null)
            {
                SortColumnsByPropertyDescending(this, EventArgs.Empty);
            }
        }

        private void OnCourseGridViewHeader_RowSelected(object sender, EventArgs e)
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

        protected void btnAddAppointmentToSelectedCourse_Click(object sender, EventArgs e)
        {
            if(AddAppointmentToSelectedCourseButtonClicked != null)
            {
                AddAppointmentToSelectedCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if(CancelButtonClicked != null)
            {
                CancelButtonClicked(this, EventArgs.Empty);
            }
        }

        private void OnMessagePanel_ReloadPage(object sender, EventArgs e)
        {
            if (ContinueButtonClicked != null)
            {
                ContinueButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}