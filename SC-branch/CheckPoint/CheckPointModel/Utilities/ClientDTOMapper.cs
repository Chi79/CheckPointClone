using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.DTOInterfaces;

namespace CheckPointModel.Utilities
{
    public class ClientDTOMapper
    {
        public static CLIENT convertClientDTOToClient(IClientDTO clientModel)
        {
            CLIENT client = new CLIENT()
            {
                UserName = clientModel.UserName,
                FirstName = clientModel.FirstName,
                LastName = clientModel.LastName,
                Email = clientModel.Email,
                Address = clientModel.Address,
                PostalCode = Convert.ToInt32(clientModel.PostalCode),
                PhoneNumber = Convert.ToInt32(clientModel.PhoneNumber),
                Password = clientModel.Password,
                ClientType = clientModel.ClientType
            };
            return client;
        }
    }
}
