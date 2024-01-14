namespace Producer.RabbitMQ.Interfaces
{
    public interface IMessageRabbitMQProducer
    {
        void SendMessage<T>(T message);
    }
}
