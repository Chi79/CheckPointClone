using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderCommon.ViewInterfaces
{
    public interface IHostControlView : IView
    {

        IEnumerable<object> HostAppointmentsDataSource { set; }
        string Message { set; }

        string Username { get; set; }

        string SelectedAppointmentName { get; }
        string SelectedAppointmentId { get; }
        bool IsSelectedAppointmentObligatory { get; }

        event EventHandler<EventArgs> StartAppointment;
        event EventHandler<EventArgs> LogOut;
        event EventHandler<EventArgs> SelectAppointment;

        void RedirectToTerminalView();
        void RedirectToLoginView();
    }
}
