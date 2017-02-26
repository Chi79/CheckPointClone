using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IRegisterClientView
    {
        string UserName { get; }
        string Password { get; }
        int ClientType { get; }
        string Firstname { get; } 
        string LastName { get; }
        string Email { get; }
        string StreetAddress { get; }
        string PostalCode { get; }
        string PhoneNumber { get; }

        string Message { get; set; }

        event EventHandler<EventArgs> RegisterNewClient;
    }
}
