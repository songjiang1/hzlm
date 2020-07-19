﻿using Learn.Cache.Redis;
using Learn.Util;

namespace Learn.Cache.Factory
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.11.9 10:45
    /// 描 述：缓存工厂类
    /// </summary>
    public class CacheFactory
    {
        private static IRedisCacheManager _cache;
        public CacheFactory(IRedisCacheManager cache)
        {
            _cache = cache;
        }
        /// <summary>
        /// 定义通用的Repository
        /// </summary>
        /// <returns></returns>
        public static ICache Cache()
        {
            //修改为支持Redis
            string cacheType = GlobalContext.SystemConfig.CacheType;
             
            switch (cacheType)
            {
                case "Redis":
                    return new Learn.Cache.Redis.Cache(_cache);
                    break; 
                default:
                    return new Cache();
                    break;
            }
        }
    }
}
