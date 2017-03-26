using Reader.DataAccessREST;
using ReaderCommon.DataAccessInterfaces;
using ReaderCommon.Enum;
using ReaderCommon.FactoryInterfaces;
using ReaderCommon.HelperInterfaces;
using ReaderCommon.ModelInterfaces;
using ReaderCommon.SerialProtocolInterfaces;
using ReaderCommon.ViewInterfaces;
using ReaderModel.Factories;
using ReaderModel.Models;
using ReaderSerialProtocols.SerialProtocols;
using ReaderViews;
using StructureMap;

namespace InjectionManager.Registries
{
    class ReaderRegistry : Registry
    {
        public ReaderRegistry()
        {

            For<ILoginView>().Use<LoginView>();
            For<IHostControlView>().Use<HostControlView>();
            For<ITerminalView>().Use<TerminalView>();
            For<ILoginModel>().Use<LoginModel>();
            For<IHostControlModel>().Use<HostControlModel>();
            For<ITerminalModel>().Use<TerminalModel>();
            For<IDataAccess>().Use<RESTService>();
            For<ISerialProtocol>().Use<ArduinoSerialProtocol>();
            For<IRegistrationResultFactory>().Use<RegistrationResultFactory>();
        }
    }
}
