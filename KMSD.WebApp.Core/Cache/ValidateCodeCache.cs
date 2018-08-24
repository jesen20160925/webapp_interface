using KMSD.WebApp.Core.Cache.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Cache
{
    public class ValidateCodeCache
    {
        public static bool SetValidateCodeWithoutExpire(string phoneNumber,string validateCode)
        {
            using (RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Set(phoneNumber, validateCode);
            }
        }

        public static bool SetValidateCodeWithExpire(string phoneNumber,string validateCode, DateTime time)
        {
            using (RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Set(phoneNumber, validateCode, time);
            }
        }

        public static string GetValidateCodeWithOutExpire(string phoneNumber)
        {
            using (RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Get(phoneNumber);
            }

        }

        public static string GetValidateCodeWithExpire(string phoneNumber)
        {
            using (RedisStringOpt redisStringOpt = new RedisStringOpt())
            {
                return redisStringOpt.Get(phoneNumber);
            }
        }
    }
}
