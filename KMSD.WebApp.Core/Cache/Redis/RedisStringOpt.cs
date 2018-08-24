using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Cache.Redis
{
    /// <summary>
    /// Redis字符串操作类
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class RedisStringOpt : RedisCacheStrategy
    {
        #region 赋值
        /// <summary>
        /// 设置key的value
        /// </summary>
        public bool Set(string key, string value)
        {
            return RedisCacheStrategy.redisClient.Set<string>(key, value);
        }

        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set(string key, string value, DateTime dt)
        {
            return RedisCacheStrategy.redisClient.Set<string>(key, value, dt);
        }

        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set(string key, string value, TimeSpan sp)
        {
            return RedisCacheStrategy.redisClient.Set<string>(key, value, sp);
        }

        /// <summary>
        /// 设置多个key/value
        /// </summary>
        public void Set(Dictionary<string, string> dic)
        {
            RedisCacheStrategy.redisClient.SetAll(dic);
        }

        #endregion

        #region 追加
        /// <summary>
        /// 在原有key的value值之后追加value
        /// </summary>
        public long Append(string key, string value)
        {
            return RedisCacheStrategy.redisClient.AppendToValue(key, value);
        }
        #endregion

        #region 获取值
        /// <summary>
        /// 获取key的value值
        /// </summary>
        public string Get(string key)
        {
            return RedisCacheStrategy.redisClient.GetValue(key);
        }

        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<string> Get(List<string> keys)
        {
            return RedisCacheStrategy.redisClient.GetValues(keys);
        }

        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<T> Get<T>(List<string> keys)
        {
            return RedisCacheStrategy.redisClient.GetValues<T>(keys);
        }
        #endregion

        #region 获取旧值赋上新值

        /// <summary>
        /// 获取旧值赋上新值
        /// </summary>
        public string GetAndSetValue(string key, string value)
        {
            return RedisCacheStrategy.redisClient.GetAndSetEntry(key, value);
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 获取值的长度
        /// </summary>
        public long GetCount(string key)
        {
            return RedisCacheStrategy.redisClient.GetValue(key).Length;
        }

        /// <summary>
        /// 自增1，返回自增后的值
        /// </summary>
        public long Incr(string key)
        {
            return RedisCacheStrategy.redisClient.IncrementValue(key);
        }

        /// <summary>
        /// 自增count，返回自增后的值
        /// </summary>
        public long IncrBy(string key, int count)
        {
            return RedisCacheStrategy.redisClient.IncrementValueBy(key, count);
        }

        /// <summary>
        /// 自减1，返回自减后的值
        /// </summary>
        public long Decr(string key)
        {
            return RedisCacheStrategy.redisClient.DecrementValue(key);
        }

        /// <summary>
        /// 自减count ，返回自减后的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public long DecrBy(string key, int count)
        {
            return RedisCacheStrategy.redisClient.DecrementValueBy(key, count);
        }
        #endregion

        public override void Transaction()
        {
            using (var tran = RedisManager.GetClient().CreateTransaction())
            {
                try
                {
                    tran.QueueCommand(p =>
                    {
                        //操作redis数据命令
                        RedisCacheStrategy.redisClient.Set<int>("name", 30);
                        long i = RedisCacheStrategy.redisClient.IncrementValueBy("name", 1);
                    });
                    //提交事务
                    tran.Commit();
                }
                catch
                {
                    //回滚事务
                    tran.Rollback();
                }
            }
        }
    }
}
