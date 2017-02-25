using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointModel.Entities;
using CheckPointDataTables.Tables;
using CheckPointCommon.Structs;

namespace CheckPointPresenters.Presenters
{
    public class RegisterClientPresenter : PresenterBase
    {
        private readonly IRegisterClientModel<CLIENT, ClientModel> _model;
        private readonly IRegisterClientView _view;
        private readonly IUnitOfWork _uOW;

        private ClientModel _clientModel = new ClientModel(); 
        private CLIENT _newClient;
        private string _errorMessage = null;

        private List<string> validationErrorMessage;

        public RegisterClientPresenter(IRegisterClientModel<CLIENT, ClientModel> registerClientModel, 
                                       IRegisterClientView registerClientView, IUnitOfWork unitOfWork)

        {
            _model = registerClientModel;
            _view = registerClientView;
            _uOW = unitOfWork;
  
            _view.RegisterNewClient += RegisterNewClientButtonCLicked;
      
        }

        private void RegisterNewClientButtonCLicked(object sender, EventArgs e)
        {
            CreateClientModelFromInput();
            _clientModel.FillPropertyList(_clientModel);

            bool ClientDataIsValid = ClientToRegisterIsValid();
            if (ClientDataIsValid)
            {
                _newClient = _model.ConvertClientModelToClient(_clientModel);
                SaveClientToDatabase(_newClient);
            }    
        }
        private void CreateClientModelFromInput()
        {
            _clientModel.UserName = _view.UserName;
            _clientModel.FirstName = _view.Firstname;
            _clientModel.LastName = _view.LastName;
            _clientModel.Email = _view.Email;
            _clientModel.Address = _view.StreetAddress;
            _clientModel.PostalCode = _view.PostalCode;
            _clientModel.PhoneNumber = _view.PhoneNumber;
            _clientModel.Password = _view.Password;
            _clientModel.ClientType = _view.ClientType;
        }
        private void SaveClientToDatabase(CLIENT newClient)
        {
            _uOW.CLIENTs.Add(newClient);
            bool saveCompleted = AttemptSaveToDb();
            if (saveCompleted)
            {
                _view.Message = "New Registration Succesfull!";
            }
            else
            {
                _view.Message = "Registraion Failed: " + _errorMessage;
            }
        
        }
        private bool ClientToRegisterIsValid()
        {
            bool clientFieldsAreValid = _clientModel.IsValid(_clientModel);
            if (clientFieldsAreValid)
            {
                _newClient = _model.ConvertClientModelToClient(_clientModel);
                return true;
            }
            else
            {
                validationErrorMessage = _clientModel.GetBrokenBusinessRules().ToList();
                DisplayValidationMessage();
                return false;
            }
        }
        private void DisplayValidationMessage()
        {
            _view.Message = string.Empty;

            foreach (string message in validationErrorMessage)
            {
                _view.Message += message;
            }
        }
 
        private bool AttemptSaveToDb()
        {
            SaveResult saveResult = _uOW.Complete();
            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _errorMessage = saveResult.ErrorMessage;
                return false;
            }
            return true;
        }
    }
}
