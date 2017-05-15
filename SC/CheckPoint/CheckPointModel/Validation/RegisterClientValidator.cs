using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ValidationInterfaces;
using CheckPointModel.Utilities;
using CheckPointCommon.DTOInterfaces;


namespace CheckPointModel.Validation
{
    public class RegisterClientValidator : Validator<IClientDTO>, IRegisterClientValidator<IClientDTO>
    {
        public List<string> FillPropertyList(IClientDTO client)
        {
           return ProperiesToStringListConverter<IClientDTO>.ConvertPropertiesToStringList(client);
        }
        public override void CheckForBrokenRules(IClientDTO client)
        {
            var propertyList = FillPropertyList(client);

            if (!ValidateStringInput.AreStringsValid(propertyList))
            {
                base.AddBrokenRule("<br /><br />One or more field is empty! Please fill in all fields. <br />");
            }
            if (client.Password.Length < 6 || client.Password.Length > 20 )
            {
                base.AddBrokenRule("Password must be no less than 6 and no more than 20 characters in length.<br /> ");
            }
              
            if (!client.Email.Contains("@"))
            {
                base.AddBrokenRule("Email not valid - must contain be in the form 'xxx@xxx.xxx'<br /> ");
            }
            if (client.ClientType < 0 || client.ClientType > 1)
            {
                base.AddBrokenRule("ClientType must be either 0 or 1. ");
            }
            try
            {
                int phoneNumber = Convert.ToInt32(client.PhoneNumber);
            }
            catch
            {
                base.AddBrokenRule("Phone number is invalid!<br />");
            }
            if (client.PhoneNumber.Length < 8 || client.PhoneNumber.Length > 8)
            {
                base.AddBrokenRule("PhoneNumber must be 8 digits.<br /> ");
            }
           
            if (client.PostalCode.Length > 4)
            {
                base.AddBrokenRule("PostalCode must be 4 digits or less.<br /> ");
            }
            try
            {
                int postcodeInteger = Convert.ToInt32(client.PostalCode);
            }
            catch
            {
                base.AddBrokenRule("Postal Code must be an valid integer value!<br />");
            }
        }
    }
}
