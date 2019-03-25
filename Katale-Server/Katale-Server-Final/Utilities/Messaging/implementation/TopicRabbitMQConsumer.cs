using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Utilities.Messaging.implementation
{
    public class TopicRabbitMQConsumer :RabbitMQ, IRabbitMQConsumer
    {
        IModel channel;

        public TopicRabbitMQConsumer(string Exchange, string Queue,string RoutingKey)
        {
            channel = connection.CreateModel();
            this.Exchange = Exchange;
            this.Queue = Queue;
            channel.ExchangeDeclare(this.Exchange, ExchangeType.Topic);
            channel.QueueDeclare(this.Queue, false, false, false, null);
            channel.QueueBind(this.Queue, this.Exchange, RoutingKey, null);

        }

        public TopicRabbitMQConsumer()
        {
            channel = connection.CreateModel();
        }

        public void ReceiveAsync()
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ch,ea)=>
            {
                channel.BasicAck(ea.DeliveryTag, false);

                System.Diagnostics.Debug.WriteLine(ea.Body.ToString());
            };

            channel.BasicConsume(this.Queue, false, consumer);
        }
        
    }
}