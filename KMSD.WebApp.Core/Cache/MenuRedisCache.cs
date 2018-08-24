
using KMSD.WebApp.Core.Cache.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Cache
{
    public class MenuRedisCache
    {
        private const string MENU_WITH_EXPIRE = "menu_with_expire";
        private const string MENU_WITHOUT_EXPIRE = "menu_without_expire";

        public static bool SetMenuWithoutExpire(string value)
        {
            using(RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Set(MENU_WITHOUT_EXPIRE, value);
            }
        }

        public static bool SetMenuWithExpire(string value,DateTime time)
        {
            using (RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Set(MENU_WITH_EXPIRE, value, time);
            }
        }

        public static string GetMenuWithOutExpire()
        {
            using(RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Get(MENU_WITHOUT_EXPIRE);
            }
                
        }

        public static string GetMenuWithExpire()
        {
            using (RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Get(MENU_WITH_EXPIRE);
            }
        }
    }
}
