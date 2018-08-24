using KMSD.WebApp.Core.Aop.Filter;
using KMSD.WebApp.Core.Result;
using KMSD.WebApp.Domain;
using KMSD.WebApp.Domain.BackData;
using KMSD.WebApp.Domain.Dto;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Service.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KMSD.WebApp.Areas.Member.Controllers
{
    /// <summary>
    /// 会员注册
    /// author：胡进顺
    /// date:2018-08-06
    /// </summary>
    [Authenticate]
    public class RegisterController : Controller
    {
        private IRegisterService registerService;

        public RegisterController(IRegisterService _registerService)
        {
            this.registerService = _registerService;
        }

        #region 获取注册时的会员编号
        /// <summary>
        /// 获取注册时的会员编号
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMemberNumber()
        {
            return CustomResult.SuccessMessage<object>(data: new { Number = registerService.GetMemberNumber() });
        }
        #endregion

        #region 会员注册表单校验
        /// <summary>
        /// 会员注册表单校验
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public JsonResult MemberRegisterCheck(RegisterDto memberInfo)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Where(m => m.Value.Errors.Any()).FirstOrDefault();
                return CustomResult.ErrorMessage(error.Value.Errors[0].ErrorMessage);
            }

            if (!memberInfo.Level.In(LevelInt.Golden, LevelInt.Diamon, LevelInt.SpecialVip))
            {
                return CustomResult.ErrorMessage("注册级别不正确");
            }

            if (!memberInfo.InsuranceType.In(InsuranceType.None, InsuranceType.BType))
            {
                return CustomResult.ErrorMessage("百万身价俱乐部不正确");
            }

            if (!registerService.RegisterCheck(memberInfo, out string errMsg))
            {
                return CustomResult.ErrorMessage(errMsg);
            }

            return CustomResult.SuccessMessage("该去购物车啦");
        } 
        #endregion
    }
}


