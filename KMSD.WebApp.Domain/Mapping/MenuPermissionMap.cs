using KMSD.WebApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Mapping
{
    public class MenuPermissionMap : EntityTypeConfiguration<MenuPermissionEntity>
    {
        public MenuPermissionMap()
        {
            #region 表、主键
            //表
            this.ToTable("MenuPermission");
            //主键
            this.HasKey(t => t.PermissionId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
