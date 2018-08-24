using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMSD.WebApp.Log
{
    /// <summary>
    /// 日志消息
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class LogMessage
    {
        private HttpContext context;

        public LogMessage(HttpContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get { return DateTime.Now; }  }
        /// <summary>
        /// Url地址
        /// </summary>
        public string Url { get { return context.Request.RawUrl; }  }
        
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get { return context.Request.UserHostAddress; } }
       
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get { return context.Request.Browser.ToString(); } }
        /// <summary>
        /// 操作人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionInfo { get; set; }
       
    }
}
