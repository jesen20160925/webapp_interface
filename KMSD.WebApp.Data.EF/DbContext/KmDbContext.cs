using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using KMSD.WebApp.Domain.Entity;
using KMSD.WebApp.Domain.Mapping;

namespace KMSD.WebApp.Data.EF
{
    public class KmDbContext : DbContext,IDbContext
    {
         #region 构造函数
        /// <summary>
        /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
        /// </summary>
        /// <param name="connString"></param>
        public KmDbContext(string connString)
            : base(connString)
        {
            //this.Configuration.AutoDetectChangesEnabled = false;
            //this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false; //禁用延迟加载
            //this.Configuration.ProxyCreationEnabled = false;
        }
        #endregion

        #region 重载
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("KMSD.WebApp.Data.EF.DLL", "KMSD.WebApp.Domain.dll").Replace("file:///", "");
            //Assembly asm = Assembly.LoadFile(assembleFileName);
            //var typesToRegister = asm.GetTypes()
            //.Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            modelBuilder.Configurations.Add(new MenuPermissionMap());
            modelBuilder.Configurations.Add(new MemberInfoMap());
            modelBuilder.Configurations.Add(new MemberRoleMap());
            modelBuilder.Configurations.Add(new MemberMenuMap());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        public DbSet<MenuPermissionEntity> MenuPermission { get; set; }
        public DbSet<MemberInfoEntity> MemberInfo { get; set; }
        public DbSet<MemberRoleEntity> MemberRole { get; set; }
        public DbSet<MemberMenuEntity> MemberMenu { get; set; }
        public DbSet<StoreInfoEntity> StoreInfo { get; set; }
    }
}
