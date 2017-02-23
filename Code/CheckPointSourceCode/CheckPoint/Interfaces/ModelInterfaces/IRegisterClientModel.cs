using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;


namespace CheckPointCommon.ModelInterfaces
{
    public interface IRegisterClientModel<U, T> where U: class where T: class
    {
        U ConvertClientModelToClient(T entityModel);
        //bool ValidateRegistrationData(T entityModel);
        //List<string> BrokenRules(T entityModel);
    }
}
