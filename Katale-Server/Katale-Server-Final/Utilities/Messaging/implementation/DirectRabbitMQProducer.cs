using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Utilities.Messaging
{
    public class DirectRabbitMQProducer :RabbitMQ, IRabbitMQProducer
    {
        IModel model;

        public DirectRabbitMQProducer()
        {
            model = connection.CreateModel();
            model.ExchangeDeclare(this.Exchange, ExchangeType.Direct);
            model.QueueDeclare(this.Queue, false, false, false, null);
            model.QueueBind(Queue, Exchange, "default", null);

        }

        public DirectRabbitMQProducer(string Exchange,string RoutingKey)
        {
            model = connection.CreateModel();
            this.Exchange = Exchange;
            model.ExchangeDeclare(this.Exchange, ExchangeType.Direct);
            model.QueueBind(Queue, Exchange, RoutingKey, null);
        }

        public DirectRabbitMQProducer(string Exchange, string Queue,string RoutingKey)
        {
            model = connection.CreateModel();
            this.Exchange = Exchange;
            this.Queue = Queue;
            model.ExchangeDeclare(this.Exchange, ExchangeType.Direct);
            model.QueueDeclare(this.Queue, false, false, false, null);
            model.QueueBind(Queue, Exchange, RoutingKey, null);

        }

        public void Send(string msg, string Routingkey)
        {
            byte[] message = System.Text.Encoding.UTF8.GetBytes(msg);

            model.BasicPublish(Exchange, Routingkey, null, message);
        }

        public void Send(object obj, string Queue, string RoutingKey)
        {
            JObject jsonObject = JObject.FromObject(obj);
            byte[] message = System.Text.Encoding.UTF8.GetBytes(jsonObject.ToString());
          
            model.BasicPublish(this.Exchange, Queue, null, message);
        }

        public void Send(object obj, string Routingkey)
        {
            model.QueueBind(Queue, Exchange, Routingkey, null);

            JObject jsonObject = JObject.FromObject(obj);

            byte[] message = System.Text.Encoding.UTF8.GetBytes(jsonObject.ToString());

            model.BasicPublish(Exchange, Routingkey, null, message);
        }
    }
}