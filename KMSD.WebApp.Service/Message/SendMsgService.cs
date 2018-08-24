using KMSD.WebApp.Core.Cache;
using KMSD.WebApp.Core.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service.Message
{
    public class SendMsgService
    {
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool SendValidateCode(string phoneNumber)
        {
            string validateCode = new Random().Next(111111, 999999).ToString().PadLeft(6, '0');

            Dictionary<string, object> dicParameter = new Dictionary<string, object>();
            dicParameter.Add("operateNumber", ConfigurationManager.AppSettings["MessageOperate"]);
            dicParameter.Add("dept", ConfigurationManager.AppSettings["MessageDept"]);
            dicParameter.Add("messagetype", ConfigurationManager.AppSettings["MessageType"]);
            dicParameter.Add("phoneValue", phoneNumber);
            dicParameter.Add("messageContent", string.Format("您此次修改密码的验证码为：{0}，{1}分钟内有效。", validateCode,5));

            ValidateCodeCache.SetValidateCodeWithExpire(phoneNumber, validateCode, DateTime.Now.AddMinutes(5).AddSeconds(30)); //5分钟
            return true;
            return WebUtil.HttpWebRequest(ConfigurationManager.AppSettings["MessageUrl"], WebUtil.WebParameterContract(dicParameter)).Equals("OK");
            
        }

        /// <summary>
        /// 发送新密码给会员
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public static bool SendNewPassword(string phoneNumber,string newPwd)
        {
            string validateCode = new Random().Next(111111, 999999).ToString().PadLeft(6, '0');

            Dictionary<string, object> dicParameter = new Dictionary<string, object>();
            dicParameter.Add("operateNumber", ConfigurationManager.AppSettings["MessageOperate"]);
            dicParameter.Add("dept", ConfigurationManager.AppSettings["MessageDept"]);
            dicParameter.Add("messagetype", ConfigurationManager.AppSettings["MessageType"]);
            dicParameter.Add("phoneValue", phoneNumber);
            dicParameter.Add("messageContent", string.Format("您的登录密码已经重置为：{0}。", newPwd));
            return true;
            return WebUtil.HttpWebRequest(ConfigurationManager.AppSettings["MessageUrl"], WebUtil.WebParameterContract(dicParameter)).Equals("OK");

        }
    }
}
