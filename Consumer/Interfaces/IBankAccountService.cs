using Consumer.Models;

namespace Consumer.Interfaces
{
    public interface IBankAccountService
    {
        void PayOrder(Order order);
    }
}
