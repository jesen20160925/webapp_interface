using KMSD.WebApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Mapping
{
    public class StoreInfoMap : EntityTypeConfiguration<StoreInfoEntity>
    {
        public StoreInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("StoreInfo");

            //主键
            this.HasKey(t => t.ID);

            #endregion

        }
    }
}
