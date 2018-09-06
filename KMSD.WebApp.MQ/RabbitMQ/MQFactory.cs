using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RabbitMQ.Client;

namespace KMSD.WebApp.MQ.RabbitMQ
{
    /// <summary>
    /// 消息队列工厂
    /// Author:胡进顺
    /// Date:2018-09-06
    /// </summary>
    public class MQFactory
    {
        private static string HostName = ConfigurationManager.AppSettings["rabbitmq.HostName"];
             
        private static string UserName = ConfigurationManager.AppSettings["rabbitmq.UserName"];
                
        private static string Password = ConfigurationManager.AppSettings["rabbitmq.Password"];
               
        private static string VHost = ConfigurationManager.AppSettings["rabbitmq.VirtualHost"];
             
        private static string Uri = ConfigurationManager.AppSettings["rabbitmq.Uri"];
            
        private static int Port = (ConfigurationManager.AppSettings["rabbitmq.Port"] ?? "5672").ToInt32OrDefault();
                
        private static IConnection _iConnection;
                
        public static IConnection CreateRabbitMQConnection()
        {
            if(_iConnection == null)
            {
                _iConnection = new ConnectionFactory()
                {
                    HostName = HostName,
                    UserName = UserName,
                    Password = Password,
                    VirtualHost = VHost,
                    Port = Port,
                    Uri = Uri
                }.CreateConnection();
            }

            return _iConnection;
        }
    }
}
