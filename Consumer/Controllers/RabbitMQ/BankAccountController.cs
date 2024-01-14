using Consumer.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer.Controllers.RabbitMQ
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private IList<BankAccount> _bankAccounts { get; set; }
       
        public BankAccountController()
        {
            _bankAccounts = BankAccounts.Accounts;
        }

        [HttpGet]
        public IActionResult GetBankAccount()
        {
            return Ok(_bankAccounts);
        }
    }
}
