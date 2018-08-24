using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Cache.Redis
{
    /// <summary>
    /// Reids列表操作类
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class RedisListOpt : RedisCacheStrategy
    {
        #region 赋值

        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public void LPush(string key, string value)
        {
            RedisCacheStrategy.redisClient.PushItemToList(key, value);
        }

        /// <summary>
        /// 从左侧向list中添加值，并设置过期时间
        /// </summary>
        public void LPush(string key, string value, DateTime dt)
        {
            RedisCacheStrategy.redisClient.PushItemToList(key, value);
            RedisCacheStrategy.redisClient.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 从左侧向list中添加值，设置过期时间
        /// </summary>
        public void LPush(string key, string value, TimeSpan sp)
        {
            RedisCacheStrategy.redisClient.PushItemToList(key, value);
            RedisCacheStrategy.redisClient.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public void RPush(string key, string value)
        {
            RedisCacheStrategy.redisClient.PrependItemToList(key, value);
        }

        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>    
        public void RPush(string key, string value, DateTime dt)
        {
            RedisCacheStrategy.redisClient.PrependItemToList(key, value);
            RedisCacheStrategy.redisClient.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>        
        public void RPush(string key, string value, TimeSpan sp)
        {
            RedisCacheStrategy.redisClient.PrependItemToList(key, value);
            RedisCacheStrategy.redisClient.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// 添加key/value
        /// </summary>     
        public void Add(string key, string value)
        {
            RedisCacheStrategy.redisClient.AddItemToList(key, value);
        }

        /// <summary>
        /// 添加key/value ,并设置过期时间
        /// </summary>  
        public void Add(string key, string value, DateTime dt)
        {
            RedisCacheStrategy.redisClient.AddItemToList(key, value);
            RedisCacheStrategy.redisClient.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 添加key/value。并添加过期时间
        /// </summary>  
        public void Add(string key, string value, TimeSpan sp)
        {
            RedisCacheStrategy.redisClient.AddItemToList(key, value);
            RedisCacheStrategy.redisClient.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// 为key添加多个值
        /// </summary>  
        public void Add(string key, List<string> values)
        {
            RedisCacheStrategy.redisClient.AddRangeToList(key, values);
        }

        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, DateTime dt)
        {
            RedisCacheStrategy.redisClient.AddRangeToList(key, values);
            RedisCacheStrategy.redisClient.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, TimeSpan sp)
        {
            RedisCacheStrategy.redisClient.AddRangeToList(key, values);
            RedisCacheStrategy.redisClient.ExpireEntryIn(key, sp);
        }
        #endregion

        #region 获取值
        /// <summary>
        /// 获取list中key包含的数据数量
        /// </summary>  
        public long Count(string key)
        {
            return RedisCacheStrategy.redisClient.GetListCount(key);
        }

        /// <summary>
        /// 获取key包含的所有数据集合
        /// </summary>  
        public List<string> Get(string key)
        {
            return RedisCacheStrategy.redisClient.GetAllItemsFromList(key);
        }

        /// <summary>
        /// 获取key中下标为star到end的值集合
        /// </summary>  
        public List<string> Get(string key, int star, int end)
        {
            return RedisCacheStrategy.redisClient.GetRangeFromList(key, star, end);
        }
        #endregion

        #region 阻塞命令

        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingPopItemFromList(string key, TimeSpan? sp)
        {
            return RedisCacheStrategy.redisClient.BlockingDequeueItemFromList(key, sp);
        }

        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingPopItemFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisCacheStrategy.redisClient.BlockingPopItemFromLists(keys, sp);
        }

        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingDequeueItemFromList(string key, TimeSpan? sp)
        {
            return RedisCacheStrategy.redisClient.BlockingDequeueItemFromList(key, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingDequeueItemFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisCacheStrategy.redisClient.BlockingDequeueItemFromLists(keys, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingRemoveStartFromList(string keys, TimeSpan? sp)
        {
            return RedisCacheStrategy.redisClient.BlockingRemoveStartFromList(keys, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingRemoveStartFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisCacheStrategy.redisClient.BlockingRemoveStartFromLists(keys, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中一个fromkey的尾部移除一个值，添加到另外一个tokey的头部，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingPopAndPushItemBetweenLists(string fromkey, string tokey, TimeSpan? sp)
        {
            using(IRedisClient rc = RedisCacheStrategy.redisClient)
            {
                var toValue = rc.BlockingDequeueItemFromList(fromkey,sp);
                rc.PushItemToList(tokey,toValue);
                return toValue;
            }

            //return BaseRedis.redisClient.BlockingPopAndPushItemBetweenLists(fromkey, tokey, sp);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 从尾部移除数据，返回移除的数据
        /// </summary>  
        public string PopItemFromList(string key)
        {
            return RedisCacheStrategy.redisClient.PopItemFromList(key);
        }

        /// <summary>
        /// 移除list中，key/value,与参数相同的值，并返回移除的数量
        /// </summary>  
        public long RemoveItemFromList(string key, string value)
        {
            return RedisCacheStrategy.redisClient.RemoveItemFromList(key, value);
        }

        /// <summary>
        /// 从list的尾部移除一个数据，返回移除的数据
        /// </summary>  
        public string RemoveEndFromList(string key)
        {
            return RedisCacheStrategy.redisClient.RemoveEndFromList(key);
        }

        /// <summary>
        /// 从list的头部移除一个数据，返回移除的值
        /// </summary>  
        public string RemoveStartFromList(string key)
        {
            return RedisCacheStrategy.redisClient.RemoveStartFromList(key);
        }
        #endregion

        #region 其它
        /// <summary>
        /// 从一个list的尾部移除一个数据，添加到另外一个list的头部，并返回移动的值
        /// </summary>  
        public string PopAndPushItemBetweenLists(string fromKey, string toKey)
        {
            return RedisCacheStrategy.redisClient.PopAndPushItemBetweenLists(fromKey, toKey);
        }
        #endregion

        public override void Transaction()
        {
            throw new NotImplementedException();
        }
    }
}
