using OrderManager.Domain.Entities;

namespace OrderManager.Application.Repositories
{
    public interface IOrderRepository
    {
        bool Add(Order order);

        bool Delete(int id);

        IEnumerable<Order> GetAll();

        Order? GetById(int id);
    }
}
