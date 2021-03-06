﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointModel.Validation;
using CheckPointCommon.ValidationInterfaces;
using CheckPointCommon.DTOInterfaces;


namespace CheckPointModel.DTOs
{
    public class ClientDTO : RegisterClientValidator , IClientDTO
    {          
        public int ClientType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
    
        public override void CheckForBrokenRules(IClientDTO client)
        {
            base.CheckForBrokenRules(this);

        }
    }
}
