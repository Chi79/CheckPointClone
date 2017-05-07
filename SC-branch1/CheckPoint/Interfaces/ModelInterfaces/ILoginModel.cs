using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckPointCommon.ModelInterfaces
{
    public interface ILoginModel 
    {
        bool LoginDataIsValid(List<string> loginData);

        void AttemptLogin(string username, string password);

        bool GetLoginAttemptStatus();

        int GetClientType();

        void ResetSessionState();

        void StoreLoggedInClientToSession(string username);

        void StoreClientTagIdToSession();

    }
}
