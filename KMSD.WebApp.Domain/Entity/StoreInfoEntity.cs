using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Entity
{
    public class StoreInfoEntity
    {
        /// <summary>
        /// 店铺基本信息表 标识列 自增
        /// </summary>        
        public int ID { get; set; }

        /// <summary>
        /// 会员编号
        /// </summary>        
        public string Number { get; set; }

        /// <summary>
        /// 推荐此店的会员编号
        /// </summary>        
        public string Direct { get; set; }

        /// <summary>
        /// 店编号，不可重复
        /// </summary>        
        public string StoreID { get; set; }

        /// <summary>
        /// 店长姓名
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// 建店期数
        /// </summary>        
        public int? ExpectNum { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>        
        public string LoginPass { get; set; }

        /// <summary>
        /// 二级密码
        /// </summary>        
        public string AdvPass { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>        
        public string StoreName { get; set; }

        /// <summary>
        /// 店铺状态（0：未激活。1：已激活。2：已注销。3：已冻结。）
        /// </summary>        
        public int StoreState { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string CPCCode { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>        
        public string StoreAddress { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>        
        public string PostalCode { get; set; }

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
        /// 传真电话
        /// </summary>        
        public string FaxTele { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>        
        public string BankCode { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>        
        public string BankCard { get; set; }

        /// <summary>
        /// Email
        /// </summary>        
        public string Email { get; set; }

        /// <summary>
        /// 网址
        /// </summary>        
        public string NetAddress { get; set; }

        /// <summary>
        /// 备注
        /// </summary>        
        public string Remark { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>        
        public DateTime? RegisterDate { get; set; }

        /// <summary>
        /// 级别数字
        /// </summary>        
        public int? StoreLevelInt { get; set; }

        /// <summary>
        /// 经营面积
        /// </summary>        
        public decimal? FareArea { get; set; }

        /// <summary>
        /// 总汇款额
        /// </summary>        
        public decimal? TotalAccountMoney { get; set; }

        /// <summary>
        /// 总的订货额
        /// </summary>        
        public decimal? TotalOrderGoodMoney { get; set; }

        /// <summary>
        /// 总投资的钱，不用于报单和订货
        /// </summary>        
        public decimal? TotalInvestMoney { get; set; }

        /// <summary>
        /// 周转款
        /// </summary>        
        public decimal? TurnOverMoney { get; set; }

        /// <summary>
        /// 周转款所订的货
        /// </summary>        
        public decimal? TurnOverGoodsMoney { get; set; }

        /// <summary>
        /// 其他款项
        /// </summary>        
        public decimal? OtherMoney { get; set; }

        /// <summary>
        /// 权限人
        /// </summary>        
        public string PermissionMan { get; set; }

        /// <summary>
        /// 店铺没钱时,最大上限报单额
        /// </summary>        
        public decimal? TotalMaxMoney { get; set; }

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
        /// 登录语言
        /// </summary>        
        public int? Language { get; set; }

        /// <summary>
        /// 所用币种
        /// </summary>        
        public int? Currency { get; set; }

        /// <summary>
        /// 用来记录店铺最后一次的访问时间
        /// </summary>        
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 店铺所在城市
        /// </summary>        
        public string SCPCCode { get; set; }

        /// <summary>
        /// 操作者IP
        /// </summary>        
        public string OperateIP { get; set; }

        /// <summary>
        /// 操作者编号
        /// </summary>        
        public string OperateNum { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int? DefaultStore { get; set; }

        /// <summary>
        /// 分公司编号
        /// </summary>        
        public string BranchNumber { get; set; }

        /// <summary>
        /// 0表示按照IP显示时间，1表示按照国家显示时间
        /// </summary>        
        public int? DisplayTimeType { get; set; }

        /// <summary>
        /// 最新的公告是否阅读
        /// </summary>        
        public int? GongGaoType { get; set; }

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
        public int BankID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string bankbranchname { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string memOldStoreid { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public decimal? Fund { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string km_Popup { get; set; }

        /// <summary>
        /// 店铺状态，0为旧店铺，1为新申请店铺，2为正式店铺
        /// </summary>        
        public int km_Apply { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string EASNo { get; set; }

        /// <summary>
        /// 保证金字段
        /// </summary>        
        public decimal? PayMargin { get; set; }

        /// <summary>
        /// 具体状态 1.1 开通 1.2 大礼包激活 1.3 保证金激活 1.4 特殊激活 1.5 特殊渠道的大礼包激活 1.6 特殊渠道的保证金激活 1.7 健康管理中心激活
        /// </summary>
        public string StatusDetail { get; set; }
    }
}
