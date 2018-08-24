
using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Core.JWT;
using KMSD.WebApp.Core.Util;
using KMSD.WebApp.Data.Extension;
using KMSD.WebApp.Domain;
using KMSD.WebApp.Domain.BackData;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Domain.Model;
using KMSD.WebApp.Repository;
using KMSD.WebApp.Service.Member;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service
{
    /// <summary>
    /// 登录管理
    /// author：胡进顺
    /// Date：2018-07-25
    /// </summary>
    public interface ILoginService : IAutofacDependency
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">会员编号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        BackMessage Login(string userName, string password);

        /// <summary>
        /// 获取游客权限
        /// </summary>
        /// <returns></returns>
        BackMessage GetVisitorPermission();
    }

    /// <summary>
    /// 登录管理
    /// author：胡进顺
    /// Date：2018-07-25
    /// </summary>
    public class LoginService : BaseRepositoryFactory, ILoginService
    {
        private IMemberInfoService memberInfoService;
        public LoginService(IMemberInfoService _memberInfoService)
        {
            memberInfoService = _memberInfoService;
        }


        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">会员编号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public BackMessage Login(string userName, string password)
        {
            BackMessage backMessage = new BackMessage();

            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                backMessage.Code = 500;
                backMessage.Msg = "";
                backMessage.Data = null;

                return backMessage;
            }

            #region 登录逻辑SQL
            StringBuilder sb = new StringBuilder(string.Format(@"
                    declare @systemvalue int;
                    declare @validBlack int;
                    declare @expired int;
                    declare @blackList int;
                    declare @memberState1 int;
                    declare @memberState2 int;
                    declare @limitLogin int;
                    declare @name nvarchar(100);
                    declare @sex int;
                    declare @mobileTele nvarchar(500);
                    declare @paperNumber nvarchar(500);
                    declare @defaultNumber nvarchar(100);
                    DECLARE @bankCard NVARCHAR(20);
                    DECLARE @birthday DATETIME;
                    DECLARE @lastLoginDate DATETIME;
                    DECLARE @levelint INT;
                    
                    DECLARE @realName INT;
                    DECLARE @isPreMember INT;
                    DECLARE @isStore INT;
                    DECLARE @isHealthManageCenter INT;
                    DECLARE @isPartner INT;
                    DECLARE @levelTitle INT;

                    declare @ExceptNum int=(select max(ExpectNum) from config);
                    --获取SystemValue值
                    select @systemvalue=systemvalue  from setsystem where systemname=@systemname; 
                    --会员是否已过实名期
                    Select @validBlack=Count(0) from ValidBlackData where UserGroup=1 and [Status]=1 and UserID=@userCode;
                    --续约是否到期
                    Select top 1 @expired=(CASE WHEN xuyueType=1 OR DATEDIFF(d,zhifuTime,GETDATE())<=366 THEN 0 ELSE 1 END ) 
                    from xuyueTb where isZhifu=1 and number=@userCode order by zhifuTime desc;
                    --禁止登陆黑名单
                    select @blackList=count(0) from Blacklist where UserID = @userCode;
                    --限制区域登陆
                    Select top 1 @defaultNumber=Number From MemberInfo Where DefaultNumber = 1;
                    select  @limitLogin=count(0) from memberinfo a left join blackgroup b on a.CPCCode=b.groupvalue
                    where grouptype=3 and number=@userCode AND a.Number !=@defaultNumber;
                    --密码验证
                    select @memberState1=isnull(MemberState,0) from memberinfo where (number=@userCode) 
                    and (loginpass=@pwd);

                    --会员已实名，返回1
                    if((Select Count(0) from CardInfo where MemberCode=@userCode)>0) begin select @realName = 1 end
                    --会员职称达到见习主任（含）以上
                    else begin 
                    
                    declare @postResult int=0
                    declare @sql nvarchar(500)='select @postResult=level2 from MemberInfoBalance'+convert(nvarchar(10),@ExceptNum)
                                              +' where Number=@Number'
                    exec sp_executesql @sql,N'@postResult int output,@Number nvarchar(50)',@postResult output,@userCode
                    --待审核-1，已录入返回-2，退回返回-3，未录入返回-4
                    declare @recoreResult int=4
                    Select @recoreResult=ApplyStatus from CardRecord where Number=@userCode and IsCurrent='True';
                    SELECT @realName = (CASE WHEN DATEDIFF(d,RegisterDate,GETDATE())>93 THEN -@recoreResult ELSE 2 END) FROM dbo.MemberInfo WHERE Number=@userCode;
                    end 

                    --是否准会员
                    SELECT @isPreMember=COUNT(0) FROM HandingCardInfo AS hci JOIN MemberInfo AS mi ON (mi.Number = hci.Number ) WHERE hci.Number=@userCode;

                    --是否服务中心
                    SELECT @isStore= COUNT(0) FROM StoreInfo si 
                    INNER JOIN StoreApplyManage sam ON si.StoreID=sam.StoreID 
                    WHERE si.Number=@userCode AND si.StoreState=1 AND sam.ApplyStatus=5 AND sam.IsCurrent='True';

--是否健康管理中心
SELECT @isHealthManageCenter = COUNT(0) FROM StudioApply sa WHERE sa.Number=@userCode AND sa.IsShop IN (1,2) AND sa.YCShopStatus=1;
--是否合伙人
SELECT @isPartner = COUNT(0) FROM StorePartner sp WHERE sp.PartnerNumber=@userCode AND sp.PayStatus=1;
--获取职称
declare @sql2 nvarchar(500)='select @levelTitle=level2 from MemberInfoBalance'+convert(nvarchar(10),@ExceptNum)
                                              +' where Number=@Number'
exec sp_executesql @sql2,N'@levelTitle int output,@Number nvarchar(50)',@levelTitle output,@userCode

                    --获取基本信息
                    SELECT @name=Name,@sex=Sex,@mobileTele=MobileTele,@paperNumber=PaperNumber,@bankCard=BankCard,@birthday=Birthday,@lastLoginDate=LastLoginDate,@levelint=LevelInt FROM dbo.MemberInfo WHERE Number=@userCode;
  
                    --返回登录验证信息
                    select @levelint LevelInt, @levelTitle LevelTitle, @isPartner IsPartner, @isHealthManageCenter IsHealthManageCenter, @isPreMember IsPreMember,@isStore IsStore, @realName RealName, @userCode UserCode,@systemvalue SystemValue,@validBlack ValidBlack,@expired Expired,@blackList BlackList,
                    case when @memberState1>=0 then @memberState1 else 
                    -1 end
                    --end
                    MemberState,@limitLogin LimitLogin,
                    @name Name,@sex Sex,@mobileTele MobileTele,@paperNumber PaperNumber ,@bankCard BankCard,@birthday Birthday,@lastLoginDate LastLoginDate,@levelint LevelInt;
            "));
            #endregion

            DbParameter[] parameters = new DbParameter[] {
                DbParameters.CreateDbParameter("systemname", "H", DbType.String),
                DbParameters.CreateDbParameter("userCode", userName, DbType.String),
                DbParameters.CreateDbParameter("pwd", EncryptionUtil.MD5(password), DbType.String),
            };

            var loginInfo = this.BaseRepository().FindList<LoginInfo>(sb.ToString(), parameters).FirstOrDefault();

          //  IMemberInfoService memberInfoService = new MemberInfoService();

            string errMsg;
            if (ValidateLogin(loginInfo, out  errMsg))
            {
                //登录成功后返回token
                backMessage.Code = 200;
                backMessage.Msg = "success";
                backMessage.Data = new LoginMessage()
                {
                    Token = JwtUtil.SetJwtEncode(userName),
                    PermissionString = GetHasPermission(loginInfo),
                    LoginInfo = new LoginInfoBD()
                    {
                        IsHealthManageCenter = loginInfo.IsHealthManageCenter > 0 ? 1 : 0,
                        IsPartner = loginInfo.IsPartner,
                        IsPreMember = loginInfo.IsPreMember,
                        IsStore = loginInfo.IsStore,
                        LevelInt = (LevelInt)loginInfo.LevelInt,
                        LevelTitle = (LevelTitle)loginInfo.LevelTitle,
                        Name = loginInfo.Name,
                        UserCode = loginInfo.UserCode,
                        Sex = loginInfo.Sex == 0 ? "女" : "男",
                        ShoppingPv = memberInfoService.GetMemberShoppingPv(userName),
                        ExperiencePv = memberInfoService.GetMemberExperiencePv(userName)
                    }
                };
            }
            else
            {
                backMessage.Code = 500;
                backMessage.Msg = errMsg;
                backMessage.Data = null;
            }

            return backMessage;
        }

        private bool ValidateLogin(LoginInfo loginInfo, out string errMsg)
        {
            errMsg = string.Empty;

            #region 系统开关

            bool isOpen = loginInfo.SystemValue == "1";
            if (!isOpen)
            {
                errMsg = "当前系统禁止登陆!";
            }

            #endregion

            #region 检查会员是否已过实名期

            bool isExpire = true;
            if (loginInfo.ValidBlack == 0)
            {
                isExpire = false;
            }
            if (isExpire)
            {
                //todo:实名认证处理
                if (loginInfo.RealName == 0)
                {
                    errMsg = "您已超出实名认证的期限，请及时到服务中心进行实名认证，认证成功后方可重新登陆!";
                }
                else if (loginInfo.RealName < -4)
                {
                    errMsg = "您好！您的实名已到期，请到服务中心进行实名认证!";
                }
                else if (loginInfo.RealName == -4)
                {
                    errMsg = "您已超过实名期限,为了不影响您易创网的使用,请尽快完成实名信息采集!";
                }
            }

            #endregion

            #region 续约是否到期                    

            if (loginInfo.Expired == 1)
            {
                errMsg = "抱歉，您的续约已到期，请及时到服务中心进行续约，续约支付成功后方可重新登陆!";
            }

            #endregion

            #region 禁止登陆黑名单

            if (loginInfo.BlackList != 0)
            {
                errMsg = "对不起，您的登陆权限失效，请与公司联系!";
            }

            #endregion

            #region 限制区域登陆

            if (loginInfo.LimitLogin != 0)
            {
                errMsg = "对不起，您的登陆权限失效，请与公司联系!";
            }

            #endregion

            #region 密码验证

            if (loginInfo != null && loginInfo.MemberState > 0)
            {
                //0:未激活;4:异常
                if (loginInfo.MemberState == 0 || loginInfo.MemberState == 4)
                    errMsg = "您的编号未激活，不能进入系统!";
                else if (loginInfo.MemberState == 2)
                {
                    errMsg = "会员已注销，不能登录!";
                }

            }
            //判断非会员登录
            else if (!(loginInfo != null && (loginInfo.IsPreMember > 0) && loginInfo.MemberState == 0))
            {
                errMsg = "用户名或密码不正确!";
            }

            #endregion

            return errMsg.IsNullOrEmpty();
        }

        #endregion

        #region 获取游客权限
        /// <summary>
        /// 获取游客权限
        /// </summary>
        /// <returns></returns>
        public BackMessage GetVisitorPermission() 
        {
            return new BackMessage(){
                 Code = 200,
            Msg = "success",
            Data = new { PermissionString = GetHasPermission(null) }
            };
        }
        #endregion

        #region 获取拥有的权限

        /// <summary>
        /// 获取拥有的权限 
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns>返回字符串中对应位 0为不可见 1为可见不可访问 2为可见可访问 3为可见点击得登录</returns>
        private string GetHasPermission(LoginInfo loginInfo)
        {
            var repository = this.BaseRepository();
            int menuCount = repository.IQueryable<MemberMenuEntity>().Count();
            var roleMenuList = repository.FindList<MemberRoleEntity>(m => 1 == 1).ToList();
            StringBuilder sbPermissionString = new StringBuilder("".PadLeft(menuCount, '0'));

            if (loginInfo == null)
            {
                return GetVisitorPermission(roleMenuList, ref sbPermissionString);
            }

            sbPermissionString = GetLevelIntPermission(loginInfo, roleMenuList, sbPermissionString);

            sbPermissionString = GetLevelTitlePermission(loginInfo, roleMenuList, sbPermissionString);

            sbPermissionString = GetPreMemberPermission(loginInfo, roleMenuList, sbPermissionString);

            sbPermissionString = GetStorePermission(loginInfo, roleMenuList, sbPermissionString);

            sbPermissionString = GetPartnerPermission(loginInfo, roleMenuList, sbPermissionString);

            sbPermissionString = GetHealthCenterPermission(loginInfo, roleMenuList, sbPermissionString);

            return sbPermissionString.ToString();
        }

        private string GetVisitorPermission(List<MemberRoleEntity> roleMenuList, ref StringBuilder sbPermissionString)
        {
            sbPermissionString = GetLevelPermission(RolePermissionType.Visitor, roleMenuList, sbPermissionString);

            return sbPermissionString.ToString();
        }

        private StringBuilder GetHealthCenterPermission(LoginInfo loginInfo, List<MemberRoleEntity> roleMenuList, StringBuilder sbPermissionString)
        {
            if (!loginInfo.IsHealthManageCenter.Equals(0))
            {
                sbPermissionString = GetLevelPermission(RolePermissionType.HealthManageCenter, roleMenuList, sbPermissionString);
            }

            return sbPermissionString;
        }

        private StringBuilder GetPartnerPermission(LoginInfo loginInfo, List<MemberRoleEntity> roleMenuList, StringBuilder sbPermissionString)
        {
            if (!loginInfo.IsPartner.Equals(0))
            {
                sbPermissionString = GetLevelPermission(RolePermissionType.Partner, roleMenuList, sbPermissionString);
            }

            return sbPermissionString;
        }

        private StringBuilder GetStorePermission(LoginInfo loginInfo, List<MemberRoleEntity> roleMenuList, StringBuilder sbPermissionString)
        {
            if (!loginInfo.IsStore.Equals(0))
            {
                sbPermissionString = GetLevelPermission(RolePermissionType.ServiceCenter, roleMenuList, sbPermissionString);
            }

            return sbPermissionString;
        }

        private StringBuilder GetPreMemberPermission(LoginInfo loginInfo, List<MemberRoleEntity> roleMenuList, StringBuilder sbPermissionString)
        {
            if (!loginInfo.IsPreMember.Equals(0))
            {
                sbPermissionString = GetLevelPermission(RolePermissionType.PreMember, roleMenuList, sbPermissionString);
            }

            return sbPermissionString;
        }

        private StringBuilder GetLevelTitlePermission(LoginInfo loginInfo, List<MemberRoleEntity> roleMenuList, StringBuilder sbPermissionString)
        {
            switch ((LevelTitle)loginInfo.LevelTitle)
            {
                case LevelTitle.ChiefDirector:
                    sbPermissionString = GetLevelPermission(RolePermissionType.ChiefDirector, roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.Manager:
                    sbPermissionString = GetLevelPermission(RolePermissionType.Manager, roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.None:
                    //sbPermissionString = GetLevelPermission(RolePermissionType., roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.Officer:
                    sbPermissionString = GetLevelPermission(RolePermissionType.Officer, roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.OfficerTrainee:
                    sbPermissionString = GetLevelPermission(RolePermissionType.OfficerTrainee, roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.SeniorManager:
                    sbPermissionString = GetLevelPermission(RolePermissionType.SeniorManager, roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.SeniorOfficer:
                    sbPermissionString = GetLevelPermission(RolePermissionType.SeniorOfficer, roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.SeniorSuperIntendent:
                    sbPermissionString = GetLevelPermission(RolePermissionType.SeniorSuperIntendent, roleMenuList, sbPermissionString);
                    break;
                case LevelTitle.SuperIntendent:
                    sbPermissionString = GetLevelPermission(RolePermissionType.SuperIntendent, roleMenuList, sbPermissionString);
                    break;
            }

            return sbPermissionString;
        }

        private StringBuilder GetLevelIntPermission(LoginInfo loginInfo, List<MemberRoleEntity> roleMenuList, StringBuilder sbPermissionString)
        {
            switch ((LevelInt)loginInfo.LevelInt)
            {
                case LevelInt.Silver:
                    sbPermissionString = GetLevelPermission(RolePermissionType.SilverCard, roleMenuList, sbPermissionString);
                    break;
                case LevelInt.Golden:
                    sbPermissionString = GetLevelPermission(RolePermissionType.GoldenCard, roleMenuList, sbPermissionString);
                    break;
                case LevelInt.Diamon:
                    sbPermissionString = GetLevelPermission(RolePermissionType.DiamondCard, roleMenuList, sbPermissionString);
                    break;
                case LevelInt.YcVip:
                    sbPermissionString = GetLevelPermission(RolePermissionType.YcVip, roleMenuList, sbPermissionString);
                    break;
            }

            return sbPermissionString;
        }

        private StringBuilder GetLevelPermission(RolePermissionType rolePerssionType, List<MemberRoleEntity> roleMenuList, StringBuilder sbPermissionString)
        {
            var roleMenu = roleMenuList.Where(m => m.RoleId == rolePerssionType.ToInt32OrDefault()).FirstOrDefault();
            if (roleMenu != null)
            {
                var menuPermission = SerializeUtil.DeserializeToObject<MenuPerssion>(roleMenu.MenuPermission);

                for (int i = 0; i < menuPermission.VisibleToLogin.Count; ++i)
                {
                    sbPermissionString.Replace('0', '3', menuPermission.VisibleToLogin[i] - 1, 1);
                }

                for (int i = 0; i < menuPermission.VisibleUnenforceable.Count; ++i)
                {
                    sbPermissionString.Replace('0', '1', menuPermission.VisibleUnenforceable[i] - 1, 1);
                }
                for (int i = 0; i < menuPermission.Executable.Count; ++i)
                {
                    sbPermissionString.Replace('0', '2', menuPermission.Executable[i] - 1, 1);
                }
            }

            return sbPermissionString;
        }

        #endregion
    }
}
