using KMSD.WebApp.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Threading;
using KMSD.WebApp.Core.JWT;
using KMSD.WebApp.Domain.Token;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Data;
using KMSD.WebApp.Data.EF;

namespace KMSD.WebApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Log4net
            {
                DateTime st = DateTime.Now;
                var log4netFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XmlConfig/log4net.config");
                var log4netFileInfo = new System.IO.FileInfo(log4netFilePath);
                log4net.Config.XmlConfigurator.Configure(log4netFileInfo);
                DateTime et = DateTime.Now;
                LogUtility.WebLogger.InfoFormat("系统启动，log4net初始化启动时间：{0}秒", (et - st).TotalSeconds);
            }

            //DI
            {
                AutofacInit();
            }

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void AutofacInit()
        {
            //实现自动注入
            var builder = new ContainerBuilder();

            Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();

            //注册所有实现了IAutofacDependency 接口的类型
            Type baseType = typeof(IAutofacDependency);

            builder.RegisterAssemblyTypes(assemblies)
                   .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                   .AsSelf().AsImplementedInterfaces()
                   .PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterType<KmDbContext>().Named<IDbContext>(DatabaseType.SqlServer.ToString()).InstancePerDependency();

            builder.RegisterType<KmDbContext>().As<IDbContext>().InstancePerDependency();

            builder.RegisterType<SqlDataBase>().As<IDatabase>().InstancePerDependency();
           
            //自动注册控制器
            builder.RegisterControllers(assemblies);
            //builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AutofacContainerManager.Instance.SetContainer(container); // 注册一个容器以便后续使用
        }
    }
}
