using OrderManager.Domain.Enums;

namespace OrderManager.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public OrderStatus Status { get; private set; }

        public void ChangeStatus(OrderStatus newStatus)
        {
            if (Status == newStatus) 
                return;

            Status = newStatus;
        }
    }
}
