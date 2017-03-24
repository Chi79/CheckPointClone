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
    public partial class HostCoursesView : ViewBase<HostCoursesPresenter> , IHostCoursesView
    {
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> RowSelected;

        public event EventHandler<EventArgs> CreateCourseButtonClicked;
        public event EventHandler<EventArgs> ManageCourseButtonClicked;
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        public event EventHandler<EventArgs> CreateReportButtonClicked;

        public event EventHandler<EventArgs> ViewAppointmentsButtonClicked;

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public IEnumerable<object> SetDataSource
        {
            set { gvHostTable.DataSource = value; }
        }
        public IEnumerable<object> SetDataSource2
        {
            set { gvHostTable1.DataSource = value; }
        }

        public int SelectedRowIndex
        {
            get { return gvHostTable.SelectedIndex; }
            set { gvHostTable.SelectedIndex = value; }
        }
        public int? SessionCourseId
        {
            get { return (int)Session["CourseId"]; }
            set { Session["CourseId"] = value; }
        }

        public int? SessionRowIndex
        {
            get { return (int)Session["MyRowIndex"]; }
            set { Session["MyRowIndex"] = value; }
        }

        public string ColumnName
        {
            get { return Session["MySortExpression"].ToString(); }
            set { Session["MySortExpression"] = value; }
        }

        public string LoggedInClient
        {
            get { return Session["LoggedInClient"].ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            gvHostTable.DataBind();
            gvHostTable1.DataBind();
        }
        public object SelectedRowValueDataKey
        {
            get { return gvHostTable.DataKeys[(int)SessionRowIndex].Value; }
        }

        protected void gvHostTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

        protected void Asc_Command(object sender, CommandEventArgs e)
        {
            ColumnName = e.CommandName;
            if (SortColumnsByPropertyAscending != null)
            {
                SortColumnsByPropertyAscending(this, EventArgs.Empty);
            }
        }

        protected void Desc_Command(object sender, CommandEventArgs e)
        {
            ColumnName = e.CommandName;
            if (SortColumnsByPropertyDescending != null)
            {
                SortColumnsByPropertyDescending(this, EventArgs.Empty);
            }
        }


        protected void manageattendance_Click(object sender, ImageClickEventArgs e)
        {
            if (ManageAttendanceButtonClicked != null)
            {
                ManageAttendanceButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void createreport_Click(object sender, ImageClickEventArgs e)
        {
            if (CreateReportButtonClicked != null)
            {
                CreateReportButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void gvHostTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvHostTable, "Select$" + e.Row.RowIndex);
            }
        }

        public void RedirectToCreateCourse()
        {
            // TODO  Response.Redirect("CreateCourseView.aspx");
            this.Message = "poopoo!";
        }
        public void RedirectToManageCourse()
        {
            //TODO  Response.Redirect("ManageCourseView.aspx");
            this.Message = "bumbum!";
        }
        public void RedirectToAppointmentsView()
        {
            Response.Redirect("HostHomeView.aspx");
        }

        protected void managecourse_Click(object sender, ImageClickEventArgs e)
        {
            if (ManageCourseButtonClicked != null)
            {
                ManageCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void createcourse_Click(object sender, ImageClickEventArgs e)
        {
            if (CreateCourseButtonClicked != null)
            {
                CreateCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void ViewAppointments_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewAppointmentsButtonClicked != null)
            {
                ViewAppointmentsButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}