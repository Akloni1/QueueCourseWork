using Newtonsoft.Json;
using Producer.RabbitMQ.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace Producer.RabbitMQ
{
    public class RabbitMQProducer : IMessageRabbitMQProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "rabbitmq" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //  channel.QueueDeclare("orders", exclusive: false);
            channel.QueueDeclare(queue: "orders", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
        }
    }
}
