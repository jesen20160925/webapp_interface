using KMSD.WebApp.Core.Aop.Filter;
using KMSD.WebApp.Core.Cache;
using KMSD.WebApp.Core.JWT;
using KMSD.WebApp.Core.Result;
using KMSD.WebApp.Domain;
using KMSD.WebApp.Domain.BackData;
using KMSD.WebApp.Service.Member;
using KMSD.WebApp.Service.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KMSD.WebApp.Areas.Member.Controllers
{
    /// <summary>
    /// 会员信息设置类
    /// author:胡进顺
    /// date:2018-07-25
    /// </summary>
    [Authenticate]
    public class SettingController : Controller
    {
        private ISettingService settingService;

        public SettingController(ISettingService _settingService)
        {
            this.settingService = _settingService;
        }
        
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="passwordType">修改密码类型</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ModifyPwd(string oldPassword, string newPassword, PasswordType passwordType)
        {
            var tokenInfo = JwtUtil.GetTokenInfo();

            return new JsonResult()
            {
                Data = settingService.ModifyPassword(tokenInfo.Number, oldPassword, newPassword, passwordType)
            };
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phoneNumber">手机号码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SendValidateCode(string phoneNumber)
        {
            if (phoneNumber.IsNullOrEmpty()) { throw new ArgumentNullException(); }
            if (SendMsgService.SendValidateCode(phoneNumber))
            {
                return CustomResult.SuccessMessage("success");
            }
            else
            {
                return CustomResult.ErrorMessage("验证码发送失败！");
            }
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="phoneNumber">手机号码</param>
        /// <param name="number">会员编号</param>
        /// <param name="name">会员姓名</param>
        /// <param name="identityNumber">证件号</param>
        /// <param name="validateCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult FindPwd(string phoneNumber, string number, string name, string identityNumber, string validateCode)
        {
            string cacheValidateCode = ValidateCodeCache.GetValidateCodeWithExpire(phoneNumber);
            if (cacheValidateCode.IsNullOrEmpty() || !cacheValidateCode.Equals(validateCode))
            {
                return CustomResult.ErrorMessage("验证码错误或已失效");
            }

            string newPwd;

            BackMessage backMessage = settingService.FindPassword(number, name, identityNumber, out newPwd);
            if (backMessage.Code == 200)
            {
                SendMsgService.SendNewPassword(phoneNumber, newPwd);
            }

            return new JsonResult() { Data = backMessage };

        }
    
    }

}
