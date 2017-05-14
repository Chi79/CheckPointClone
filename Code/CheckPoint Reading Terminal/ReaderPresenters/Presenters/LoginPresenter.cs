using ReaderCommon.DataAccessInterfaces;
using ReaderCommon.ModelInterfaces;
using ReaderCommon.ViewInterfaces;
using ReaderPresenters.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaderPresenters.Presenters
{
    public class LoginPresenter : PresenterBase
    {
        private readonly ILoginView _loginView;
        private readonly ILoginModel _loginModel;
        private readonly IDataAccess _dataAccess;

        private string _username;
        private string _password;

        public LoginPresenter(ILoginView loginView, ILoginModel loginModel, IDataAccess dataAccess)
        {
            _loginView = loginView;
            _loginModel = loginModel;
            _dataAccess = dataAccess;

            _loginView.Login += _loginView_OnLoginButtonClicked;
            _loginView.CloseApplication += OnCloseApplicationButtonClicked;
        }

        private void OnCloseApplicationButtonClicked(object sender, EventArgs e)
        {
            _loginView.CloseReadingTerminalApplication();
        }

        private async void _loginView_OnLoginButtonClicked(object sender, EventArgs e)
        {
            _username = _loginView.Username;
            _password = _loginView.Password;


            _loginView.LoginButtonText = "Logging in...";
            _loginView.LoginButtonEnabledState = false;

            var isLoginSuccessful = await _dataAccess.AttemptLogin(_username, _password);
            

            if (isLoginSuccessful)
            {
                _loginView.Message = "Login Successful!";
                _loginView.RedirectToHostControlView();
            }  
            else
            {
                _loginView.Message = "Login Failed. Please check login info";
                _loginView.LoginButtonText = "Log In";
                _loginView.LoginButtonEnabledState = true;

            }              
                
            

        }

       
    }
}
