using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ValidationInterfaces;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;


namespace CheckPointModel.Validation
{
    public class RegisterClientValidator : Validator<ClientDTO>, IRegisterClientValidator<ClientDTO>
    {
        private List<string> propertyList;
        public List<string> FillPropertyList(ClientDTO client)
        {
           propertyList = ProperiesToStringListConverter<ClientDTO>.ConvertPropertiesToStringList(client);
           return propertyList;
        }
        public override void CheckForBrokenRules(ClientDTO client)
        {
            if (!ValidateStringInput.AreStringsValid(propertyList))
            {
                base.AddBrokenRule("One or more field is empty! Please fill in all fields. ");
            }
            if (client.Password.Length < 6)
            {
                base.AddBrokenRule("Password must be 6 characters or more. ");
            }
            if (!client.Email.Contains("@"))
            {
                base.AddBrokenRule("Email not valid - must contain be in the form 'xxx@xxx.xxx' ");
            }
            if (client.ClientType < 0 || client.ClientType > 1)
            {
                base.AddBrokenRule("ClientType must be either 0 or 1. ");
            }
            if (client.PhoneNumber.Length < 8)
            {
                base.AddBrokenRule("PhoneNumber must be 8 digits or more. ");
            }
            if (client.PostalCode.Length < 4)
            {
                base.AddBrokenRule("PostalCode must be 4 digits. ");
            }
        }
    }
}
