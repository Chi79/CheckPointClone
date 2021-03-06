﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.Utilities;
using CheckPointCommon.Structs;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.Enums;

namespace CheckPointModel.Models
{
    public class LoginModel : ILoginModel
    {

        private IUnitOfWork _uOW;
        private ISessionService _sessionService;

        private LoginResult loginResult;

        public LoginModel(IUnitOfWork uOW, ISessionService sessionService)
        {

            _uOW = uOW;
            _sessionService = sessionService;

        }

        public bool LoginDataIsValid(List<string> loginData)
        {

            return ValidateStringInput.AreStringsValid(loginData);

        }

        public void AttemptLogin(string username, string password)
        {

            loginResult = _uOW.CLIENTs.Login(username, password);

        }

        public bool GetLoginAttemptStatus()
        {

            return loginResult.Success;

        }

        public int GetClientType()
        {

            return loginResult.ClientType;

        }      

        public void StoreLoggedInClientToSession(string username)
        {

            _sessionService.LoggedInClient = username;

        }


        public void ResetSessionState()
        {

            _sessionService.SessionAppointmentId = -1;
            _sessionService.SessionCourseId = -1;
            _sessionService.AppointmentDeletedFromCourseStatus = false;
            _sessionService.NewAppointmentAddedToCourseStatus = false;
            _sessionService.UpdatedCourseStatus = false;
            _sessionService.DeletedCourseStatus = false;
            _sessionService.SavedChangesStatus = false;
           
        }

        private string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;

        }

        private string fetchLoggedInClientTagId()
        {

            string client = GetLoggedInClient();

            return _uOW.Client_TagIds.GetClientTagId(client);             
  
        }

        public void StoreClientTagIdToSession()
        {

            string clientTagId = fetchLoggedInClientTagId();

            _sessionService.ClientTagId = clientTagId;

        }

    }
}
