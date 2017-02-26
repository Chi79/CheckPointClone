using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPOCOs.POCOs;


namespace CheckPointCommon.ModelInterfaces
{
    public interface ILoginModel 
    {
        bool LoginDataIsValid(List<string> loginData);
    }
}
