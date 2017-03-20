using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;


namespace CheckPointCommon.ModelInterfaces
{
    public interface IRegisterClientModel
    {
        object ConvertClientDTOToClient(object entityModel);
    }
}
