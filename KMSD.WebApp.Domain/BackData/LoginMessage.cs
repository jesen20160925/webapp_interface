using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.BackData
{
    /// <summary>
    /// 登录数据返回
    /// </summary>
    /// 
    public class LoginMessage 
    {
        public string Token { get; set; }

        public string PermissionString { get; set; }

        public LoginInfoBD LoginInfo { get; set; }
    }

    public class LoginInfoBD
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 是否准会员
        /// </summary>
        public int IsPreMember { get; set; }

        /// <summary>
        /// 是否服务中心
        /// </summary>
        public int IsStore { get; set; }

        /// <summary>
        /// 会员级别 
        /// </summary>
        public LevelInt LevelInt { get; set; }

        /// <summary>
        /// 会员职称
        /// </summary>
        public LevelTitle LevelTitle { get; set; }

        /// <summary>
        /// 是否合伙人
        /// </summary>
        public int IsPartner { get; set; }

        /// <summary>
        /// 是否健康管理中心
        /// </summary>
        public int IsHealthManageCenter { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 购物积分
        /// </summary>
        public decimal ShoppingPv { get; set; }


        /// <summary>
        /// 体验积分
        /// </summary>
        public decimal ExperiencePv { get; set; }

    }
}
