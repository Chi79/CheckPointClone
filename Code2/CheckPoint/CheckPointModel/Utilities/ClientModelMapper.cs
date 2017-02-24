using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointModel.Entities;

namespace CheckPointModel.Utilities
{
    public class ClientModelMapper
    {
        public static CLIENT convertToClient(ClientModel clientModel)
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
