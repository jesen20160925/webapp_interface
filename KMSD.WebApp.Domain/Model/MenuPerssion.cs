using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Model
{
    public class MenuPerssion
    {
        public List<int> VisibleToLogin { get; set; }

        public List<int> VisibleUnenforceable { get; set; }

        public List<int> Executable { get; set; }
    }
}
