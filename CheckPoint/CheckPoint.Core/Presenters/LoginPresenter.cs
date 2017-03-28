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
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class LoginPresenter : PresenterBase
    {
        private readonly ILoginView _view;
        private readonly ILoginModel _model;
        private readonly IUnitOfWork _uOW;
        private readonly ISessionService _sessionService;

        private ClientType _clientType;

        public LoginPresenter(ILoginView loginView, ILoginModel loginModel, IUnitOfWork unitOfWork, ISessionService sessionService)
        {
            this._view = loginView;
            this._model = loginModel;
            this._uOW = unitOfWork;
            this._sessionService = sessionService;

            _view.Login += _loginView_OnLoginButtonClicked;
        }

        public override void FirstTimeInit()
        {
            ResetAddAppointmentStatus();
        }

        private void _loginView_OnLoginButtonClicked(object sender, EventArgs e)
        {
            AttemptToLogin();
        }

        private void AttemptToLogin()
        {
            string username = _view.Username;
            string password = _view.Password;

            LoginResult loginResult = _uOW.CLIENTs.Login(username, password);

            bool loginAttemptSuccessful = loginResult.Success;
            if(loginAttemptSuccessful)
            {
                _sessionService.LoggedInClient = username;
    
                _clientType = (ClientType)loginResult.ClientType;
                CheckClientType();
            }
            else
            {
                _view.Message = "Login Failed!";
            }
        }

        private void CheckClientType()
        {
            switch (_clientType)
            {
                case ClientType.User:
                    _view.RedirectToUserHomePage();
                    break;
                case ClientType.Host:
                    _view.RedirectToHostHomePage();
                    break;
            }
        } 
        private void ResetAddAppointmentStatus()
        {

            _sessionService.AddingAppointmentToCourseStatus = false;
        }  
    } 
}
