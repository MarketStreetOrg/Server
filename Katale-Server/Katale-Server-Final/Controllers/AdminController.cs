using Katale_Server_Final.Utilities.Messaging;
using Katale_Server_Final.Utilities.Messaging.implementation;
using System.Web.Http;

namespace Katale_Server_.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {

        IRabbitMQConsumer RabbitMQConsumer = new TopicRabbitMQConsumer("test_exchange", "test_queue", "test.me");
        
        [HttpGet]
        [Route("listen")]
        public string Listen()
        {

            RabbitMQConsumer.ReceiveAsync();


            return "Listening from RabbitMQ";

        }


    }

}