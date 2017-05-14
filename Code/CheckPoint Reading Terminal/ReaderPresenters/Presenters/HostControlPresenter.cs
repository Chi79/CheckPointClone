using ReaderCommon.DataAccessInterfaces;
using ReaderCommon.ModelInterfaces;
using ReaderCommon.SerialProtocolInterfaces;
using ReaderCommon.ViewInterfaces;
using ReaderPresenters.Base;
using System;
using System.Collections.Generic;

namespace ReaderPresenters.Presenters
{
    public class HostControlPresenter : PresenterBase
    {
        private readonly IHostControlView _hostControlView;
        private readonly IHostControlModel _hostControlModel;
        private readonly IDataAccess _dataAccess;
        private readonly ISerialProtocol _serialProtocol;


        public HostControlPresenter(IHostControlView hostControlView, IHostControlModel hostControlModel, IDataAccess dataAccess, ISerialProtocol serialProtocol)
        {
            _hostControlView = hostControlView;
            _hostControlModel = hostControlModel;
            _dataAccess = dataAccess;
            _serialProtocol = serialProtocol;
            _hostControlView.StartAppointment += OnStartAppointmentButtonClicked;
            _hostControlView.LogOut += OnLogOutButtonClicked;
            LoadHostAndAppointments(_hostControlView.Username);
        }

        private async void LoadHostAndAppointments(string hostUserName)
        {
            var loggedInHost = await _dataAccess.GetLoggedInHost(hostUserName);
            _hostControlView.Username = loggedInHost.UserName;

            var hostAppointments = await _dataAccess.GetHostAppointments(hostUserName);
            _hostControlView.HostAppointmentsDataSource = hostAppointments as IEnumerable<object>;

        }
        private void OnStartAppointmentButtonClicked(object sender, EventArgs e)
        {
            if(_serialProtocol.IsConnected())
            {               
                _hostControlView.RedirectToTerminalView();
            }
            else
            {
                _hostControlView.Message = "Please make sure the RFID reader is connected to the reading terminal";
            }
        }



        private void OnLogOutButtonClicked(object sender, EventArgs e)
        {
            _hostControlView.RedirectToLoginView();
        }

       
    }
}
