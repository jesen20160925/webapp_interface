using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using KMSD.WebApp.Core.Config;
using KMSD.WebApp.Core.Util;
using KMSD.WebApp.Domain.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KMSD.WebApp.Core.JWT
{
    /// <summary>
    /// JWT 工具类(json web token)
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class JwtUtil
    {
        /// <summary>
        /// 生成JwtToken
        /// </summary>
        /// <param name="payload">不敏感的用户数据</param>
        /// <returns></returns>
        public static string SetJwtEncode(string userName)
        {
            //格式如下
            var payload = new Dictionary<string, object>{
                    { "Number",userName },
                    { "IMEI",HttpContext.Current.Request.Headers["IMEI"]},
                    { "Expire", TimeUtil.GetTimeStamp() },
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, JwtConfig.SECRET);
            return token;
        }

        /// <summary>
        /// 根据jwtToken获取实体
        /// </summary>
        /// <param name="token">jwtToken</param>
        /// <returns></returns>
        private static string GetJwtDecode(string token)
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            return decoder.Decode(token, JwtConfig.SECRET, verify: true);//token为之前生成的字符串
        }

        /// <summary>
        /// 获取TokenInfo实体
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static TokenInfo GetTokenInfo(string token)
        {
            return SerializeUtil.DeserializeToObject<TokenInfo>(JwtUtil.GetJwtDecode(token));
        }


        public static TokenInfo GetTokenInfo()
        {
           var token = HttpContext.Current.Request.Headers["Token"];
           return SerializeUtil.DeserializeToObject<TokenInfo>(JwtUtil.GetJwtDecode(token));
        }
    }
}
