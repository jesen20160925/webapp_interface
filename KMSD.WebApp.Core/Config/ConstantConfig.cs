using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Config
{
    /// <summary>
    /// 统一常用配置值管理
    /// Author:胡进顺
    /// Date: 2018-08-22
    /// </summary>
    public class ConstantConfig
    {
        /// <summary>
        /// 续约年缴费用
        /// </summary>
        public static readonly decimal YEAR_CONTRACT_FEE = 100m;

        /// <summary>
        /// 续约永久费用
        /// </summary>
        public static readonly decimal FOREVER_CONTRACT_FEE = 300m;
    }
}
