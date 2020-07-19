﻿using System;

namespace Learn.Cache
{
    public interface ICache
    {  
        void AddCache<T>(string cacheKey, T value);

        void AddCache<T>(string cacheKey, T value, DateTime expireTime);

        void RemoveCache(string cacheKey);

        void RemoveAllCache();

        T GetCache<T>(string cacheKey);
    }
}
