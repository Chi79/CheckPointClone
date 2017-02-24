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
         public bool Result;
    }
    public struct SaveResult
    {
        public string ErrorMessage;
        public int Result;

    }
}
