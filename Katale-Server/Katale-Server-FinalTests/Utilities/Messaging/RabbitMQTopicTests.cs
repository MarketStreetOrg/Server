using System;
using System.Collections.Generic;
using Katale_Server_.Models;
using Katale_Server_Final.Models;
using Katale_Server_Final.Utilities.Messaging;
using Katale_Server_Final.Utilities.Messaging.implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Utilities.Messaging
{
    [TestClass]
    public class RabbitMQTopicTests
    {
        IRabbitMQProducer rabbitMQProducer = new TopicRabbitMQProducer("test_exchange","test_queue");
        IRabbitMQConsumer RabbitMQConsumer = new TopicRabbitMQConsumer("test_exchange", "test_queue","test.me");

        [TestMethod]
        public void TestSendMessage()
        {
            Department department = new Department("Depo", "Depo desc");
            
            rabbitMQProducer.Send(department,"test.me");

            
        }

        [TestMethod]
        public void TestReceiveMessage()
        {           
            RabbitMQConsumer.ReceiveAsync();
        }
    }
}
