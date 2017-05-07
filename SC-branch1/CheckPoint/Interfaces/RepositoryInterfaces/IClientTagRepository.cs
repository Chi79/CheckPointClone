﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
namespace CheckPointCommon.RepositoryInterfaces
{
   public interface IClientTagRepository:IRepository<CLIENT_TAG>
    {
        string GetClientTagId (string userName);
    }
}
