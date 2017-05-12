using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointModel.DTOs;
using CheckPointDataTables.Tables;
using CheckPointCommon.Structs;

namespace CheckPointPresenters.Presenters
{
    public class RegisterClientPresenter : PresenterBase
    {

        private readonly IRegisterClientModel _model;
        private readonly IRegisterClientView _view;
        private readonly IUnitOfWork _uOW;

        private ClientDTO _clientDTO = new ClientDTO(); 

        public RegisterClientPresenter(IRegisterClientModel registerClientModel,
                                       IRegisterClientView registerClientView, 
                                       IUnitOfWork unitOfWork)

        {

            _model = registerClientModel;
            _view = registerClientView;
            _uOW = unitOfWork;

  
            _view.RegisterNewClient += RegisterNewClientButtonClicked;
            _view.BackToHomePageClicked += OnBackToHomePageClicked;
            _view.GoToLoginClicked += OnGoToLoginClicked;

            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
            _view.ContinueButtonClicked += OnContinueButtonClicked;
      
        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {

            HideMessagePanel();

            ShowRegisterButton();

        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {

            HideMessagePanel();

            ShowRegisterButton();

        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {

            HideYesNoButtons();

            CreateClientDTOFromInput();

            CheckClientIsValid();

        }

        private void OnGoToLoginClicked(object sender, EventArgs e)
        {

            _view.RedirectToLogin();

        }

        private void OnBackToHomePageClicked(object sender, EventArgs e)
        {

            _view.RedirectBackToHomePage();

        }

        public override void FirstTimeInit()
        {
            
        }

        private void RegisterNewClientButtonClicked(object sender, EventArgs e)
        {

            HideRegisterButton();

            HideContinueButton();

            ShowMessagePanel();

            ShowYesNoButtons();

            _view.Message = "<br /> You are about to register a new account! <br /> <br /> Do you wish to proceed? <br /> <br />";

            
            //CreateClientDTOFromInput();

            //CheckClientIsValid();
        }

        private void CreateClientDTOFromInput()
        {

            _clientDTO.UserName = _view.UserName;
            _clientDTO.FirstName = _view.Firstname;
            _clientDTO.LastName = _view.LastName;
            _clientDTO.Email = _view.Email;
            _clientDTO.Address = _view.StreetAddress;
            _clientDTO.PostalCode = _view.PostalCode;
            _clientDTO.PhoneNumber = _view.PhoneNumber;
            _clientDTO.Password = _view.Password;
            _clientDTO.ClientType = _view.ClientType;

        }

        private void SaveClientToDatabase(CLIENT newClient)
        {

            _uOW.CLIENTs.Add(newClient);

            AttemptSaveToDb(); 

        }


        private void CheckClientIsValid()
        {

            bool clientFieldsAreValid = _clientDTO.IsValid(_clientDTO);
            if (!clientFieldsAreValid)
            {
                DisplayValidationMessage();
            }
            else
            {
                var _newClient = _model.ConvertClientDTOToClient(_clientDTO) as CLIENT;
                SaveClientToDatabase(_newClient);
            }

        }

        private void DisplayValidationMessage()
        {


            ShowMessagePanel();

            _view.Message = string.Empty;

            var validationErrorMessage = _clientDTO.GetBrokenBusinessRules().ToList();

            foreach (string message in validationErrorMessage)
            {
                _view.Message += message;
            }

            ShowContinueButton();

        }
 

        private void AttemptSaveToDb()
        {

            ShowMessagePanel();

            SaveResult saveResult = _uOW.Complete();
            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {

                _view.Message = "<br />Sorry! Registraion Failed: <br /><br /> " + saveResult.ErrorMessage;

                ShowContinueButton();
            }
            else
            {
                _view.Message = "<br />New Registration Succesfull!  <br /><br /> Please continue to login to your new account.. <br /> <br /> <br />";
                _view.LoginButtonVisible = true;

                ShowLoginButton();
            }

          

        }


        private void ShowYesNoButtons()
        {

            _view.YesButtonVisible = true;
            _view.NoButtonVisible = true;

        }

        private void HideYesNoButtons()
        {

            _view.YesButtonVisible = false;
            _view.NoButtonVisible = false;

        }

        private void ShowMessagePanel()
        {

            _view.MessagePanelVisible = true;

        }

        private void HideMessagePanel()
        {

            _view.MessagePanelVisible = false;

        }

        private void HideContinueButton()
        {

            _view.ContinueButtonVisible = false;

        }

        private void ShowContinueButton()
        {

            _view.ContinueButtonVisible = true;

        }

        private void HideLogInButton()
        {

            _view.LoginButtonVisible = false;

        }

        private void ShowLoginButton()
        {

            _view.LoginButtonVisible = true;

        }

        private void HideRegisterButton()
        {

            _view.RegisterButtonVisible = false;

        }

        private void ShowRegisterButton()
        {

            _view.RegisterButtonVisible = true;

        }
    }
}

