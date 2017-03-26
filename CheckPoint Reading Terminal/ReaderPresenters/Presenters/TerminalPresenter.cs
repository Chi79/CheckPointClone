using ReaderCommon.DataAccessInterfaces;
using ReaderCommon.Enum;
using ReaderCommon.FactoryInterfaces;
using ReaderCommon.HelperInterfaces;
using ReaderCommon.ModelInterfaces;
using ReaderCommon.SerialProtocolInterfaces;
using ReaderCommon.ViewInterfaces;
using ReaderModel.Utilities;
using ReaderPresenters.Base;
using System;
using System.Media;

namespace ReaderPresenters.Presenters
{
    public class TerminalPresenter : PresenterBase
    {
        private readonly ITerminalView _terminalView;
        private readonly ITerminalModel _terminalModel;
        private readonly IDataAccess _dataAccess;
        private readonly ISerialProtocol _serialProtocol;
        private readonly IRegistrationResultFactory _registrationResultFactory;

        public TerminalPresenter(ITerminalView terminalView, ITerminalModel terminalModel, IDataAccess dataAccess,
            ISerialProtocol serialProtocol, IRegistrationResultFactory registrationResultFactory)
        {
            _terminalView = terminalView;
            _terminalModel = terminalModel;
            _dataAccess = dataAccess;
            _serialProtocol = serialProtocol;
            _registrationResultFactory = registrationResultFactory;
            _serialProtocol.SerialPackage += OnTagScanned;
            _serialProtocol.Connect();
            _terminalView.EndAppointment += OnEndAppointmentButtonClicked;
            _terminalView.ToggleEndAppointmentPanel += OnToggleEndAppointmentButtonClicked;
        }

        private async void OnTagScanned(object sender, ISerialEventArgs e)
        {

            RegistrationSoundPlayer.Play();
            var tagId = GetTagId(e.Data, e.Length);

            var UpdateAttemptStatus = await _dataAccess.UpdateAttendeeWithStampAndStatus(tagId, _terminalView.ActiveAppointmentId,
                _terminalView.ActiveAppointmentObligatoryStatus);

            var registrationResult = _registrationResultFactory.CreateRegistrationResult(UpdateAttemptStatus);

            _terminalView.DisplayRegistrationResult(registrationResult.Message, registrationResult.Color);
        }

        public string GetTagId(byte[] serialData, byte length)
        {
            var formattedSerialData = _terminalModel.FormatSerialData(serialData, length);
            string tagId = _terminalModel.ConvertSerialDataIntoString((byte[])formattedSerialData);

            return tagId;
        }

        private async void OnEndAppointmentButtonClicked(object sender, EventArgs e)
        {
            var endActiveAppointment = await _dataAccess.AttemptLogin(_terminalView.Username, _terminalView.Password);

            if(endActiveAppointment)
            {
                _serialProtocol.Disconnect();
                _serialProtocol.SerialPackage -= OnTagScanned;
                _terminalView.Message = "";
                _terminalView.RedirectToHostControlView();
            }
            else
            {
                _terminalView.Message = "Verification Failed";
            }
        }

        private void OnToggleEndAppointmentButtonClicked(object sender, EventArgs e)
        {
            if(!_terminalView.ShowEndAppointmentPanel)
            {
                _terminalView.ShowEndAppointmentPanel = true;
                               
            }
            else
            {
                _terminalView.ShowEndAppointmentPanel = false;
                _terminalView.Message = "";
            }
            
        }
    }
}
