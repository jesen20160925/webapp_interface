using Autofac;
using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KMSD.WebApp.Repository
{
    /// <summary>
    /// 数据工厂
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class DbFactory
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <param name="DbType">数据库类型</param>
        /// <returns></returns>
        public static IDatabase Base(string connString, DatabaseType DbType)
        {
            DbHelper.DbType = DbType;
            return AutofacContainerManager.Instance.Resolve<IDatabase>(new NamedParameter[]{ new NamedParameter("connString", connString), new NamedParameter("DbType", DbType.ToString())});
        }

        /// <summary>
        /// 连接基础库
        /// </summary>
        /// <returns></returns>
        public static IDatabase Base()
        {
            return AutofacContainerManager.Instance.Resolve<IDatabase>(new NamedParameter[]{ new NamedParameter("connString", "BaseDb"), new NamedParameter("DbType", "")});
        }
    }
}
