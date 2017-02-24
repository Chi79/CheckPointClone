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
        private readonly IRegisterClientModel<CLIENT, ClientModel> _registerClientModel;
        private readonly IRegisterClientView _registerClientView;
        private readonly IUnitOfWork _unitOfWork;

        private ClientModel _clientModel = new ClientModel(); 
        private CLIENT _newClient;
        private string _errorMessage = null;

        private List<string> validationErrorMessage;

        public RegisterClientPresenter(IRegisterClientModel<CLIENT, ClientModel> registerClientModel, IRegisterClientView registerClientView, IUnitOfWork unitOfWork)
        {
            _registerClientModel = registerClientModel;
            _registerClientView = registerClientView;
            _unitOfWork = unitOfWork;
  
            _registerClientView.RegisterNewClient += RegisterNewClientButtonCLicked;
      
        }

        private void RegisterNewClientButtonCLicked(object sender, EventArgs e)
        {
            CreateClientModelFromInput();
            _clientModel.FillPropertyList(_clientModel);

            bool ClientDataIsValid = ClientToRegisterIsValid();
            if (ClientDataIsValid)
            {
                _newClient = _registerClientModel.ConvertClientModelToClient(_clientModel);
                SaveClientToDatabase(_newClient);
            }    
        }
        private void CreateClientModelFromInput()
        {
            _clientModel.UserName = _registerClientView.UserName;
            _clientModel.FirstName = _registerClientView.Firstname;
            _clientModel.LastName = _registerClientView.LastName;
            _clientModel.Email = _registerClientView.Email;
            _clientModel.StreetAddress = _registerClientView.StreetAddress;
            _clientModel.PostalCode = _registerClientView.PostalCode;
            _clientModel.PhoneNumber = _registerClientView.PhoneNumber;
            _clientModel.Password = _registerClientView.Password;
            _clientModel.ClientType = _registerClientView.ClientType;
        }
        private void SaveClientToDatabase(CLIENT newClient)
        {
            _unitOfWork.CLIENTs.Add(newClient);
            bool saveCompleted = AttemptSaveToDb();
            if (saveCompleted)
            {
                _registerClientView.Message = "New Registration Succesfull!";
            }
            else
            {
                _registerClientView.Message = "Registraion Failed: " + _errorMessage;
            }
        
        }
        private bool ClientToRegisterIsValid()
        {
            bool clientFieldsAreValid = _clientModel.IsValid(_clientModel);
            if (clientFieldsAreValid)
            {
                _newClient = _registerClientModel.ConvertClientModelToClient(_clientModel);
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
            _registerClientView.Message = string.Empty;

            foreach (string message in validationErrorMessage)
            {
                _registerClientView.Message += message;
            }
        }
        //private bool AttemptSaveToDb()
        //{
        //    string errorMessage;
        //    bool savedToDb = (_unitOfWork.Complete(out errorMessage) > 0);
        //    if (!savedToDb)
        //    {
        //        _errorMessage = errorMessage;
        //        return false;
        //    }
        //    return true;
        //}
        private bool AttemptSaveToDb()
        {
            SaveResult saveResult = _unitOfWork.myComplete();
            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _errorMessage = saveResult.ErrorMessage;
                return false;
            }
            return true;

            //string errorMessage;
            //bool savedToDb = (_unitOfWork.Complete(out errorMessage) > 0);
            //if (!savedToDb)
            //{
            //    _errorMessage = errorMessage;
            //    return false;
            //}
            //return true;
        }
    }
}
