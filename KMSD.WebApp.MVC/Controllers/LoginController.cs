using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using KMSD.WebApp.Core.Util;
using KMSD.WebApp.Core.JWT;
using KMSD.WebApp.Service;
using KMSD.WebApp.Domain.BackData;

namespace KMSD.WebApp.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService loginService;

        public LoginController(ILoginService _loginService)
        
        {
            this.loginService = _loginService;
        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            return new JsonResult()
            {
                Data = loginService.Login(username, password)
            }; 
        }

        [HttpPost]
        public JsonResult Vistor()
        {
            return new JsonResult()
            {
                Data = loginService.GetVisitorPermission()
            };
        }
    }
}
