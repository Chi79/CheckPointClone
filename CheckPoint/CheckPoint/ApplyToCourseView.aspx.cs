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
    public partial class ApplyToCourseView :ViewBase<ApplyToCoursePresenter>, IApplyToCourseView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HookUpEvents();

        }
        public string Message
        {

            set { lblMessage.Text = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { UserAppointmentGridView.SetDataSource = value; }

        }

        public IEnumerable<object> SetDataSource2
        {
            set { UserAppointmentGridViewHeader.SetDataSource2 = value; }
        }

        public int SelectedRowIndex
        {

            get { return UserAppointmentGridView.SelectedRowIndex; }
            set { UserAppointmentGridView.SelectedRowIndex = value; }

        }

        public object SelectedRowValueDataKey
        {

            get { return UserAppointmentGridView.SelectedRowValueDataKey; }

        }
        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;

        public event EventHandler<EventArgs> btnApplyToCourse_Click;


        protected void OnbtnApplyToCourse_Click(object sender, EventArgs e)
        {
            if (btnApplyToCourse_Click != null)
            {
                btnApplyToCourse_Click(this, EventArgs.Empty);
            }
            
        }

        public void BindData()
        {
            UserAppointmentGridViewHeader.DataBind();
            UserAppointmentGridView.DataBind();
        }
        public override void HookUpEvents()
        {
            RowSelected += ApplyToCourseView_RowSelected;
            SortColumnsByPropertyAscending += ApplyToCourseView_SortColumnsByPropertyAscending;
            SortColumnsByPropertyDescending += ApplyToCourseView_SortColumnsByPropertyDescending;
        
    }

        private void ApplyToCourseView_SortColumnsByPropertyDescending(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ApplyToCourseView_SortColumnsByPropertyAscending(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ApplyToCourseView_RowSelected(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

  
    }
}