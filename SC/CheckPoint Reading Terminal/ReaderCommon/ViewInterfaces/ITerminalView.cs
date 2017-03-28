using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderCommon.ViewInterfaces
{
    public interface ITerminalView : IView
    {
        event EventHandler<EventArgs> EndAppointment;
        event EventHandler<EventArgs> ToggleEndAppointmentPanel;
        string ActiveAppointmentName { set; }
        string ActiveAppointmentId { get; set; }
        bool ActiveAppointmentObligatoryStatus { get; set; }
        bool ShowEndAppointmentPanel { get; set; }

        string RegistrationResultMessage { set; }
        string RegistrationResultColor { set; }

        string Username { get; set; }
        string Password { get; }

        string Message { set; }

        void RedirectToHostControlView();

        void DisplayRegistrationResult(string resultMessage, string resultColor);
    }

}
