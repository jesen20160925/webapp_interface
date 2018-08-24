﻿using KMSD.WebApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Mapping
{
    public class ValidBlackDataMap : EntityTypeConfiguration<ValidBlackDataEntity>
    {
        public ValidBlackDataMap()
        {
            #region 表、主键
            //表
            this.ToTable("ValidBlackData");

            //主键
            this.HasKey(t => t.ID);

            #endregion

            #region 配置关系
            #endregion
        }
    }
}