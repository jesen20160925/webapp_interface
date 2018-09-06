using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.MQ.RabbitMQ
{
    /// <summary>
    /// 消息发布者抽象类
    /// Author:胡进顺
    /// Date:2018-09-06
    /// </summary>
    public abstract class Publish
    {
        public abstract void Send(string message);
    }
}
