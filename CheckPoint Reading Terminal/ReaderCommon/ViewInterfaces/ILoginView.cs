using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderCommon.ViewInterfaces
{
    public interface ILoginView : IView
    {
        string Username { get; }
        string Password { get; }
        string Message { set; }

        string LoginButtonText { set; }

        bool LoginButtonEnabledState { set; }
        
        event EventHandler<EventArgs> Login;

        void RedirectToHostControlView();
    }
}
