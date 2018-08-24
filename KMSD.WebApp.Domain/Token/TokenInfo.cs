using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Token
{
    /// <summary>
    /// Token封装类
    /// author:胡进顺
    /// date:2018-07-24
    /// </summary>
    public class TokenInfo
    {
        public string Number { get; set; }

        public string IMEI { get; set; }

        public string Expire { get; set; }
    }
}
