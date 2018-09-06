using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.MQ.RabbitMQ
{
    /// <summary>
    /// 订单消息订阅者
    /// Author:胡进顺
    /// Date:2018-09-06
    /// </summary>
    public class OrdersSubscribe : Subscribe
    {
        public override void Receive(Action<string> action)
        {
            using (var connection = MQFactory.CreateRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var queueName = channel.QueueDeclare().QueueName;

                    channel.ExchangeDeclare(exchange: "Orders", type: "fanout");

                    channel.QueueBind(queue: queueName,
                             exchange: "Orders",
                             routingKey: "");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        //此处处理接收到的消息
                        action(message);
                        //Console.WriteLine(" [x] {0}", message);
                    };
                    channel.BasicConsume(queue: queueName,
                                         noAck: false,
                                         consumer: consumer);
                }
            }
        }
    }
}
