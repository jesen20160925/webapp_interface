using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Entity
{
    public class MenuPermissionEntity
    {
        public Int64 PermissionId { get; set; }

        public string RoleName { get; set; }

        public string PermissName { get; set; }
    }
}
