using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.Utilities;
using CheckPointModel.Entities;

namespace CheckPointModel.Models
{
    public class RegisterClientModel : IRegisterClientModel<ClientModel, CLIENT>
    {
        public CLIENT ConvertClientModelToClient(ClientModel client)
        {
            return ClientModelToClientMapper.convertToClient(client);
        }
    }
}
