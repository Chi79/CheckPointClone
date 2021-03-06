﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class AttendeeGridViewHeader1 : System.Web.UI.UserControl
    {
        public string ColumnName
        {

            get { return Session["MySortExpression"].ToString(); }
            set { Session["MySortExpression"] = value; }

        }

        public IEnumerable<object> SetDataSource2
        {

            set { gvAttendeeTable1.DataSource = value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            gvAttendeeTable1.DataBind();
        }

        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> AttendeeRowSelected;

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

        protected void gvAttendeeTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (AttendeeRowSelected != null)
            {
                AttendeeRowSelected(this, EventArgs.Empty);
            }

        }
    }
}