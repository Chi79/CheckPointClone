using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCOClassLibrary;
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

        //maintenace of state:

        private int ?currentIndex;

        //private string _navigationstatus;
        ///Presenter constuctor which allows us to pass in the View and Model as interfaces - exposing their events,
        /// methods and properties.    
        public AppointmentPresenter(IAppointmentView view, IAppointmentModel<Appointment> model)  //dependencies passed into contructor 
        {

            this._view = view;
            this._model = model;

            Initialize();
        }
        private void Initialize()
        {
            if (appointments == null)
            {
                appointments = _model.CreateList();  //Creates and returns List of Appointments in the Model
            }                                        //lets us manipulate the List that the Model creates.
            if (currentIndex == null)
            {
                currentIndex = _model.indexcounter;
            }
                                                                                       
            _view.SaveAppointment += Save_Appointment;  //Subscribe to the View events.
            _view.NewAppointment += New_Appointment;
            _view.PreviousAppointment += Previous_Appointment;
            _view.NextAppointment += Next_Appointment;
            _view.YesButtonClick += YesButtonClicked;
            _view.NoButtonClick += NoButtonClicked;
            
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
            _view.isDirty = false;
            _model.indexcounter = appointments.Count;
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
            if(_model.indexcounter == appointments.Count)
            {
                appointments.Add(appointment);
                _model.indexcounter = appointments.Count - 1;
            }
            appointments[_model.indexcounter] = appointment;
            _view.isDirty = false;
            _view.StatusChange = "Appointment Saved";
            _view.NewButtonVisible = true;
            LoadAppointment(appointments[_model.indexcounter]);
        }
        private void ProceedToNextAppointment()
        {
            int appointmentsListUpperBound = (appointments.Count - 1);
            if (_model.indexcounter < appointmentsListUpperBound)
            {
                _model.indexcounter++;
                LoadAppointment(appointments[_model.indexcounter]);
                _view.isDirty = false;
                _view.StatusChange = "Appointment:" + (_model.indexcounter + 1);
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
            if (_model.indexcounter > 0)
            {
                _model.indexcounter--;
                LoadAppointment(appointments[_model.indexcounter]);
                _view.isDirty = false;
                _view.StatusChange = "Appointment:" + (_model.indexcounter+ 1);
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
                LoadAppointment(appointments[_model.indexcounter]);
            }
            _view.StatusChange = "End of Index - Appointment:" + (_model.indexcounter + 1);
            _view.PreviousButtonVisible = false;
            _view.NextButtonVisible = true;
        }
        private void CheckNavigationStatus()
        {
            if (_model.navigationstatus == "new")
            {
                CreateNewAppointment();
            }
            if (_model.navigationstatus == "next")
            {
                ProceedToNextAppointment();
            }
            if (_model.navigationstatus == "back")
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
                _model.navigationstatus = "new";
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
                _model.navigationstatus = "back";
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
                _model.navigationstatus = "next";
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
            _view.isDirty = true;
        }
        #endregion
    }
}
