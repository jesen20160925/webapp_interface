using KMSD.WebApp.Data;
using KMSD.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Repository
{
    /// <summary>
    /// 泛型仓储工厂
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryFactory<T> where T : class,new()
    {
        /// <summary>
        /// 定义仓储
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        public IBaseRepository<T> BaseRepository(string connString)
        {
            return new BaseRepository<T>(DbFactory.Base(connString, DatabaseType.SqlServer));
        }

        /// <summary>
        /// 定义仓储（基础库）
        /// </summary>
        /// <returns></returns>
        public IBaseRepository<T> BaseRepository()
        {
            return new BaseRepository<T>(DbFactory.Base());
        }
    }
}
