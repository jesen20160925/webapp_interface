using KMSD.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service.BaseService
{
    /// <summary>
    /// 描  述：业务逻辑层基类(增删改查)
    /// 创建人：胡进顺
    /// 日  期：2018-07-18
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : RepositoryFactory<T>, IBaseService<T> where T:class,new()
    {
        #region 新增实体
        public int AddEntity(T entity)
        {
            return this.BaseRepository().Insert(entity);
        }

        public int AddEntity(List<T> entity)
        {
            return this.BaseRepository().Insert(entity);
        } 
        #endregion

        #region 修改实体
        public int ModifyEntity(T entity)
        {
            return this.BaseRepository().Update(entity);
        }

        public int ModifyEntity(List<T> entity)
        {
            return this.BaseRepository().Update(entity);
        }

        public int ModifyEntity(Expression<Func<T, bool>> condition)
        {
            return this.BaseRepository().Update(condition);
        } 
        #endregion

        #region 删除实体
        public int RemoveEntity(T entity)
        {
            return this.BaseRepository().Delete(entity);
        }

        public int RemoveEntity(List<T> entity)
        {
            return this.BaseRepository().Delete(entity);
        }

        public int RemoveEntity(Expression<Func<T, bool>> condition)
        {
            return this.BaseRepository().Delete(condition);
        } 
        #endregion

        #region 查找实体
        public T GetEntity(object keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }


        public T GetEntity(Expression<Func<T, bool>> predicate)
        {
            return this.BaseRepository().FindEntity(predicate);
        }
        #endregion
    }
}
