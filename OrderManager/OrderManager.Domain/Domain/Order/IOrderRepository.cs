using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Domain.Domain.Order
{
    public interface IOrderRepository
    {
        Order Add(Order order);

        bool Delete(int id);

        IEnumerable<Order> GetAll();

        Order? GetById(int id);
    }
}
