using Consumer.Interfaces;
using Consumer.Models;

namespace Consumer.Services.RabbitMQ
{
    public class BankAccountService: IBankAccountService
    {
        private IList<BankAccount> _accounts;
        public BankAccountService()
        {
            _accounts = BankAccounts.Accounts;
        }
        public void PayOrder(Order order)
        {
            var item = _accounts.Where(x => x.Id == order.CardBuyerId).FirstOrDefault() ?? throw new Exception("Карта не найдена");
            if(order.Price > item.Balance)
            {
                throw new Exception("Недостаточно средств");
            }
            item.Balance -= order.Price * order.Quantity;
        }
    }
}
