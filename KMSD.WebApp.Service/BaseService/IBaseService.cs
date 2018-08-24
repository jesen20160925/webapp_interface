using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service.BaseService
{
    /// <summary>
    /// 描  述：业务逻辑层基类接口(增删改查)
    /// 创建人：胡进顺
    /// 日  期：2018-07-18
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> where T : class,new()
    {
        int AddEntity(T entity);

        int AddEntity(List<T> entity);

        int ModifyEntity(T entity);

        int ModifyEntity(List<T> entity);

        int ModifyEntity(Expression<Func<T, bool>> condition);
       
        int RemoveEntity(T entity);

        int RemoveEntity(List<T> entity);

        int RemoveEntity(Expression<Func<T, bool>> condition);

        T GetEntity(object key);

        T GetEntity(Expression<Func<T, bool>> predicate);

    }
}
