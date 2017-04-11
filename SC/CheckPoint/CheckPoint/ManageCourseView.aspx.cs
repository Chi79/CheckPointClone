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

        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> RowSelected;


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
    }
}