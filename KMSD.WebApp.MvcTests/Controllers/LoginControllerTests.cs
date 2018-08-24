using NUnit.Framework;
using KMSD.WebApp.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMSD.WebApp.Service;
using System.Reflection;
using Autofac;
using System.IO;
using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Data.EF;
using KMSD.WebApp.Data;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using KMSD.WebApp.Service.Member;

namespace KMSD.WebApp.Mvc.Controllers.Tests
{
    [TestFixture()]
    public class LoginControllerTests
    {
        [Test()]
        public void VistorTest()
        {
            IMemberInfoService memberInfoService = new MemberInfoService();
            ILoginService service = new LoginService(memberInfoService);

            var p = service.GetVisitorPermission();

            var ps =  Core.Util.SerializeUtil.DeserializeToObject<PS>(Core.Util.SerializeUtil.SerializeToString(p.Data));

            Assert.AreEqual("33002222000020022220000000000000000000000", ps.PermissionString);
        }
        [SetUp()]
        protected void AutofacInit()
        {
            //实现自动注入
            var builder = new ContainerBuilder();

           // Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();

            //注册所有实现了 IAutofacDependency 接口的类型
           // Type baseType = typeof(IAutofacDependency);

            //builder.RegisterAssemblyTypes(assemblies)
            //       .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
            //       .AsSelf().AsImplementedInterfaces()
            //       .PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterType<KmDbContext>().Named<IDbContext>(DatabaseType.SqlServer.ToString()).InstancePerDependency();

            builder.RegisterType<KmDbContext>().As<IDbContext>().InstancePerDependency();

            builder.RegisterType<SqlDataBase>().As<IDatabase>().InstancePerDependency();

            //自动注册控制器
          //  builder.RegisterControllers(assemblies);
            //builder.RegisterFilterProvider();

            var container = builder.Build();

            //下面就是使用MVC的扩展 更改了MVC中的注入方式.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AutofacContainerManager.Instance.SetContainer(container); // 注册一个容器以便后续使用
        }
    }

    class PS
    {
        public string PermissionString { get; set; }
    }
}

