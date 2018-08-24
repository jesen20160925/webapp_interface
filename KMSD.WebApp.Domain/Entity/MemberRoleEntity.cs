using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Entity
{
    public class MemberRoleEntity
    {

        /// <summary>
        /// 角色Id
        /// </summary>        
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>        
        public string RoleName { get; set; }

        /// <summary>
        /// 权限
        /// </summary>        
        public string MenuPermission { get; set; }


    }
}
