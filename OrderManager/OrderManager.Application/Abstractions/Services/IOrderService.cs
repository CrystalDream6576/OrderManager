using OrderManager.Application.Abstractions.Observer;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Abstractions.Services
{
    public interface IOrderService : ISubject<Order>
    {
        bool Add(Order order);

        bool Delete(int id);
    }
}
