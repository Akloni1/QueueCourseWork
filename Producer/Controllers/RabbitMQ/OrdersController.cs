using Microsoft.AspNetCore.Mvc;
using Producer.Models;
using Producer.RabbitMQ.Interfaces;
using RabbitMQ.Client;

namespace Producer.Controllers.RabbitMQ
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IList<Order> _order { get; set; }
        private readonly IMessageRabbitMQProducer _messagePublisher;
        public OrdersController(IMessageRabbitMQProducer messagePublisher)
        {
            _order = new List<Order>();
            _messagePublisher = messagePublisher;
        }

        [HttpPost]
        public  IActionResult CreateOrder(Order order)
        {
            _order.Add(order);
            _messagePublisher.SendMessage(order);
            return Ok();
        }
    }
}
