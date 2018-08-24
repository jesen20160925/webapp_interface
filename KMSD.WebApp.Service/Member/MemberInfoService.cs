using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Repository;
using KMSD.WebApp.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service.Member
{
    /// <summary>
    /// 会员信息接口
    /// author：胡进顺
    /// date：2018-08-03
    /// </summary>
    public interface IMemberInfoService : IBaseService<MemberInfoEntity>, IAutofacDependency
    {
        /// <summary>
        /// 购物积分余额
        /// </summary>
        /// <param name="number">会员编号</param>
        /// <returns></returns>
        decimal GetMemberShoppingPv(string number);

        /// <summary>
        /// 体验积分余额
        /// </summary>
        /// <param name="number">会员编号</param>
        /// <returns></returns>
        decimal GetMemberExperiencePv(string number);

        /// <summary>
        /// 获取会员姓名
        /// </summary>
        /// <param name="number">会员编号</param>
        /// <returns></returns>
        string GetMemberName(string number);
    }

    /// <summary>
    /// 会员信息接口
    /// author：胡进顺
    /// date：2018-08-03
    /// </summary>
    public class MemberInfoService : BaseService<MemberInfoEntity>, IMemberInfoService
    {
        private IBaseRepository<MemberInfoEntity> repository;
        public MemberInfoService()
        {
            repository = this.BaseRepository();
        }

        public decimal GetMemberExperiencePv(string number)
        {
            var memberInfo = repository.FindEntity(m => m.Number == number);
            if(memberInfo == null)
            {
                return 0;
            }
            else
            {
                return (decimal)(memberInfo.fuxiaoin - memberInfo.fuxiaoout);
            }
            
        }

        public decimal GetMemberShoppingPv(string number)
        {
            var memberInfo = repository.FindEntity(m => m.Number == number);
            if (memberInfo == null)
            {
                return 0;
            }
            else
            {
                return (decimal)(memberInfo.Jackpot - memberInfo.Out);
            }
        }

        public string GetMemberName(string number)
        {
            var memberInfo = repository.FindEntity(m => m.Number == number);

            return memberInfo == null ? null : memberInfo.Name.Replace(1, memberInfo.Name.Length - 2, "*");
        }
    }
}
