using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RabbitMQ.Client;

namespace Katale_Server_Final.Utilities.Messaging
{
    public abstract class RabbitMQ
    {
        public IConnectionFactory connectionFactory = new ConnectionFactory();
        public IConnection connection = null;

        protected string Exchange { get; set; }
        protected string Queue { get; set; }
       
        public RabbitMQ()
        {
            
            string Username = PropertyConfigurations.Read("username", "RabbitMQ");
            string Password = PropertyConfigurations.Read("password", "RabbitMQ");

            this.connectionFactory.UserName = Username;
            this.connectionFactory.Password = Password;

            connection = this.connectionFactory.CreateConnection();
        }

    }
}