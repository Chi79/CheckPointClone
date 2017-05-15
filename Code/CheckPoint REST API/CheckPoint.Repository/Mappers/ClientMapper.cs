using CheckPoint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.Mappers
{
    public class ClientMapper
    {
        public ClientMapper()
        {

        }

        public DTO.Client CreateClient(CLIENT client)
        {
            return new DTO.Client()
            {
                UserName = client.UserName,
                Password = client.Password,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                PostalCode = client.PostalCode,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                ClientType = client.ClientType
            };
        }

        public CLIENT CreateClient(DTO.Client client)
        {
            return new CLIENT()
            {
                UserName = client.UserName,
                Password = client.Password,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                PostalCode = client.PostalCode,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                ClientType = client.ClientType
            };
        }

        public object CreateShapeDataObject(CLIENT client, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(CreateClient(client), listOfFields);
        }

        public object CreateShapeDataObject(DTO.Client client, List<string> listOfFields)
        {
            if(!listOfFields.Any())
            {
                return client;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach(var field in listOfFields)
                {
                    var fieldValue = client.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(client, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);                 
                }

                return objectToReturn;
            }

        }
    }
}
