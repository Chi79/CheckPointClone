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
    public partial class HostHomeView : ViewBase<HostHomePresenter> , IHostHomeView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO
      
        }
        public IEnumerable<object> SetDataSource
        {
            set { gvAppointments.DataSource = value; }
        }
        public IEnumerable<object> SetDataSource2
        {     
            set { gv2.DataSource = value; } 
        }

        public void Databind()
        {
            gvAppointments.DataBind();
            gv2.DataBind();
        }
        public string Message
        {
            set { lblMessage.Text = value; }
        }
        public event EventHandler<EventArgs> BindGrid;

        protected void gvAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvAppointments_Sorting(object sender, GridViewSortEventArgs e)
        {
            if(BindGrid != null)
            {
                BindGrid(this, EventArgs.Empty);
            }
        }
    }
}