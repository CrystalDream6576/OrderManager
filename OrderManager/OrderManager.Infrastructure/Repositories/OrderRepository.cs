using OrderManager.Application.Repositories;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Enums;

namespace OrderManager.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = new();

        private int Id = 1;

        public bool Add(Order order)
        {
            if (order is null) 
                throw new ArgumentNullException(nameof(order));

            order.Id = Id;
            Id++;

            orders.Add(order);

            order.ChangeStatus(OrderStatus.Confirmed);

            return true;
        }

        public bool Delete(int id)
        {
            Order? order = orders.FirstOrDefault(x => x.Id == id);

            if (order is null) return false;

            orders.Remove(order);

            return true;
        }

        public IEnumerable<Order> GetAll()
        {
            return orders.ToList();
        }

        public Order? GetById(int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

    }
}
