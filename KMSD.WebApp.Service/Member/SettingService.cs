using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Domain;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Repository;
using KMSD.WebApp.Service.BaseService;
using KMSD.WebApp.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMSD.WebApp.Domain.BackData;
using KMSD.WebApp.Core.Cache;

namespace KMSD.WebApp.Service.Member
{
    /// <summary>
    /// 会员中心信息设置
    /// author：胡进顺
    /// Date：2018-07-27
    /// </summary>
    public interface ISettingService : IBaseService<MemberInfoEntity>, IAutofacDependency
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="number">会员编号</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="passwordType">密码类型</param>
        /// <returns></returns>
        BackMessage ModifyPassword(string number,string oldPwd, string newPwd,PasswordType passwordType);

        /// <summary>
        /// 找回密码校验
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        BackMessage FindPassword(string number, string name, string identityNumber,out string newPwd);
    }

    /// <summary>
    /// 会员中心信息设置
    /// author：胡进顺
    /// Date：2018-07-27
    /// </summary>
    public class SettingService : BaseService<MemberInfoEntity>, ISettingService
    {
        //定义一个仓储对象，用于查询实体避免每次查询都创建出一个新的连接，调用增删改时需要重新创建连接对象
        private IBaseRepository<MemberInfoEntity> memberInfoRepository;

        public SettingService()
        {
            memberInfoRepository = this.BaseRepository();
        }

        #region 密码设置
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="number">会员编号</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="passwordType">密码类型</param>
        /// <returns></returns>
        public BackMessage ModifyPassword(string number, string oldPwd, string newPwd, PasswordType passwordType)
        {
            oldPwd = EncryptionUtil.MD5(oldPwd);

            BackMessage backMessage = new BackMessage();

            switch (passwordType)
            {
                case PasswordType.LoginPassword:

                    ModifyLoginPwd(number, oldPwd, newPwd, backMessage);

                    break;
                case PasswordType.PaymentPassword:

                    ModifyPaymentPwd(number, oldPwd, newPwd, backMessage);

                    break;
            }

            return backMessage;
        }

        private void ModifyPaymentPwd(string number, string oldPwd, string newPwd, BackMessage backMessage)
        {
            var memberInfo = memberInfoRepository.FindEntity(m => m.Number == number && m.Advpass == oldPwd);

            if (memberInfo.IsNull())
            {
                backMessage.Code = 500;
                backMessage.Msg = "原始密码错误！";
            }
            else
            {
                memberInfo.Advpass = EncryptionUtil.MD5(newPwd);
                memberInfo.AdvTime = DateTime.UtcNow;
                if (memberInfoRepository.Update(memberInfo) > 0)
                {
                    backMessage.Code = 200;
                    backMessage.Msg = "success";
                }
            }
        }

        private void ModifyLoginPwd(string number, string oldPwd, string newPwd, BackMessage backMessage)
        {
            var memberInfo = memberInfoRepository.FindEntity(m => m.Number == number && m.LoginPass == oldPwd);

            if (memberInfo.IsNull())
            {
                backMessage.Code = 500;
                backMessage.Msg = "原始密码错误！";
            }
            else
            {
                memberInfo.LoginPass = EncryptionUtil.MD5(newPwd);
                if (memberInfoRepository.Update(memberInfo) > 0)
                {
                    backMessage.Code = 200;
                    backMessage.Msg = "success";
                }
            }
        }
        #endregion

        #region 找回密码校验

        public BackMessage FindPassword(string number,string name,string identityNumber,out string newPwd)
        {
            BackMessage backMessage = new BackMessage();

            var memberInfo = memberInfoRepository.FindEntity(m => m.Number == number && m.PaperNumber == identityNumber && m.Name==name); 
            if(memberInfo == null)
            {
                newPwd = null;
                backMessage.Code = 500;
                backMessage.Msg = "用户名或姓名或证件号错误！";
                backMessage.Data = null;
            }
            else
            {
                newPwd = new Random().Next(1111111, 999999).ToString().PadLeft(6, '0');

                memberInfo.LoginPass = newPwd;

                if (memberInfoRepository.Update(memberInfo) > 0)
                {
                    backMessage.Code = 200;
                    backMessage.Msg = "success";
                }
            }

            return backMessage;
        }

        #endregion


    }
}
