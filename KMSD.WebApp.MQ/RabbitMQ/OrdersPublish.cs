using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.MQ.RabbitMQ
{
    /// <summary>
    /// 订单信息发布者
    /// Author:胡进顺
    /// Date:2018-09-06
    /// </summary>
    public class OrdersPublish : Publish
    {
        public override void Send(string message)
        {
            using (var connection = MQFactory.CreateRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange:"Orders",type : "fanout");

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "logs",
                                         routingKey: "",
                                         basicProperties: null,
                                         body: body);
                }
            }
        }
    }
}
