using KMSD.WebApp.Core.JWT;
using KMSD.WebApp.Core.Result;
using KMSD.WebApp.Domain.BackData;
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
    /// 会员首页
    /// author:胡进顺
    /// date:2018-07-30
    /// </summary>
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(typeof(HomeController));
            //var actionDescriptor = controllerDescriptor.FindAction(ControllerContext, "DemoAction");
            //IEnumerable<Filter> filters = FilterProviders.Providers.GetFilters(ControllerContext, actionDescriptor);
            return View();
        }

       


        [HttpPost]
        public JsonResult GetNoLoginToken()
        {
            return CustomResult.SuccessMessage<object>(new { Token = JwtUtil.SetJwtEncode("") });
        }
    }
}
