
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Entity
{
    public class MemberInfoEntity
    {
        /// <summary>
        /// 会员基本信息表 标识列 自增
        /// </summary>        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 会员编号
        /// </summary>        
        public string Number { get; set; }

        /// <summary>
        /// 安置人编号
        /// </summary>        
        public string Placement { get; set; }

        /// <summary>
        /// 推荐人编号
        /// </summary>        
        public string Direct { get; set; }

        /// <summary>
        /// 期数
        /// </summary>        
        public int? ExpectNum { get; set; }

        /// <summary>
        /// 首次报单号
        /// </summary>        
        public string OrderID { get; set; }

        /// <summary>
        /// 所属店铺编号
        /// </summary>        
        public string StoreID { get; set; }

        /// <summary>
        /// 本人真实姓名
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>        
        public string PetName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>        
        public string LoginPass { get; set; }

        /// <summary>
        /// 电子账户密码
        /// </summary>        
        public string Advpass { get; set; }

        /// <summary>
        /// 级别数字
        /// </summary>        
        public int? LevelInt { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>        
        public DateTime? RegisterDate { get; set; }

        /// <summary>
        /// 激活时间
        /// </summary>        
        public DateTime? ActiveDate { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>        
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary>        
        public int? Sex { get; set; }

        /// <summary>
        /// 会员状态（0：未激活。1：已激活。2：已注销。3：已冻结。）
        /// </summary>        
        public int MemberState { get; set; }

        /// <summary>
        /// 家庭电话
        /// </summary>        
        public string HomeTele { get; set; }

        /// <summary>
        /// 办公电话
        /// </summary>        
        public string OfficeTele { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>        
        public string MobileTele { get; set; }

        /// <summary>
        /// 传真号码
        /// </summary>        
        public string FaxTele { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string CPCCode { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>        
        public string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>        
        public string PostalCode { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>        
        public string PaperTypeCode { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>        
        public string PaperNumber { get; set; }

        /// <summary>
        /// 银行
        /// </summary>        
        public string BankCode { get; set; }

        /// <summary>
        /// 分行名称
        /// </summary>        
        public string BankBranchName { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string BCPCCode { get; set; }

        /// <summary>
        /// 银行详细地址
        /// </summary>        
        public string BankAddress { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>        
        public string BankCard { get; set; }

        /// <summary>
        /// 开户名
        /// </summary>        
        public string BankBook { get; set; }

        /// <summary>
        /// 备注
        /// </summary>        
        public string Remark { get; set; }

        /// <summary>
        /// 发放奖金的标识
        /// </summary>        
        public int? Release { get; set; }

        /// <summary>
        /// 累积的奖金和其它会员转账来的金额(不包括未汇出款的金额)
        /// </summary>        
        public decimal? Jackpot { get; set; }

        /// <summary>
        /// 奖金转出累计
        /// </summary>        
        public decimal? Out { get; set; }

        /// <summary>
        /// 会员申请要发放的奖金数在公司审核时应该进减去操作
        /// </summary>        
        public decimal? MemberShip { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? TotalRemittances { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? TotalDefray { get; set; }

        /// <summary>
        /// Email
        /// </summary>        
        public string Email { get; set; }

        /// <summary>
        /// 标识
        /// </summary>        
        public int? Flag { get; set; }

        /// <summary>
        /// 找回密码答案
        /// </summary>        
        public string Answer { get; set; }

        /// <summary>
        /// 找回密码问题
        /// </summary>        
        public string Question { get; set; }

        /// <summary>
        /// 照片路径
        /// </summary>        
        public string PhotoPath { get; set; }

        /// <summary>
        /// VIP会员卡号
        /// </summary>        
        public int? VIPCard { get; set; }

        /// <summary>
        /// 是否是批量注册
        /// </summary>        
        public byte? IsBatch { get; set; }

        /// <summary>
        /// 登录语言
        /// </summary>        
        public int? Language { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>        
        public string Error { get; set; }

        /// <summary>
        /// 1是左区，2是右区
        /// </summary>        
        public int? District { get; set; }

        /// <summary>
        /// 记录会员最后一次的访问时间
        /// </summary>        
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 操作者IP
        /// </summary>        
        public string OperateIP { get; set; }

        /// <summary>
        /// 操作者编号
        /// </summary>        
        public string OperaterNum { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string ChangeInfo { get; set; }

        /// <summary>
        /// 0表示按照IP显示时间，1表示按照国家显示时间
        /// </summary>        
        public int? DisplayTimeType { get; set; }

        /// <summary>
        /// 最新的公告是否阅读
        /// </summary>        
        public int? GongGaoType { get; set; }

        /// <summary>
        /// 起点会员编号
        /// </summary>        
        public int? DefaultNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int? AdvCount { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public DateTime? AdvTime { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int? XuHao { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string Assister { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int BankID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int IsConfirm { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? fuxiaoin { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? fuxiaoout { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string oldNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string txCode { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? oldpv { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? Fund { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int? isFaFang { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int? isTeamLeader { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string teamName { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int km_Status { get; set; }

        /// <summary>
        /// 用于保存银行信息是否已经编辑过，0为未编辑，1为已编辑，默认为已编辑，下发被退回的全部置为未编辑
        /// </summary>        
        public int? BankIsEdit { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string km_Popup { get; set; }

        /// <summary>
        /// 默认空，仅用于超级VIP，主编号
        /// </summary>        
        public string VIPTop { get; set; }

        /// <summary>
        /// 默认空，仅用于超级VIP，左副编号
        /// </summary>        
        public string VIPLeft { get; set; }

        /// <summary>
        /// 默认空，仅用于超级VIP，右副编号
        /// </summary>        
        public string VIPRight { get; set; }

        /// <summary>
        /// 默认0，标识当前编号的超级VIP相关状态。0:普通编号；1:超级VIP主编号；2:左副编号；3:右副编号。
        /// </summary>        
        public int VIPStatus { get; set; }

        /// <summary>
        /// 默认0，会员注册订单支付时的期数。
        /// </summary>        
        public int PayExpectNum { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string MarketName { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? VIPRegisterPv { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string MarketNameSenior { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string MemberClass { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int? openCashOut { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public DateTime? openCashOutTime { get; set; }


    }
}
