using KMSD.WebApp.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Data.EF
{
    public interface IDbContext : IDisposable, IObjectContextAdapter, IAutofacDependency
    {
    }
}
