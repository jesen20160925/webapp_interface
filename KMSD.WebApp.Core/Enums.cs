using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core
{
    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// 本地缓存
        /// </summary>
        LocalCache,

        /// <summary>
        /// Redis
        /// </summary>
        Redis,
    }

    public enum RedisOptType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        String,
        /// <summary>
        /// 链表
        /// </summary>
        List,
        /// <summary>
        /// 集合
        /// </summary>
        Set,
        /// <summary>
        /// 有序集合
        /// </summary>
        ZSet,
        /// <summary>
        /// 哈希
        /// </summary>
        Hash
    }
}
