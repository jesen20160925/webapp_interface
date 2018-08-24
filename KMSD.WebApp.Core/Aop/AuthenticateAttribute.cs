using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using KMSD.WebApp.Core.JWT;
using KMSD.WebApp.Domain.Token;
using KMSD.WebApp.Core.Util;
using KMSD.WebApp.Domain.BackData;

namespace KMSD.WebApp.Core.Aop.Filter
{
    /// <summary>
    /// 自定义身份认证过滤器
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class AuthenticateAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.HttpMethod.Equals("POST") || !filterContext.HttpContext.Request.ContentType.Equals("application/x-www-form-urlencoded"))
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new BackMessage()
                    {
                        Code = 500,
                        Msg = "访问错误！",
                        Data = null
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return;
            }

            if (!IsAuthenticated(filterContext)) 
            {
                this.ProcessUnautheticatedRequest(filterContext);
            }
        }

        private void ProcessUnautheticatedRequest(AuthenticationContext filterContext)
        {
            //filterContext.Result = new HttpUnauthorizedResult();
            filterContext.Result = new JsonResult()
            {
                Data = new BackMessage()
                {
                    Code = 501,
                    Msg = "您的登录权限已失效，请重新登录！",
                    Data = null
                }
            };
        }

        protected virtual bool IsAuthenticated(AuthenticationContext filterContext)
        {
            string token = filterContext.HttpContext.Request.Headers["Token"];
            if (!string.IsNullOrEmpty(token))
            {
                TokenInfo tokenInfo = JwtUtil.GetTokenInfo(token);

                if (tokenInfo != null)
                {
                    var span = DateTime.Now - TimeUtil.StampToDateTime(tokenInfo.Expire);
                    if (span.TotalHours > 2)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        { 
            
        }
    }
}
