using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ANDERSONDFM.Integracao
{
    
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            try
            {
                //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
                //docker pull rabbitmq:3-management
                //docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                };
                //Create the RabbitMQ connection using connection factory details as i mentioned above
                var connection = factory.CreateConnection();
                //Here we create channel with session and model
                using var channel = connection.CreateModel();
                //declare the queue after mentioning name and a few property related to that
                channel.QueueDeclare("product", exclusive: false);
                //Serialize the message
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                //put the data on to the product queue
                channel.BasicPublish(exchange: "", routingKey: "product", body: body);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, show an error message, etc.)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}

