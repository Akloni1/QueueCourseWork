namespace Producer.Models
{
    public class Order
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long CardBuyerId { get; set; }
    }
}
