using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.Enums;
using CheckPointCommon.Structs;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class LoginPresenter : PresenterBase
    {
        private readonly ILoginView _view;
        private readonly ILoginModel _model;
        private readonly IUnitOfWork _uOW;

        private List<string> _LoginData = new List<string>();
        private ClientType _clientType;

        private string _username;
        private string _password;

        public LoginPresenter(ILoginView loginView, ILoginModel loginModel, IUnitOfWork unitOfWork)
        {
            this._view = loginView;
            this._model = loginModel;
            this._uOW = unitOfWork;

            _view.Login += _loginView_OnLoginButtonClicked;
        }
        private void _loginView_OnLoginButtonClicked(object sender, EventArgs e)
        {
            _username = _view.Username;
            _password = _view.Password;

            _LoginData.Add(_username);
            _LoginData.Add(_password);

            if(ValidateLoginData())
            {
                AttemptToLogin();
            }
        }

        private bool ValidateLoginData()
        {
            bool allFieldsValid = _model.LoginDataIsValid(_LoginData);
            if (allFieldsValid)
            {
                return true;
            } 
            _view.Message = "Please fill out all fields.";
            return false;     
        }

        private void AttemptToLogin()
        {
            LoginResult loginResult = _uOW.CLIENTs.Login(_username, _password);
            bool loginAttemptSuccessful = loginResult.Result;
            if(loginAttemptSuccessful)
            {
                _clientType = (ClientType)loginResult.ClientType;
                _view.Message = "Login Succesfull!";

                CheckClientType();
            }
            else
            {
                _view.Message = "Login Failed!";
            }
        }
        private void CheckClientType()
        {
            switch(_clientType)
            {
                case ClientType.User:
                    _view.Message = "Logged in as User.";
                    _view.RedirectToUserHomePage();
                    break;
                case ClientType.Host:
                    _view.Message = "Logged in as Host.";
                    break;
            }
        }   
    } 
}
