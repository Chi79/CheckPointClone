using ReaderCommon.ViewInterfaces;
using ReaderPresenters.Base;
using ReaderPresenters.Framework;
using ReaderPresenters.Presenters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReaderViews
{
    public partial class HostControlView : ViewBase<HostControlPresenter>, IHostControlView
    {

        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        public IEnumerable<object> HostAppointmentsDataSource
        {
            set { dgvHostAppointments.DataSource = value; }          
        }

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public string SelectedAppointmentName
        {
            get
            {
                 return dgvHostAppointments.SelectedCells[0].OwningRow.Cells[0].Value.ToString(); 
            }
        }

        public string SelectedAppointmentId
        {
            get { return dgvHostAppointments.SelectedCells[0].OwningRow.Cells[5].Value.ToString(); }
        }

        public bool IsSelectedAppointmentObligatory
        {
            get { return (bool)dgvHostAppointments.SelectedCells[0].OwningRow.Cells[6].Value; }
        }


        public HostControlView()
        {
            InitializeComponent();

        }

        public event EventHandler<EventArgs> StartAppointment;
        public event EventHandler<EventArgs> LogOut;
        public event EventHandler<EventArgs> ClosePreviousView;
        public event EventHandler<EventArgs> SelectAppointment;

        public void ShowView()
        {
            this.Show();
        }

        public void HideView()
        {
            this.Hide();
        }

        public void RedirectToTerminalView()
        {
            this.Hide();
            var _terminalView = IOC.Container.GetInstance<ITerminalView>();
            _terminalView.ClosePreviousView += (s, e) => this.Close(); //closes current view when new view is created.
            _terminalView.ActiveAppointmentName = this.SelectedAppointmentName;
            _terminalView.ActiveAppointmentId = this.SelectedAppointmentId;
            _terminalView.ActiveAppointmentObligatoryStatus = this.IsSelectedAppointmentObligatory;
            _terminalView.Username = this.Username;
            _terminalView.ShowView();
        }

        public void RedirectToLoginView()
        {
            this.Hide();
            var _terminalView = IOC.Container.GetInstance<ILoginView>();
            _terminalView.ClosePreviousView += (s, e) => this.Close(); 
            _terminalView.ShowView();
        }

        private void btnStartAppointment_Click(object sender, EventArgs e)
        {
            if(StartAppointment != null)
            {
                StartAppointment(this, EventArgs.Empty);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if(LogOut != null)
            {
                LogOut(this, EventArgs.Empty);
            }
        }


        private void dgvHostAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectAppointment != null)
            {
                SelectAppointment(this, e);
            }
        }

    }
}
