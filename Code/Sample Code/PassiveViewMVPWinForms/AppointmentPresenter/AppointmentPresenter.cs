using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCOLibrary;
using InterfaceLibrary;


namespace AppointmentsPresenter
{
    //The Presenter is the go-between for the View and Model.  It sets the properties in the View to be displayed and
    //Stores and Gets the data from the Model. It responds to events raised by the View.
    public class AppointmentPresenter
    {   
        private readonly IAppointmentView _view;                //references the View Interface
        private readonly IAppointmentModel<Appointment> _model; //references the Model Interface
        /// <summary>
        /// The List of Appointments is created and stored in the Model.  
        /// In reality we would be using a Database and not a List<>.
        /// </summary>
        private List<Appointment> appointments;

        //primitive maintenace of state:
        private int currentIndex = 0;
        private bool isNew = true;

        private string navigationstatus = "next";
        ///Presenter constuctor which allows us to pass in the View and Model as interfaces - exposing their events,
        /// methods and properties.    
        public AppointmentPresenter(IAppointmentView view, IAppointmentModel<Appointment> model)  //dependencies passed into contructor using program.cs
        {
            this._view = view;
            this._model = model;

            Initialize();
        }
        private void Initialize()
        {
            appointments = _model.CreateList();         //Creates and returns List of Appointments in the Model
                                                        //lets us manipulate the List that the Model creates.
            _view.SaveAppointment += Save_Appointment;  //Subscribe to the View events.
            _view.NewAppointment += New_Appointment;
            _view.PreviousAppointment += Previous_Appointment;
            _view.NextAppointment += Next_Appointment;
            _view.YesButtonClick += YesButtonClicked;
            _view.NoButtonClick += NoButtonClicked;

            BlankAppointment();
            _view.StatusChange = "Ready";
        }
        private void BlankAppointment()
        {
            _view.AppointmentName = string.Empty;
            _view.Priority = "Low";
            _view.StartDate = null;
            _view.DueDate = null;
            _view.CompletionDate = null;
            _view.Completed = false;
        }
        private void CreateNewAppointment()
        {
            BlankAppointment();
            this.isNew = true;
            _view.isDirty = false;
            currentIndex = appointments.Count;
            _view.StatusChange = "New Appointment";
            _view.SaveButtonVisible = true;
            _view.PreviousButtonVisible = true;
            _view.NextButtonVisible = false;
        }
        private void LoadAppointment(Appointment appointment)
        {
            _view.AppointmentName = appointment.AppointmentName;
            _view.Priority = appointment.Priority;
            _view.StartDate = appointment.StartDate;
            _view.DueDate = appointment.DueDate;
            _view.CompletionDate = appointment.CompletionDate;
            _view.Completed = appointment.Completed;
            _view.isDirty = false;
            this.isNew = false;
        }
        private void SetAppointmentProperties(Appointment appointment)
        {
            appointment.AppointmentName = _view.AppointmentName;
            appointment.Priority = _view.Priority;
            appointment.StartDate = _view.StartDate;
            appointment.DueDate = _view.DueDate;
            appointment.CompletionDate = _view.CompletionDate;
            appointment.Completed = _view.Completed;
        }
        private bool IsDataValid(Appointment appointment)
        {
            if (!_model.ValidateNullStrings(appointment))
            {
                _view.StatusChange = "Please complete all fields and dates in the Appointment descritpion!";
                return false;
            }
            else if (!_model.ValidateDates(appointment))
            {
                _view.StatusChange = "Date information invalid - Please enter a date mm/dd/yyyy";
                return false;
            }
            return true;
        }
        private void SaveAppointmentToModel(Appointment appointment)
        {
            if (this.isNew)
            {
                appointments.Add(appointment);
                this.isNew = false;
                currentIndex = appointments.Count - 1;
            }
            appointments[currentIndex] = appointment;
            _view.isDirty = false;
            _view.StatusChange = "Appointment Saved";
            _view.NewButtonVisible = true;
            LoadAppointment(appointments[currentIndex]);
        }
        private void ProceedToNextAppointment()
        {
            int appointmentsListUpperBound = (appointments.Count - 1);
            if (currentIndex < appointmentsListUpperBound)
            {
                currentIndex++;
                LoadAppointment(appointments[currentIndex]);
                _view.isDirty = false;
                _view.StatusChange = "Appointment:" + (currentIndex + 1);
            }
            else
            {
                EndOfIndexOrNoExistingAppointments();
                _view.NextButtonVisible = false;
            }
            _view.PreviousButtonVisible = true;
        }
        private void GoBackToPreviousAppointment()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                LoadAppointment(appointments[currentIndex]);
                _view.isDirty = false;
                _view.StatusChange = "Appointment:" + (currentIndex + 1);
            }
            else
            {
                EndOfIndexOrNoExistingAppointments();
            }
            _view.NextButtonVisible = true;
        }
        private void EndOfIndexOrNoExistingAppointments()
        {
            if (appointments.Count > 0)
            {
                LoadAppointment(appointments[currentIndex]);
            }
            _view.StatusChange = "End of Index - Appointment:" + (currentIndex + 1);
            _view.PreviousButtonVisible = false;
            _view.NextButtonVisible = true;
        }
        private void CheckNavigationStatus()
        {
            if (navigationstatus == "new")
            {
                CreateNewAppointment();
            }
            if (navigationstatus == "next")
            {
                ProceedToNextAppointment();
            }
            if (navigationstatus == "back")
            {
                GoBackToPreviousAppointment();
            }
        }
        #region Save_Appointment event response
        private void Save_Appointment(object sender, EventArgs e)
        {
            Appointment appointmentToSave = new Appointment();
            SetAppointmentProperties(appointmentToSave);
            bool canSave = true;
            canSave = IsDataValid(appointmentToSave);
            if (canSave)
            {
                _model.ParseAppointmentDates(appointmentToSave);
                SaveAppointmentToModel(appointmentToSave);
            }
        }
        #endregion
        #region New_Appointment event response
        private void New_Appointment(object sender, EventArgs e)
        {
            if (!_view.isDirty)
            {
                CreateNewAppointment();
            }
            else
            {
                _view.StatusChange = "Proceed to create a new appointment and discard changes ?";
                _view.YesButtonVisible = true;
                _view.NoButtonVisible = true;
                navigationstatus = "new";
            }
        }
        #endregion
        #region Previous_Appointment event response
        private void Previous_Appointment(object sender, EventArgs e)
        {
            if (!_view.isDirty)
            {
                GoBackToPreviousAppointment();
            }
            else
            {
                _view.StatusChange = "Go back to last appointment and discard changes ?";
                _view.YesButtonVisible = true;
                _view.NoButtonVisible = true;
                navigationstatus = "back";
            }
        }
        #endregion
        #region Next_Appointment event response
        private void Next_Appointment(object sender, EventArgs e)
        {
            if (!_view.isDirty)
            {
                ProceedToNextAppointment();
            }
            else
            {
                _view.StatusChange = "Proceed to next appointment and discard changes ?";
                _view.YesButtonVisible = true;
                _view.NoButtonVisible = true;
                navigationstatus = "next";
            }
        }
        #endregion
        #region YesButtonClicked event response
        private void YesButtonClicked(object sender, EventArgs e)
        {
            CheckNavigationStatus();
            _view.YesButtonVisible = false;
            _view.NoButtonVisible = false;
        }
        #endregion
        #region NoButtonCLicked event reponse
        private void NoButtonClicked(object sender, EventArgs e)
        {
            _view.YesButtonVisible = false;
            _view.NoButtonVisible = false;
            _view.StatusChange = "Ready";
        }
        #endregion
    }
}
