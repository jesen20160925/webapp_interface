using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Dto
{
    /// <summary>
    /// 会员注册
    /// </summary>
    [Serializable]
    public class RegisterDto
    {
        /// <summary>
        /// 推荐人编号
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "推荐编号不能为空！")]
        public string DirectNumber { get; set; }

        /// <summary>
        /// 服务中心编号
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "服务中心编号不能为空！")]
        public string StoreId { get; set; }

        /// <summary>
        /// 注册姓名
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "姓名不能为空！")]
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "手机号码不能为空！")]
        [RegularExpression(@"^1(?:3\d|4[4-9]|5[0-35-9]|6[67]|7[013-8]|8\d|9\d)\d{8}$", ErrorMessage = "手机号码格式不正确.")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "身份证号码不能为空！")]
        public string IdentityId { get; set; }

        /// <summary>
        /// 注册级别
        /// </summary>
        ///[Range(3, 5, ErrorMessage = "注册级别错误")]
        public LevelInt Level { get; set; }

        /// <summary>
        /// 续约类型
        /// </summary>
        public ContractType ContractType { get; set; }

        /// <summary>
        /// 百万身价俱乐部
        /// </summary>
        ///[Range(0, 2, ErrorMessage = "百万身价俱乐部错误")]
        public InsuranceType InsuranceType { get; set; }

    }
}
