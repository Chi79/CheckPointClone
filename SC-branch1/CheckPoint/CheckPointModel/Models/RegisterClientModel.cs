using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.Utilities;
using CheckPointModel.DTOs;
using CheckPointCommon.DTOInterfaces;

namespace CheckPointModel.Models
{
    public class RegisterClientModel : IRegisterClientModel
    {
        public object ConvertClientDTOToClient(object client)
        {
            return ClientDTOMapper.convertClientDTOToClient((IClientDTO)client);
        }
    }
}
