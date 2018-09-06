using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.MQ.RabbitMQ
{
    /// <summary>
    /// 消息订阅者抽象类
    /// Author：胡进顺
    /// Date:2018-09-06
    /// </summary>
    public abstract class Subscribe
    {
        public abstract void Receive(Action<string> action);
        
    }
}
