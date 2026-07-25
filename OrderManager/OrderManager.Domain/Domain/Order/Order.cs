namespace OrderManager.Domain.Domain.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
