using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain
{
    /// <summary>
    /// 会员级别
    /// </summary>
    public enum LevelInt
    {
        /// <summary>
        /// 银卡
        /// </summary>
        Silver = 2,

        /// <summary>
        /// 金卡
        /// </summary>
        Golden = 3,

        /// <summary>
        /// 钻卡
        /// </summary>
        Diamon = 4,

        /// <summary>
        /// 易创VIP
        /// </summary>
        YcVip = 5,

        /// <summary>
        /// 特级VIP
        /// </summary>
        SpecialVip = 999
    }

    /// <summary>
    /// 会员职称
    /// </summary>
    public enum LevelTitle
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,

        /// <summary>
        /// 见习主任
        /// </summary>
        OfficerTrainee = 1,

        /// <summary>
        /// 主任
        /// </summary>
        Officer = 2,

        /// <summary>
        /// 高级主任
        /// </summary>
        SeniorOfficer = 3,

        /// <summary>
        /// 经理
        /// </summary>
        Manager = 4,

        /// <summary>
        /// 高级经理
        /// </summary>
        SeniorManager = 5,

        /// <summary>
        /// 总监
        /// </summary>
        SuperIntendent = 6,

        /// <summary>
        /// 高级总监
        /// </summary>
        SeniorSuperIntendent = 7,

        /// <summary>
        /// 首席总监
        /// </summary>
        ChiefDirector = 8,
    }


    public enum PasswordType
    {
        /// <summary>
        /// 登录密码(一级密码）
        /// </summary>
        LoginPassword = 1,

        /// <summary>
        /// 支付密码（二级密码）
        /// </summary>
        PaymentPassword = 2
    }

    public enum RolePermissionType
    {
        /// <summary>
        /// 游客权限 1
        /// </summary>
        Visitor = 1,

        /// <summary>
        /// 准会员
        /// </summary>
        PreMember = 2,

        /// <summary>
        /// 银卡
        /// </summary>
        SilverCard = 3,

        /// <summary>
        /// 金卡
        /// </summary>
        GoldenCard = 4,

        /// <summary>
        /// 钻卡
        /// </summary>
        DiamondCard = 5,

        /// <summary>
        /// 易创VIP
        /// </summary>
        YcVip = 6,

        /// <summary>
        /// 见习主任
        /// </summary>
        OfficerTrainee = 7,

        /// <summary>
        /// 主任
        /// </summary>
        Officer = 8,

        /// <summary>
        /// 高级主任
        /// </summary>
        SeniorOfficer = 9,

        /// <summary>
        /// 经理
        /// </summary>
        Manager = 10,

        /// <summary>
        /// 高级经理
        /// </summary>
        SeniorManager = 11,

        /// <summary>
        /// 总监
        /// </summary>
        SuperIntendent = 12,

        /// <summary>
        /// 高级总监
        /// </summary>
        SeniorSuperIntendent = 13,

        /// <summary>
        /// 首席总监
        /// </summary>
        ChiefDirector = 14,

        /// <summary>
        /// 服务中心
        /// </summary>
        ServiceCenter = 15,

        /// <summary>
        /// 健康管理中心
        /// </summary>
        HealthManageCenter = 16,

        /// <summary>
        /// 合伙人
        /// </summary>
        Partner = 17

    }

    /// <summary>
    /// 参保类型
    /// </summary>
    public enum InsuranceType
    {
        /// <summary>
        /// 无（不购买保险）
        /// </summary>
        None = 0,

        /// <summary>
        /// A级会员
        /// </summary>
        AType = 1,

        /// <summary>
        /// B级会员
        /// </summary>
        BType=2,
    }


    /// <summary>
    /// 续约类型
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// 年缴
        /// </summary>
        YearContract = 0,

        /// <summary>
        /// 永久续约
        /// </summary>
        ForeverContract = 1
    }
}
