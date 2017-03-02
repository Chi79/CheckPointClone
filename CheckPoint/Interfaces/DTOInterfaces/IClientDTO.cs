using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.DTOInterfaces
{
    public interface IClientDTO
    {
       int ClientType { get; set; }
       string UserName { get; set; }
       string Password { get; set; }
       string FirstName { get; set; }
       string LastName { get; set; }
       string Email { get; set; }
       string Address { get; set; }
       string PhoneNumber { get; set; }
       string PostalCode { get; set; }
    }
}
