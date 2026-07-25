using MediatorExample.Application.Abstractions;
using MediatorExample.Domain;
using MediatorExample.Infrastructure.Repositories;
using OrderManager.Application.Queries;

namespace OrderManager.Application.Handlers
{
    public class GetAllOrdersHandler:IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Handle(GetAllOrdersQuery request)
        {
            return orderRepository.GetAll();
        }
    }

}
