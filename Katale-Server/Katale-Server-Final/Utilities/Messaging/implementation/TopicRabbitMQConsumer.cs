using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Katale_Server_Final.Utilities.Messaging.implementation
{
    public class TopicRabbitMQConsumer : RabbitMQ, IRabbitMQConsumer
    {
        IModel channel;

        public TopicRabbitMQConsumer(string Exchange, string Queue, string RoutingKey)
        {
            channel = connection.CreateModel();
            channel.ExchangeDeclare(Exchange, ExchangeType.Topic);
            channel.QueueDeclare(Queue, false, false, false, null);
            channel.QueueBind(Queue, Exchange, RoutingKey, null);

        }

        public TopicRabbitMQConsumer()
        {
            channel = connection.CreateModel();
            channel.ExchangeDeclare(Exchange, ExchangeType.Topic);
            channel.QueueDeclare(Queue, false, false, false, null);
            channel.QueueBind(Queue, Exchange, "default", null);

        }

        public void ReceiveAsync()
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, args) =>
            {
                channel.BasicAck(args.DeliveryTag, false);

                System.Diagnostics.Debug.WriteLine("Message Received: " + System.Text.Encoding.UTF8.GetString(args.Body));

            };

            channel.BasicConsume(Queue, false, consumer);

        }

    }
}