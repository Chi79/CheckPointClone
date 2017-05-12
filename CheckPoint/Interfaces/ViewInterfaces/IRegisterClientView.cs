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

        bool LoginButtonVisible {set; }

        bool MessagePanelVisible { set; }

        bool YesButtonVisible { set; }

        bool NoButtonVisible { set; }

        bool ContinueButtonVisible { set; }

        bool RegisterButtonVisible { set; }

        void RedirectBackToHomePage();
        void RedirectToLogin();

        event EventHandler<EventArgs> RegisterNewClient;
        event EventHandler<EventArgs> BackToHomePageClicked;
        event EventHandler<EventArgs> GoToLoginClicked;

        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> ContinueButtonClicked;
    }
}
