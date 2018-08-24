using KMSD.WebApp.Core.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Repository
{
    /// <summary>
    /// 带泛型的仓储接口,提供增删改查，每次通过Sql查询需要重新创建对象，因为每次查询后连接已释放
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public interface IBaseRepository<T> where T:class,new()
    {
        IBaseRepository<T> BeginTrans();
        void Commit();
        void Rollback();

        int ExecuteBySql(string strSql);
        int ExecuteBySql(string strSql, params DbParameter[] dbParameter);
        int ExecuteByProc(string procName);
        int ExecuteByProc(string procName, params DbParameter[] dbParameter);

        int Insert(T entity);
        int Insert(List<T> entity);
        int Delete();
        int Delete(T entity);
        int Delete(List<T> entity);
        int Delete(Expression<Func<T, bool>> condition);
        int Delete(object keyValue);
        int Delete(object[] keyValue);
        int Delete(object propertyValue, string propertyName);
        int Update(T entity);
        int Update(List<T> entity);
        int Update(Expression<Func<T, bool>> condition);

        T FindEntity(object keyValue);
        T FindEntity(Expression<Func<T, bool>> condition);
        IQueryable<T> IQueryable();
        IQueryable<T> IQueryable(Expression<Func<T, bool>> condition);
        IEnumerable<T> FindList(string strSql);
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition);
        IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter);
        IEnumerable<T> FindList(Pagination pagination);
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition, Pagination pagination);
        IEnumerable<T> FindList(string strSql, Pagination pagination);
        IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter, Pagination pagination);

        DataTable FindTable(string strSql);
        DataTable FindTable(string strSql, DbParameter[] dbParameter);
        DataTable FindTable(string strSql, Pagination pagination);
        DataTable FindTable(string strSql, DbParameter[] dbParameter, Pagination pagination);
        object FindObject(string strSql);
        object FindObject(string strSql, DbParameter[] dbParameter);
    }
}
