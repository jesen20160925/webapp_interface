using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.JobScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicesToRun = new ServiceBase[]
           {
                  new QuartzService()
           };
            ServiceBase.Run(servicesToRun);
        }
    }
}
