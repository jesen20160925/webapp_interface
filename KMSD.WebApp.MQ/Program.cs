using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KMSD.WebApp.MQ
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "jesen";
            factory.Password = "jesen";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    bool durable = true;
                    channel.QueueDeclare("task_queue", durable, false, false, null);

                    string message = GetMessage(args);
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    //properties.SetPersistent(true);


                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "task_queue", properties, body);
                    Console.WriteLine(" set {0}", message);
                }
            }

            //Console.ReadKey();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }

    partial class Program
    {
        static void Main1(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "jesen";
            factory.Password = "jesen";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    bool durable = true;
                    channel.QueueDeclare("task_queue", durable, false, false, null);
                    channel.BasicQos(0, 1, false);

                    var consumer = new EventingBasicConsumer(channel);

                    channel.BasicConsume("task_queue", false, consumer);


                    consumer.Received += (c, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine("Received {0}", message);
                        Console.WriteLine("Done");

                        channel.BasicAck(ea.DeliveryTag, false); //设置客户端需要回复一个ack确认给服务器
                    };

                }
            }
        }


    }
}
