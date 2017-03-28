using ReaderCommon.Enum;
using ReaderCommon.FactoryInterfaces;
using ReaderModel.Factories;
using ReaderModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaderCommon.HelperInterfaces;

namespace ReaderModel.Factories
{
    public class RegistrationResultFactory : IRegistrationResultFactory
    {

        public IRegistrationResult CreateRegistrationResult(RegistrationFeedbackStatus status)
        {
            switch (status)
            {
                case RegistrationFeedbackStatus.Successful:
                    return new RegistrationResult("Registration Successful", "Green");
                case RegistrationFeedbackStatus.Failed:
                    return new RegistrationResult("Registration Failed. Please contact host", "Red");
                case RegistrationFeedbackStatus.AlreadyRegistered:
                    return new RegistrationResult("Already registered for this appointment", "Yellow");
                case RegistrationFeedbackStatus.NoDatabaseConnection:
                    return new RegistrationResult("Unable to contact database. Contact Staff", "White");
                default:
                    return new RegistrationResult("Reading Terminal Error. Contact Staff", "White");
            }


        }
    }
}
