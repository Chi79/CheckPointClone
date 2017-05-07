using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class UserCourseGridView : System.Web.UI.UserControl
    {
        public int? SessionRowIndex
        {

            get { return (int)Session["MyRowIndex"]; }
            set { Session["MyRowIndex"] = value; }

        }
        public int SelectedRowIndex
        {

            get { return gvHostTable.SelectedIndex; }
            set { gvHostTable.SelectedIndex = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { gvHostTable.DataSource = value; }

        }

        public object SelectedRowValueDataKey
        {

            get { return gvHostTable.DataKeys[(int)SessionRowIndex].Value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler<EventArgs> RowSelected;

        protected void gvHostTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }

        }
        protected void gvHostTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvHostTable, "Select$" + e.Row.RowIndex);
            }

        }
    }
}