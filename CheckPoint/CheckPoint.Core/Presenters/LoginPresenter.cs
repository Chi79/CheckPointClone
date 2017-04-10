using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.Enums;


namespace CheckPointPresenters.Presenters
{

    public class LoginPresenter : PresenterBase
    {

        private readonly ILoginView _view;
        private readonly ILoginModel _model;

        private ClientType _clientType;

        public LoginPresenter(ILoginView loginView, ILoginModel loginModel)
        {

            this._view = loginView;
            this._model = loginModel;

            _view.Login += _loginView_OnLoginButtonClicked;

        }

        public override void FirstTimeInit()
        {

        }

        private void _loginView_OnLoginButtonClicked(object sender, EventArgs e)
        {

            AttemptToLogin();

        }

        private void AttemptToLogin()
        {

            string username = _view.Username;
            string password = _view.Password;

            _model.AttemptLogin(username, password);


            bool loginAttemptSuccessful = _model.GetLoginAttemptStatus();
            if (loginAttemptSuccessful)
            {

                _model.StoreLoggedInClientToSession(username);

                _clientType = (ClientType)_model.GetClientType();

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

    } 
}
