using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KMSD.WebApp.Areas.Member
{
    public class MemberAreaRegistration : AreaRegistration
    {
        public override string AreaName 
        {
            get{
                return "Store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "Store_default",
               "Store/{controller}/{action}/{id}",
               new { action = "Index", controller = "Home", id = UrlParameter.Optional },
               namespaces : new string[]{ "KMSD.WebApp.Areas.Store.Controllers" }
           );
        }
    }
}
