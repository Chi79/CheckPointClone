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
    public partial class HostHomeView : ViewBase<HostHomePresenter> , IHostHomeView
    {
        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> CreateAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        public event EventHandler<EventArgs> CreateReportButtonClicked;
        public event EventHandler<EventArgs> ViewCoursesButtonClicked;
        public event EventHandler<EventArgs> AddSelectedAppointmentToCourseButtonClicked;

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
            get  { return gvHostTable.SelectedIndex; }
            set  { gvHostTable.SelectedIndex = value; }
        }
        public int? SessionAppointmentId
        {
            get { return (int)Session["AppointmentId"]; }
            set { Session["AppointmentId"] = value; }
        }

        public bool AddAppointmentToCourseStatus
        {
            get { return (bool)Session["AddingAppointmentToCourse"]; }
            set { Session["AddingAppointmentToCourse"] = value; }
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

        public bool ViewCoursesButtonVisible
        {
            set { btnViewCourses.Visible = value; }
        }

        public bool CreateAppointmentButtonVisible
        {
            set { btnCreateAppointment.Visible = value; }
        }

        public bool ManageAppointmentButtonVisible
        {
            set { btnManageAppointment.Visible = value; }
        }

        public bool CreateReportButtonVisible
        {
            set { btnCreateReport.Visible = value; }
        }

        public bool ManageAttendanceButtonVisible
        {
            set { btnManageAttendance.Visible = value; }
        }

        public bool AddSelectedAppointmenButtonVisible
        {
            set { btnAddSelectedAppointmentToCourse.Visible = value; }
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
            if(SortColumnsByPropertyAscending != null)
            {
                SortColumnsByPropertyAscending(this, EventArgs.Empty);
            }
        }

        protected void Desc_Command(object sender, CommandEventArgs e)
        {
            ColumnName = e.CommandName;
            if(SortColumnsByPropertyDescending != null)
            {
                SortColumnsByPropertyDescending(this, EventArgs.Empty);
            }
        }
        protected void createAppointment_Click(object sender, ImageClickEventArgs e)
        {
            if (CreateAppointmentButtonClicked != null)
            {
                CreateAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void manageAppointment_Click(object sender, ImageClickEventArgs e)
        {
            if (ManageAppointmentButtonClicked != null)
            {
                ManageAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void manageattendance_Click(object sender, ImageClickEventArgs e)
        {
            if(ManageAttendanceButtonClicked != null)
            {
                ManageAttendanceButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void createreport_Click(object sender, ImageClickEventArgs e)
        {
            if(CreateReportButtonClicked != null)
            {
                CreateReportButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void ViewCourses_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewCoursesButtonClicked != null)
            {
                ViewCoursesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnAddSelectedAppointmentToCourse_Click(object sender, ImageClickEventArgs e)
        {
            if (AddSelectedAppointmentToCourseButtonClicked != null)
            {
                AddSelectedAppointmentToCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void gvHostTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvHostTable, "Select$" + e.Row.RowIndex);
            }
        }

        public void RedirectToCreateAppointment()
        {
            Response.Redirect("CreateAppointmentView.aspx");
        }
        public void RedirectToManageAppointment()
        {
            Response.Redirect("ManageSingleAppointmentView.aspx");
        }
        public void RedirectToCoursesView()
        {
            Response.Redirect("HostCoursesView.aspx");
        }
    }
}