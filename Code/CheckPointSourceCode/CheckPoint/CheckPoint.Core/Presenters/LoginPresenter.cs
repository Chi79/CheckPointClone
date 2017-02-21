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
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class LoginPresenter : PresenterBase
    {
        private readonly ILoginView _loginView;
        private readonly ILoginModel _loginModel;
        private readonly IUnitOfWork _unitOfWork;

        private List<string> _LoginData = new List<string>();
        private ClientType _clientType;

        private string _username;
        private string _password;

        public LoginPresenter(ILoginView loginView, ILoginModel loginModel, IUnitOfWork unitOfWork)
        {
            this._loginView = loginView;
            this._loginModel = loginModel;
            this._unitOfWork = unitOfWork;

            _loginView.Login += _loginView_OnLoginButtonClicked;
        }
        private void _loginView_OnLoginButtonClicked(object sender, EventArgs e)
        {
            _username = _loginView.Username;
            _password = _loginView.Password;

            _LoginData.Add(_username);
            _LoginData.Add(_password);

            if(ValidateLoginData())
            {
                AttemptToLogin();
            }
        }

        private bool ValidateLoginData()
        {
            bool allFieldsValid = _loginModel.LoginDataIsValid(_LoginData);
            if (allFieldsValid)
            {
                return true;
            } 
            _loginView.Message = "Please fill out all fields.";
            return false;     
        }

        private void AttemptToLogin()
        {
            int clientType;
            bool loginAttemptSuccessful = _unitOfWork.CLIENTs.Login(_username, _password, out clientType);
            if (loginAttemptSuccessful)
            {
                _clientType = (ClientType)clientType;
                _loginView.Message = "Login Succesfull!";


                CheckClientType();
            }
            else
            {
                _loginView.Message = "Login Failed!";
            }
        }
        private void CheckClientType()
        {
            switch(_clientType)
            {
                case ClientType.User:
                    _loginView.Message = "Logged in as User.";
                    _loginView.RedirectToUserHomePage();
                    break;
                case ClientType.Host:
                    _loginView.Message = "Logged in as Host.";
                    break;
            }
        }   
    } 
}
