using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;


namespace CheckPointCommon.ModelInterfaces
{
    public interface IRegisterClientModel<T, U> where T: class where U: class
    {
        U ConvertClientModelToClient(T entityModel);
        //bool ValidateRegistrationData(T entityModel);
        //List<string> BrokenRules(T entityModel);
    }
}
