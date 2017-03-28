using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class AppointmentGridViewHeader : System.Web.UI.UserControl
    {
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> RowSelected;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ColumnName
        {
            get { return Session["MySortExpression"].ToString(); }
            set { Session["MySortExpression"] = value; }
        }

        public IEnumerable<object> SetDataSource2
        {
            set { gvHostTable1.DataSource = value; }
        }

        public void BindData()
        {
            gvHostTable1.DataBind();
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
        protected void gvHostTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }
    }
}