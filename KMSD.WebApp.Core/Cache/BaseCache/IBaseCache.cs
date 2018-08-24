using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KMSD.WebApp.Core.Cache.BaseCache
{
    /// <summary>
    /// 本地缓存接口
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseCache<T> where T : class,new()
    {
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        T GetCache(string cacheKey);

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        void WriteCache(T value, string cacheKey);

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        void WriteCache(T value, string cacheKey, DateTime expireTime);

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        void RemoveCache(string cacheKey);

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        void RemoveCache();
    }
}
