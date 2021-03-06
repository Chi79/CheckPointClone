﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckPointCommon.CacheInterfaces;

namespace CheckPointHTTPServices.Cache
{

    public class CacheData : ICacheData
    {

        public void Add(string key, object data)
        {

            HttpContext.Current.Cache.Insert(key, data);

        }

        public void AddWithExpiry(string key, object data)
        {

            DateTime expiry = new DateTime().AddHours(1);
            TimeSpan? span = new TimeSpan();
            span = null;
            HttpContext.Current.Cache.Insert(key, data, null, expiry, (TimeSpan)span);

        }

        public T Fetch<T>(string key)
        {

            T dataStored = (T)HttpContext.Current.Cache.Get(key);
            if (dataStored == null)
            dataStored = default(T);

            return dataStored; 

        }
        public IEnumerable<T> FetchCollection<T>(string key)
        {

            IEnumerable<T> cachedCollection = (IEnumerable<T>)HttpContext.Current.Cache.Get(key);
            if (cachedCollection == null)
            cachedCollection = default(IEnumerable<T>);

            return cachedCollection;

        }

        public void Remove(string key)
        {

            HttpContext.Current.Cache.Remove(key);

        }
    }
}