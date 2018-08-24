using KMSD.WebApp.Core.JWT;
using KMSD.WebApp.Domain.BackData;
using KMSD.WebApp.Domain.Token;
using KMSD.WebApp.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace KMSD.WebApp.Core.Aop.Filter
{
    /// <summary>
    /// 自定义异常处理类
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class CustomExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            LogMessage logMessage = new LogMessage(HttpContext.Current);

            string token = HttpContext.Current.Request.Headers["Token"];
            if (!string.IsNullOrEmpty(token))
            {
                TokenInfo tokenInfo = JwtUtil.GetTokenInfo(token);

                if (tokenInfo != null)
                {
                    logMessage.UserName = tokenInfo.Number;
                }
            }

            logMessage.ExceptionInfo = string.Format("{0}\r\n{1}\r\n{2}\r\n", filterContext.Exception.Message, filterContext.Exception.StackTrace, filterContext.Exception.Source);

            LogUtility.ErrorLogger.Error(new LogFormat().ExceptionFormat(logMessage));

            filterContext.ExceptionHandled = true; //指示异常已经处理，不需要返回异常信息到客户端

            filterContext.Result = new JsonResult()
            {
                Data = new BackMessage()
                {
                    Code = 500,
                    Msg = "false",
                    Data = null
                }
            };
        }
    }
}
