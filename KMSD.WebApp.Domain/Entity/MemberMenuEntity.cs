using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Entity
{
    public class MemberMenuEntity
    {  /// <summary>
       /// 菜单模块Id
       /// </summary>        
        public int MenuId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>        
        public string MenuName { get; set; }
    }
}
