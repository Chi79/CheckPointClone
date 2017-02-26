using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfaceLibrary;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using AppointmentsPresenter;
using AppointmentModel;
using POCOClassLibrary;


namespace WebFormMVP 
{
    public partial class frmAppointmentView : System.Web.UI.Page, IAppointmentView
    {
        IAppointmentModel<Appointment> model;
        AppointmentPresenter presenter;

        public string AppointmentName
        {
            get { return txtAppointment.Text; }
            set { txtAppointment.Text = value;}
        }
        public string Priority
        {
            get { return cboPriority.Text; }
            set { cboPriority.Text = value; }
        }
        public string StartDate
        {
            get { return txtStartDate.Text; }
            set { txtStartDate.Text = value; }
        }
        public string DueDate
        {
            get { return txtDueDate.Text; }
            set { txtDueDate.Text = value; }
        }
        public string CompletionDate
        {
            get { return txtCompletionDate.Text; }
            set { txtCompletionDate.Text = value; }
        }
        public bool Completed
        {
            get { return chkCompleted.Checked; }
            set { chkCompleted.Checked = value; }
        }
        public bool isDirty { get { return (bool)Session["isDirty"]; }  set { Session["isDirty"] = value; }}

        public bool NewButtonVisible
        {
            set { btnNew.Visible = value; }
        }
        public bool SaveButtonVisible
        {
            set { btnSave.Visible = value; }
        }
        public bool NextButtonVisible
        {
            set { btnNext.Visible = value; }
        }
        public bool PreviousButtonVisible
        {
            set { btnPrevious.Visible = value; }
        }
        public bool YesButtonVisible
        {
            set { btnYes.Visible = value; }
        }
        public bool NoButtonVisible
        {
            set { btnNo.Visible = value; }
        }
        public string StatusChange
        {
            set { lblStatus.Text = value; }
        }

        public event EventHandler<EventArgs> NewAppointment;
        public event EventHandler<EventArgs> NextAppointment;
        public event EventHandler<EventArgs> NoButtonClick;
        public event EventHandler<EventArgs> PreviousAppointment;
        public event EventHandler<EventArgs> SaveAppointment;
        public event EventHandler<EventArgs> YesButtonClick;

        public void Show()
        {
            this.Show();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["myAppointment"] == null)
            {
                model = new AppointmentsModel();
                Session["myAppointment"] = model;
                this.isDirty = false;
            }
            presenter = new AppointmentPresenter((IAppointmentView)this, (IAppointmentModel<Appointment>)Session["myAppointment"]);
        }

        protected void txtAppointment_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        protected void txtDueDate_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        protected void txtCompletionDate_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        protected void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (PreviousAppointment != null)
            {
                PreviousAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveAppointment != null)
            {
                SaveAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            if (NewAppointment != null)
            {
                NewAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (NextAppointment != null)
            {
                NextAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (YesButtonClick != null)
            {
                YesButtonClick(this, EventArgs.Empty);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if (NoButtonClick != null)
            {
                NoButtonClick(this, EventArgs.Empty);
            }
        }

        protected void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }
    }
}