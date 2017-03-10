﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.CacheInterfaces
{
    public interface ICacheData
    {
        T Fetch<T>(string key);

        void Remove(string key);
        void Add(string key, object data);

        void AddWithDependency(string key, object data, object dependency);

        void AddWithExpirationAndDependency(string key, object data, DateTime expriry, object dependency);
    }
}