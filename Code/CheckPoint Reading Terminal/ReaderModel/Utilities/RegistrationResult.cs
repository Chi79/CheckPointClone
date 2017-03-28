using ReaderCommon.HelperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Utilities
{
    public class RegistrationResult : IRegistrationResult
    {
        public RegistrationResult(string resultMessage, string resultColor)
        {
            Message = resultMessage;
            Color = resultColor;

        }
        public string Message { get; set; }
        public string Color { get; set; }

       
    }
}
