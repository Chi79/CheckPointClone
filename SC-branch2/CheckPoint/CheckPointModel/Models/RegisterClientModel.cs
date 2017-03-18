using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.Utilities;
using CheckPointModel.DTOs;

namespace CheckPointModel.Models
{
    public class RegisterClientModel : IRegisterClientModel<CLIENT, ClientDTO> 
    {
        public CLIENT ConvertClientModelToClient(ClientDTO client)
        {
            return ClientDTOMapper.convertClientDTOToClient(client);
        }
    }
}
