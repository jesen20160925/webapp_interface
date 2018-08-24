using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Core.Result;
using KMSD.WebApp.Domain;
using KMSD.WebApp.Domain.BackData;
using KMSD.WebApp.Domain.Dto;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Repository;
using KMSD.WebApp.Service.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service.Member
{
    /// <summary>
    /// 会员注册
    /// author：胡进顺
    /// date：2018-08-06
    /// </summary>
    public interface IRegisterService : IAutofacDependency
    {
        /// <summary>
        /// 获取新编号
        /// </summary>
        /// <returns></returns>
        string GetMemberNumber();

        /// <summary>
        /// 注册表单校验
        /// </summary>
        /// <param name="registerInfo"></param>
        /// <returns></returns>
        bool RegisterCheck(RegisterDto registerInfo,out string errMsg);
    }

    public class RegisterService : BaseRepositoryFactory, IRegisterService
    {
        #region 构造
        private IRepository repository;

        public RegisterService()
        {
            repository = this.BaseRepository();
        } 
        #endregion

        #region 获取新编号
        /// <summary>
        /// 获取新编号
        /// </summary>
        /// <returns></returns>
        public string GetMemberNumber()
        {
            System.Random r = new Random();
            string number = r.Next(11111111, 99999999).ToString();
            string[] str = new string[] { "0", "1", "2", "3", "5", "6", "8", "9" };
            number = number.Replace("4", str[r.Next(0, 7)]);
            number = number.Replace("7", str[r.Next(0, 7)]);
            return number;
        } 
        #endregion

        #region 注册表单校验
        /// <summary>
        /// 注册表单校验
        /// </summary>
        /// <param name="registerInfo"></param>
        /// <returns></returns>
        public bool RegisterCheck(RegisterDto registerInfo, out string errMsg)
        {
            errMsg = string.Empty;
            if (!ValidateService.CheckNumberExist(registerInfo.DirectNumber))
            {
                errMsg = "推荐编号不存在！";
                return false;
            }

            if (!ValidateService.CheckIDCard(registerInfo.IdentityId))
            {
                errMsg = "身份证号码错误！";
                return false;
            }

            if (!ValidateService.CheckAge(registerInfo.IdentityId, !registerInfo.InsuranceType.Equals(InsuranceType.None), out errMsg))
            {
                return false;
            }

            if(ValidateService.IsIdentiyIdRegistOver7(registerInfo.IdentityId,registerInfo.Level == LevelInt.SpecialVip))
            {
                errMsg = "一个身份证最多可以注册7个会员！";
                return false;
            }

            if(ValidateService.IsMobilePhoneRegistOver7(registerInfo.MobilePhone,registerInfo.Level == LevelInt.SpecialVip))
            {
                errMsg = "一个身份证最多可以注册7个会员！";
                return false;
            }

            return true;
        } 
        #endregion
    }
}
