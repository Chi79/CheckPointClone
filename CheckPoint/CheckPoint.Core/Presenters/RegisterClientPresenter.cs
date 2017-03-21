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
            CreateClientDTOFromInput();

            CheckClientIsValid();
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
            _view.Message = string.Empty;

            var validationErrorMessage = _clientDTO.GetBrokenBusinessRules().ToList();

            foreach (string message in validationErrorMessage)
            {
                _view.Message += message;
            }
        }
 

        private void AttemptSaveToDb()
        {
            SaveResult saveResult = _uOW.Complete();
            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _view.Message = "Registraion Failed: " + saveResult.ErrorMessage;
            }
            else
            {
                _view.Message = "New Registration Succesfull!";
                _view.LoginButtonVisible = true;
            }
        }
    }
}
