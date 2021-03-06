﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class AttendeeGridView1 : System.Web.UI.UserControl
    {
        public int? SessionRowIndex
        {

            get { return (int)Session["MyRowIndex"]; }
            set { Session["MyRowIndex"] = value; }

        }
        public int SelectedRowIndex
        {

            get { return gvAttendeeTable.SelectedIndex; }
            set { gvAttendeeTable.SelectedIndex = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { gvAttendeeTable.DataSource = value; }

        }

        public void BindData()
        {

            gvAttendeeTable.DataBind();

        }

        public object SelectedRowValueDataKey
        {

            get { return gvAttendeeTable.DataKeys[(int)SessionRowIndex].Value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler<EventArgs> AttendeeRowSelected;

        protected void gvAttendeeTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (AttendeeRowSelected != null)
            {
                AttendeeRowSelected(this, EventArgs.Empty);
            }

        }
        protected void gvAttendeeTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvAttendeeTable, "Select$" + e.Row.RowIndex);
            }

        }
    }
}