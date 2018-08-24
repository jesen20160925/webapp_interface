using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Cache.Redis
{
    public delegate void UseAcquiredLockAction(IRedisClient rc);

    /// <summary>
    /// Redis缓存策略类
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class RedisCacheStrategy : IDisposable
    {
        public static IRedisClient redisClient { get; private set; }

        private bool _disposed = false;

        public RedisCacheStrategy()
        {
            redisClient = RedisManager.GetClient();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    redisClient.Dispose();
                    redisClient = null;
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 保存数据DB文件到硬盘
        /// </summary>
        public void Save()
        {
            redisClient.Save();
        }

        /// <summary>
        /// 异步保存数据DB文件到硬盘
        /// </summary>
        public void SaveAsync()
        {
            redisClient.SaveAsync();
        }

        /// <summary>
        /// 事务操作，好像没什么用，redis事务失败，在失败的命令前执行的都会生效，失败的命令后的不再执行而已
        /// </summary>
        public virtual void Transaction() { }

        /// <summary>
        /// 使用乐观锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public virtual void UseAcquiredLockCmd(string key,UseAcquiredLockAction action)
        {
            using (IRedisClient rc = RedisCacheStrategy.redisClient)
            {
                using (rc.AcquireLock(key))
                {
                    action(rc);
                }
            }
        }
    }
}
