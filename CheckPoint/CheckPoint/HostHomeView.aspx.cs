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
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
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

        public string ColumnName
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
    }
}