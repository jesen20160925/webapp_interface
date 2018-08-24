using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Util
{
    public class SerializeUtil
    {
        /// <summary>
        /// 对数据进行序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeToString(object value)
        {
            //解决Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type 'System.Data.Entity.DynamicProxies.导航属性导致的序列化异常,也可在实体类当中的导航属性加注释[JsonIgnore]
            //JsonSerializerSettings settings = new JsonSerializerSettings();
            // settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // return JsonConvert.SerializeObject(value,settings);
            return JsonConvert.SerializeObject(value);
        }
        /// <summary>
        /// 反序列化操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeToObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
