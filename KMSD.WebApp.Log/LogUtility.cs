using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Log
{
    /// <summary>
    /// 日志工具类
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public static class LogUtility
    {
        public static object LogLock = new object();

        public static log4net.ILog SystemLogger { get { return GetLogger("SystemLogger"); } }
        public static log4net.ILog WebLogger { get { return GetLogger("WebLogger"); } }
        public static log4net.ILog Account { get { return GetLogger("Account"); } }
        public static log4net.ILog AdminUserInfo { get { return GetLogger("AdminUserInfo"); } }
        public static log4net.ILog DebugLogger { get { return GetLogger("DebugLogger"); } }
        public static log4net.ILog ErrorLogger { get { return GetLogger("ErrorLogger"); } }
        public static log4net.ILog OAuthLogger { get { return GetLogger("OAuthLogger"); } }
        public static log4net.ILog Order { get { return GetLogger("Order"); } }
        public static log4net.ILog Cache { get { return GetLogger("Cache"); } }

        //新建的领域可以在这里继续添加

        public static log4net.ILog GetLogger(string name)
        {
            lock (LogUtility.LogLock)
            {
                return log4net.LogManager.GetLogger(name);
            }
        }
    }
}
