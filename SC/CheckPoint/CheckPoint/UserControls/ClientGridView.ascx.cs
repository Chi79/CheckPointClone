using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class AttendeeGridView : System.Web.UI.UserControl
    {

        public int? SessionRowIndex
        {

            get { return (int)Session["MyRowIndex"]; }
            set { Session["MyRowIndex"] = value; }

        }
        public int SelectedRowIndex
        {

            get { return gvClientTable.SelectedIndex; }
            set { gvClientTable.SelectedIndex = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { gvClientTable.DataSource = value; }

        }

        public void BindData()
        {

            gvClientTable.DataBind();

        }

        public object SelectedRowValueDataKey
        {

            get { return gvClientTable.DataKeys[(int)SessionRowIndex].Value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler<EventArgs> RowSelected;

        protected void gvClientTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }

        }
        protected void gvClientTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvClientTable, "Select$" + e.Row.RowIndex);
            }

        }
    }
}