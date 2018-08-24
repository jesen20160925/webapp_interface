using KMSD.WebApp.Core.Result;
using KMSD.WebApp.Service.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KMSD.WebApp.Areas.Store.Controllers
{
    public class CommonController : Controller
    {
        private IStoreInfoService storeInfoService;

        public CommonController(IStoreInfoService _storeInfoService)
        {
            storeInfoService = _storeInfoService;
        }

        public JsonResult GetStoreName(string storeId)
        {
            if (storeId.IsNullOrEmpty())
            {
                return CustomResult.ErrorMessage("服务中心编号不能为空！");
            }

            string name = storeInfoService.GetStoreName(storeId);

            if (name.IsNullOrEmpty())
            {
                return CustomResult.ErrorMessage("该服务中心编号不存在！");
            }

            return CustomResult.SuccessMessage(name);
        }
    }
}
