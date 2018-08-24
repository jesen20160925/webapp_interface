using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Model
{
    /// <summary>
    /// 用户的登录信息模型
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 系统类别
        /// </summary>
        public string SystemValue { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 实名状态
        /// </summary>
        public int RealName { get; set; }

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
        public int LevelInt { get; set; }

        /// <summary>
        /// 会员职称
        /// </summary>
        public int LevelTitle { get; set; }

        /// <summary>
        /// 是否合伙人
        /// </summary>
        public int IsPartner { get; set; }

        /// <summary>
        /// 是否健康管理中心
        /// </summary>
        public int IsHealthManageCenter { get; set; }



        /// <summary>
        /// 会员是否已过实名期
        /// </summary>
        public int ValidBlack { get; set; }
        /// <summary>
        /// 续约是否到期
        /// </summary>
        public int Expired { get; set; }
        /// <summary>
        /// 禁止登陆黑名单
        /// </summary>
        public int BlackList { get; set; }
        /// <summary>
        /// 验证状态
        /// </summary>
        public int MemberState { get; set; }
        /// <summary>
        /// 限制区域登陆
        /// </summary>
        public int LimitLogin { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary> 
        public string MobileTele { get; set; }

        /// <summary>
        ///  身份证号码
        /// </summary> 
        public string PaperNumber { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCard { get; set; }
        /// <summary>
        /// 上次登录的时间
        /// </summary>
        public DateTime LastLoginDate { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
