using KMSD.WebApp.Data.Extension;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service.Validate
{
    public class ValidateService : BaseRepositoryFactory
    {
        #region 校验会员编号是否存在
        /// <summary>
        /// 校验会员编号是否存在
        /// </summary>
        /// <param name="number">会员编号</param>
        /// <returns></returns>
        public static bool CheckNumberExist(string number)
        {
            using (IRepository repository = new BaseRepository(DbFactory.Base()))
            {
                return repository.FindList<MemberInfoEntity>(m => m.Number == number).FirstOrDefault() == null ? false : true;
            }
        }

        #endregion


        #region 身份证合法性验证

        /// <summary>
        /// 身份证合法性验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = _checkIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = _checkIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 18位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        private static bool _checkIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 15位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        private static bool _checkIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        #endregion

        #region 年龄校验

        /// <summary>
        /// 年龄校验
        /// </summary>
        /// <param name="IdentityId"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool CheckAge(string IdentityId, bool isJoinInsurance, out string errMsg)
        {
            errMsg = string.Empty;
            string birth = IdentityId.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = DateTime.Parse(birth);
            TimeSpan ts = DateTime.Today - time;

            if (isJoinInsurance)
            {
                if (ts.TotalDays > 60 * 365)
                {
                    errMsg = "对不起，年龄超过60周岁不符合参保要求！";
                }
            }

            if (ts.TotalDays < 22 * 365)
            {
                errMsg = "你输入的出生年月不符合大于22岁的标准！";
            }
            else if (ts.TotalDays > 80 * 365)
            {
                errMsg = "你输入的出生年月不符合小于80岁的标准！";
            }

            return errMsg.IsNullOrEmpty();
        }

        #endregion

        #region 身份证注册数超7校验

        /// <summary>
        /// 身份证注册数超7校验
        /// </summary>
        /// <param name="identiyId">身份证号</param>
        /// <param name="IsSpecialVip">是否注册特级Vip</param>
        /// <returns></returns>
        public static bool IsIdentiyIdRegistOver7(string identiyId,bool IsSpecialVip)
        {
            using (BaseRepository repository = new BaseRepository(DbFactory.Base()))
            {
                StringBuilder sb = new StringBuilder(@"select count(0) from memberinfo where PaperNumber=@PaperNumber 
AND Number NOT IN (
SELECT hci.Number FROM HandingCardInfo hci 
JOIN MemberInfo mi ON hci.Number=mi.Number
WHERE mi.MemberState=0);");

                var obj = repository.FindObject(sb.ToString(), new DbParameter[] { DbParameters.CreateDbParameter("PaperNumber", identiyId) });

                return IsSpecialVip ? obj.ToInt32OrDefault() > 4 : obj.ToInt32OrDefault() >= 7;
            }
        }

        #endregion

        #region 手机号注册数超7校验

        /// <summary>
        /// 手机号注册数超7校验
        /// </summary>
        /// <param name="mobilePhone">手机号</param>
        /// <param name="IsSpecialVip">是否注册特级Vip</param>
        /// <returns></returns>
        public static bool IsMobilePhoneRegistOver7(string mobilePhone, bool IsSpecialVip)
        {
            using (BaseRepository repository = new BaseRepository(DbFactory.Base()))
            {
                StringBuilder sb = new StringBuilder(@"select count(0) from memberinfo where MobileTele=@MobileTele 
AND Number NOT IN (
SELECT hci.Number FROM HandingCardInfo hci 
JOIN MemberInfo mi ON hci.Number=mi.Number
WHERE mi.MemberState=0);");

                var obj = repository.FindObject(sb.ToString(), new DbParameter[] { DbParameters.CreateDbParameter("MobileTele", mobilePhone) });

                return IsSpecialVip ? obj.ToInt32OrDefault() > 4 : obj.ToInt32OrDefault() >= 7;
            }
        }

        #endregion


    }
}
