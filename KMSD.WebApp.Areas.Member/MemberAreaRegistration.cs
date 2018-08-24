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
                return "Member";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "Member_default",
               "Member/{controller}/{action}/{id}",
               new { action = "Index", controller = "Home", id = UrlParameter.Optional },
               namespaces : new string[]{ "KMSD.WebApp.Areas.Member.Controllers" }
           );
        }
    }
}
