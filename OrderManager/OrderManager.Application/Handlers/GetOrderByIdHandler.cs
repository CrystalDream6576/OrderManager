using MediatorExample.Application.Abstractions;
using MediatorExample.Domain;
using MediatorExample.Infrastructure.Repositories;
using OrderManager.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Handlers
{
    public class GetOrderByIdHandler:IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Handle(GetOrderByIdQuery request)
        {
            Order? order = _orderRepository.GetById(request.id);

            if (order is null)
            {
                throw new KeyNotFoundException(
                    $"Order with ID {request.id} was not found.");
            }

            return order;
        }
    }
}
