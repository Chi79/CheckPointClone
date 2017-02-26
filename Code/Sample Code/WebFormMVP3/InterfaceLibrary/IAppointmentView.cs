using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    /// <summary>
    /// Interface which integrates the View with the Model
    /// </summary>
    public interface IAppointmentView
    {
        string AppointmentName { get; set; }
        string Priority { get; set; }
        string StartDate { get; set; }
        string DueDate { get; set; }
        string CompletionDate { get; set; }
        bool Completed { get; set; }
        bool NextButtonVisible { set; }
        bool PreviousButtonVisible { set; }
        bool SaveButtonVisible { set; }
        bool NewButtonVisible { set; }
        bool YesButtonVisible { set; }
        bool NoButtonVisible { set; }

        // messages/communication
        /// <summary>
        /// StatusChange is a simple message that the View can choose to ignore. The message is printed to a label.
        /// 
        /// 'isDirty' bool can be set by the Presenter or the View.  The View sets it to 'true' whenever one of the controls
        /// values changes.  The Presenter sets it to 'false' whenever an appointment is saved or a new one loaded.
        /// </summary>
        string StatusChange { set; }
        bool isDirty { get; set; }

        void Show();
        /// <summary>
        /// Interface events for the View to communicate to Presenter
        /// </summary>
        event EventHandler<EventArgs> SaveAppointment;
        event EventHandler<EventArgs> NewAppointment;
        event EventHandler<EventArgs> PreviousAppointment;
        event EventHandler<EventArgs> NextAppointment;
        event EventHandler<EventArgs> YesButtonClick;
        event EventHandler<EventArgs> NoButtonClick;
    }
}
