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
        public event EventHandler<EventArgs> SortColumn;
        public event EventHandler<EventArgs> RowSelected;

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public IEnumerable<object> SetDataSource
        {
            set { gvHostTable.DataSource = value; }
        }
   
        public int SelectedRowIndex
        {
            get  { return gvHostTable.SelectedIndex; }
            set  { gvHostTable.SelectedIndex = value; }
        }
 
        public int? SessionRowIndex
        {
            get { return (int)Session["MyRowIndex"]; }
            set { Session["MyRowIndex"] = value; }
        }

        public string ColumnTitle
        {
            get { return Session["MySortExpression"].ToString(); }
            set { Session["MySortExpression"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void BindData()
        {
            gvHostTable.DataBind();
        }

        protected void gvHostTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

        protected void gvHostTable_Sorting(object sender, GridViewSortEventArgs e)
        {
            ColumnTitle = e.SortExpression;
            if (SortColumn != null)
            {
                SortColumn(this, EventArgs.Empty);
            }
        }
        protected void AppIdAsc_Click(object sender, EventArgs e)
        {
            this.Message = "haha";
        }
        protected void AppIdDesc_Click(object sender, EventArgs e)
        {
            this.Message = "Hoorah";
        }
        protected void CourseIdAsc_Click(object sender, EventArgs e)
        {
            this.Message = "hoho";
        }
        protected void CourseIdDesc_Click(object sender, EventArgs e)
        {
            this.Message = "hehe";
        }

        protected void AppNameAsc_Click(object sender, EventArgs e)
        {

        }

        protected void AppNameDesc_Click(object sender, EventArgs e)
        {

        }

        protected void DescriptionAsc_Click(object sender, EventArgs e)
        {

        }

        protected void DescriptionDesc_Click(object sender, EventArgs e)
        {

        }
        protected void DateAsc_Click(object sender, EventArgs e)
        {

        }

        protected void DateDesc_Click(object sender, EventArgs e)
        {

        }

        protected void StartTimeAsc_Click(object sender, EventArgs e)
        {

        }

        protected void StartTimeDesc_Click(object sender, EventArgs e)
        {

        }

        protected void EndTimeAsc_Click(object sender, EventArgs e)
        {

        }

        protected void EndTimeDesc_Click(object sender, EventArgs e)
        {

        }

        protected void AddressAsc_Click(object sender, EventArgs e)
        {

        }

        protected void AddressDesc_Click(object sender, EventArgs e)
        {

        }

        protected void PostalCodeAsc_Click(object sender, EventArgs e)
        {

        }

        protected void PostalCodeDesc_Click(object sender, EventArgs e)
        {

        }

        protected void IsObligAsc_Click(object sender, EventArgs e)
        {

        }

        protected void IsObligDesc_Click(object sender, EventArgs e)
        {

        }

        protected void IsPrivateAsc_Click(object sender, EventArgs e)
        {

        }

        protected void IsPrivateDesc_Click(object sender, EventArgs e)
        {

        }
    }
}