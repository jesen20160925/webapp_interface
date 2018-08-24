using KMSD.WebApp.Core.Aop.Filter;
using KMSD.WebApp.Core.Result;
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
    /// 会员公共信息
    /// Author：胡进顺
    /// Date:2018-08-21
    /// </summary>
    [Authenticate]
    public class CommonController : Controller
    {
        private IMemberInfoService memberInfoService;

        public CommonController(IMemberInfoService _memberInfoService)
        {
            memberInfoService = _memberInfoService;
        }

        public JsonResult GetMemberName(string number)
        {
            if (number.IsNullOrEmpty())
            {
                return  CustomResult.ErrorMessage("会员编号不能为空！");
            }

            string name = memberInfoService.GetMemberName(number);

            if (name.IsNullOrEmpty())
            {
                return CustomResult.ErrorMessage("该会员编号不存在！");
            }

            return CustomResult.SuccessMessage(name);
        }
    }
}
