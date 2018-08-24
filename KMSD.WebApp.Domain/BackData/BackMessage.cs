using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.BackData
{
    /// <summary>
    /// 返回数据基类
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class BackMessage
    {
        /// <summary>
        /// 状态码 成功 200
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

    }
}
