using ReaderCommon.ViewInterfaces;
using ReaderPresenters.Base;
using ReaderPresenters.Framework;
using ReaderPresenters.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderViews
{
    public partial class TerminalView : ViewBase<TerminalPresenter>, ITerminalView
    {
        public TerminalView()
        {
            InitializeComponent();
        }

        public string ActiveAppointmentName
        {
            set { txtActiveAppointmentName.Text = value; }
        }
        public string ActiveAppointmentId { get; set; }

        public bool ActiveAppointmentObligatoryStatus { get; set; }

        public string Username { get; set; }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public bool ShowEndAppointmentPanel
        {
            get { return panelConfirmEndAppointment.Visible; }
            set { panelConfirmEndAppointment.Visible = value; }
        }

        public string RegistrationResultColor
        {
            set { txtRegistrationFeedback.BackColor = Color.FromName(value); }
        }

        public string RegistrationResultMessage
        {
            set { txtRegistrationFeedback.Text = value; }
        }

        public event EventHandler<EventArgs> ClosePreviousView;
        public event EventHandler<EventArgs> EndAppointment;
        public event EventHandler<EventArgs> ToggleEndAppointmentPanel;

        public void DisplayRegistrationResult(string resultMessage, string resultColor)
        {
            this.Invoke((MethodInvoker)delegate //invoke cross-thread request
            {

                txtRegistrationFeedback.Text = resultMessage;
                txtRegistrationFeedback.BackColor = Color.FromName(resultColor);

            });
        }

        public void HideView()
        {
            this.Hide();
        }

        public void ShowView()
        {
            this.Show();
        }

        public void RedirectToHostControlView()
        {
            this.Hide();
            var _hostControlView = IOC.Container.GetInstance<IHostControlView>();
            _hostControlView.Username = this.Username;
            _hostControlView.ClosePreviousView += (s, e) => this.Close(); //closes current view when new view is created.
            _hostControlView.ShowView();
        }

        private void btnToggleEndAppointmentPanel_Click(object sender, EventArgs e)
        {
            if(ToggleEndAppointmentPanel != null)
            {
                ToggleEndAppointmentPanel(this, EventArgs.Empty);
            }
        }

        private void btnEndAppointment_Click(object sender, EventArgs e)
        {
            if(EndAppointment != null)
            {
                EndAppointment(this, EventArgs.Empty);
            }
        }

    }
}

