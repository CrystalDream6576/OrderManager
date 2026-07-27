

using OrderManager.Domain.Entities;
using OrderManager.Domain.Enums;

namespace OrderManager.Domain.Repositories
{
    public interface IOrderRepository
    {
        bool Add(Order order);

        bool Delete(int id);

        IEnumerable<Order> GetAll();

        Order? GetById(int id);
    }
}
