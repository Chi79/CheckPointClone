using ReaderCommon.Enum;
using ReaderCommon.HelperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderCommon.FactoryInterfaces
{
    public interface IRegistrationResultFactory
    {
        IRegistrationResult CreateRegistrationResult(RegistrationFeedbackStatus status);
    }
}
