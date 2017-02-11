using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassiveViewMVPmodeltest
{
    public partial class frmAppointmentView : Form, IAppointmentView  
        //The View implements the Interface.
        //Importantly, there is nothing in the View which ties it to the Presenter or the Model. They are not
        //referenced at all. All communication with the Presenter happens indirectly through events. There is no 
        //communication with the Model at all. The only methods ever called relate only to UI tasks.
    {   
        #region View Properties to set/get and events for Presenter to subscribe to.
        public string AppointmentName
        {
            get { return txtAppointment.Text; }
            set { txtAppointment.Text = value; }
        }
        public string Priority
        {
            get { return cboPriority.Text; }
            set { cboPriority.Text = value; }
        }
        public string StartDate
        {
            get { return txtStartDate.Text; }
            set
            {
                if (value == null) txtStartDate.Text = string.Empty;
                else txtStartDate.Text = value;
            }
        }
        public string DueDate
        {
            get { return txtDueDate.Text; }
            set
            {
                if (value == null) txtDueDate.Text = string.Empty;
                else txtDueDate.Text = value;
            }
        }
        public string CompletionDate
        {
            get { return txtCompletionDate.Text; }
            set
            {
                if (value == null) txtCompletionDate.Text = string.Empty;
                else txtCompletionDate.Text = value;
            }
        }
        public bool Completed
        {
            get { return chkCompleted.Checked; }
            set { chkCompleted.Checked = value; }
        }
        public bool isDirty { get; set; }

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
        public event EventHandler<EventArgs> PreviousAppointment;
        public event EventHandler<EventArgs> SaveAppointment;
        public event EventHandler<EventArgs> YesButtonClick;
        public event EventHandler<EventArgs> NoButtonClick;
        #endregion
        public frmAppointmentView()
        {
            InitializeComponent();
        }
        #region Here we set up the events to fire on various interactions with user controls.  
        private void frmAppointmentView_Load_1(object sender, EventArgs e)
        {
            this.isDirty = false;
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveAppointment != null)
            {
                SaveAppointment(this, EventArgs.Empty);
            }
        }
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            if (NewAppointment != null)
            {
                NewAppointment(this, EventArgs.Empty);
            }
        }
        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (PreviousAppointment != null)
            {
                PreviousAppointment(this, EventArgs.Empty);
            }
        }
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (NextAppointment != null)
            {
                NextAppointment(this, EventArgs.Empty);
            }
        }
        private void btnYes_Click_1(object sender, EventArgs e)
        {
            if (YesButtonClick != null)
            {
                YesButtonClick(this, EventArgs.Empty);
            }
        }
        private void btnNo_Click_1(object sender, EventArgs e)
        {
            if (NoButtonClick != null)
            {
                NoButtonClick(this, EventArgs.Empty);
            }
        }
        private void txtAppointment_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }
        private void cboPriority_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.isDirty = true;
        }
        private void txtStartDate_TextChanged_1(object sender, EventArgs e)
        {
            this.isDirty = true;
        }
        private void txtDueDate_TextChanged_1(object sender, EventArgs e)
        {
            this.isDirty = true;
        }
        private void txtCompletionDate_TextChanged_1(object sender, EventArgs e)
        {
            this.isDirty = true;
        }
        private void chkCompleted_CheckedChanged_1(object sender, EventArgs e)
        {
            this.isDirty = true;
        }
        #endregion
    }
}
