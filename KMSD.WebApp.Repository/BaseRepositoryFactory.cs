using KMSD.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Repository
{
    /// <summary>
    /// 不带泛型仓储工厂
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class BaseRepositoryFactory
    {
        /// <summary>
        /// 定义仓储
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        public IRepository BaseRepository(string connString)
        {
            return new BaseRepository(DbFactory.Base(connString, DatabaseType.SqlServer));
        }
        /// <summary>
        /// 定义仓储（基础库）
        /// </summary>
        /// <returns></returns>
        public IRepository BaseRepository()
        {
            return new BaseRepository(DbFactory.Base());
        }
    }
}
