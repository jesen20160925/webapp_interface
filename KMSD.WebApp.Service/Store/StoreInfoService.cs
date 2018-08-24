using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Repository;
using KMSD.WebApp.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service.Store
{
    /// <summary>
    /// 店铺业务类
    /// Author:胡进顺
    /// Date:2018-08-21
    /// </summary>
    public interface IStoreInfoService : IBaseService<StoreInfoEntity>, IAutofacDependency
    {
        /// <summary>
        /// 根据服务中心编号获取服务中心负责人姓名
        /// </summary>
        /// <param name="storeId">服务中心编号</param>
        /// <returns></returns>
        string GetStoreName(string storeId);
    }

    public class StoreInfoService : BaseService<StoreInfoEntity>, IStoreInfoService
    {
        private IBaseRepository<StoreInfoEntity> repository;

        public StoreInfoService()
        {
            repository = this.BaseRepository();
        }

        public string GetStoreName(string storeId)
        {
            var storeInfo = base.GetEntity(s => s.StoreID == storeId);
            return storeInfo == null ? null : storeInfo.Name.Replace(1, storeInfo.Name.Length - 2, "*");
        }
    }
}
