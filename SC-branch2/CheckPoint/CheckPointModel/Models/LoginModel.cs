using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.Utilities;


namespace CheckPointModel.Models
{
    public class LoginModel : ILoginModel
    {
        public bool LoginDataIsValid(List<string> loginData)
        {
            return ValidateStringInput.AreStringsValid(loginData);
        }
    }
}
