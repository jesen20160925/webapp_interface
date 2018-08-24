
using KMSD.WebApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KMSD.WebApp.Mvc.Controllers
{
    //[Authenticate]
    public class HomeController : Controller
    {
        private IHomeService homeService;

        public HomeController(IHomeService _homeService)
        {
            this.homeService = _homeService;
        }

        [HttpPost]
        public JsonResult Index()
        {
            return new JsonResult() { Data = homeService.GetHomeIndexData() };
        }
    }
}
