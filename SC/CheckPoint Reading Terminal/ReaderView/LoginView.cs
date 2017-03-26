using ReaderCommon.ViewInterfaces;
using ReaderPresenters.Base;
using ReaderPresenters.Framework;
using ReaderPresenters.Presenters;
using System;
using System.Windows.Forms;

namespace ReaderViews
{
    public partial class LoginView : ViewBase<LoginPresenter>, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public string Username
        {
            get{ return txtUsername.Text; }
            set {txtUsername.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }
        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public string LoginButtonText
        {
            set { btnLogin.Text = value; }
        }

        public bool LoginButtonEnabledState
        {
            set { btnLogin.Enabled = value; }
        }

        public event EventHandler<EventArgs> Login;
        public event EventHandler<EventArgs> ClosePreviousView;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(Login != null)
            {
                Login(this, EventArgs.Empty);
               
            }
        } 

        public void ShowView()
        {
            this.Show();
        }

        public void HideView()
        {
            this.Hide();
        }

        public void RedirectToHostControlView()
        {
            this.Hide();
            var _hostControlView = IOC.Container.GetInstance<IHostControlView>();
            _hostControlView.Username = this.Username;
            _hostControlView.ClosePreviousView += (s, e) => this.Close(); //closes current view when new view is created.
            _hostControlView.ShowView();           
        }
    }
}
