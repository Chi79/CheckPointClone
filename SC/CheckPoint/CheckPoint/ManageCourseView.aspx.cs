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
            AppointmentGridView.RowSelected += GridView_RowSelected;
            AppointmentGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            AppointmentGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            AppointmentGridViewHeader.RowSelected += OnAppointmentGridViewHeader_RowSelected;
        }


        public string Message
        {
            set { lblMessage.Text = value; }
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
            set { AppointmentGridViewHeader.SetDataSource2 = value;  }
        }

        public IEnumerable<object> SetDataSourceAppointmentData
        {
            set { AppointmentGridView.SetDataSource = value; }
        }

        public object SelectedRowValueDataKey
        {

            get { return AppointmentGridView.SelectedRowValueDataKey; }

        }

        public int SelectedRowIndex
        {

            get { return AppointmentGridView.SelectedRowIndex; }
            set { AppointmentGridView.SelectedRowIndex = value; }
        }


        public void BindData()
        {
            ManageCourseGrid.DataBind();
            ManageCourseHeader.DataBind();

            AppointmentGridView.DataBind();
            AppointmentGridViewHeader.DataBind();
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