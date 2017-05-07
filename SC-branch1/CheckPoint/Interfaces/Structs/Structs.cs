using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.Structs
{
    public struct LoginResult
    {
         public int ClientType;
         public bool Success;
         
    }
    public struct SaveResult
    {
        public string ErrorMessage;
        public int Result;
    }
}
