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
    public partial class ManageCourseView : ViewBase<ManageCoursePresenter> , IManageCourseView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        public override void HookUpEvents()
        {

            ManageCourseAppGrid.RowSelected += GridView_RowSelected;
            ManageCourseAppGridHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            ManageCourseAppGridHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            ManageCourseAppGridHeader.RowSelected += OnAppointmentGridViewHeader_RowSelected;

        }

        public string Message
        {

            set { lblMessage.Text = value; }

        }

        public bool AppointmentAddedMessageVisible
        {

            set { appointmentAddedMessage.Visible = value; }

        }

        public bool AppointmentDeletedMessageVisible
        {

            set { appointmentDeletedMessage.Visible = value; }

        }

        public bool RemoveSelectedAppointmentButtonVisible
        {

            set { btnRemoveSelectedAppointmentFromCourse.Visible = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { ManageCourseGrid.SetDataSource = value; }

        }

        public IEnumerable<object> SetDataSource2
        {

            set { ManageCourseHeader.SetDataSource2 = value; }

        }

        public IEnumerable<object> SetDataSourceAppointmentHeader
        {

            set { ManageCourseAppGridHeader.SetDataSource2 = value;  }

        }

        public IEnumerable<object> SetDataSourceAppointmentData
        {

            set { ManageCourseAppGrid.SetDataSource = value; }

        }

        public object SelectedRowValueDataKey
        {

            get { return ManageCourseAppGrid.SelectedRowValueDataKey; }

        }

        public int SelectedRowIndex
        {

            get { return ManageCourseAppGrid.SelectedRowIndex; }
            set { ManageCourseAppGrid.SelectedRowIndex = value; }

        }


        public void BindData()
        {

            ManageCourseGrid.DataBind();
            ManageCourseHeader.DataBind();

            ManageCourseAppGrid.DataBind();
            ManageCourseAppGridHeader.DataBind();

        }

        public void RedirectToCourseSelectorView()
        {

            Response.Redirect("CourseSelectorView.aspx");

        }

        public void RedirectToAppointmentSelectorView()
        {

            Response.Redirect("AppointmentSelectorView.aspx");

        }

        public void RedirectToAppointmentsView()
        {

            Response.Redirect("HostHomeView.aspx");

        }

        public void RedirectToCoursesView()
        {

            Response.Redirect("HostCoursesView.aspx");

        }

        public void RedirectToUpdateCourseView()
        {

            Response.Redirect("UpdateCourseView.aspx");

        }

        public void ReloadPageAfterEditing()
        {

            Response.Redirect("ManageCourseView.aspx");

        }

        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> ViewAppointementsButtonClicked;
        public event EventHandler<EventArgs> ViewCoursesButtonClicked;

        public event EventHandler<EventArgs> RemoveSelectedAppointmentButtonClicked;
        public event EventHandler<EventArgs> MoveSelectedAppointmentToAnotherCourseButtonClicked;
        public event EventHandler<EventArgs> AddAnotherAppointmentToThisCourseButtonClicked;
        public event EventHandler<EventArgs> UpdateCourseButtonClicked;


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

        protected void btnBackToAppointmentsView_Click(object sender, EventArgs e)
        {
            if(ViewAppointementsButtonClicked != null)
            {
                ViewAppointementsButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnBackToCoursesView_Click(object sender, EventArgs e)
        {
            if(ViewCoursesButtonClicked != null)
            {
                ViewCoursesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnRemoveSelectedAppointmentFromCourse_Click(object sender, EventArgs e)
        {
            if(RemoveSelectedAppointmentButtonClicked != null)
            {
                RemoveSelectedAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnMoveSelectedAppointmentToAnotherCourse_Click(object sender, EventArgs e)
        {
            if(MoveSelectedAppointmentToAnotherCourseButtonClicked != null)
            {
                MoveSelectedAppointmentToAnotherCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnAddAnotherAppointmentToThisCourse_Click(object sender, EventArgs e)
        {
            if(AddAnotherAppointmentToThisCourseButtonClicked != null)
            {
                AddAnotherAppointmentToThisCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if(UpdateCourseButtonClicked != null)
            {
                UpdateCourseButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}