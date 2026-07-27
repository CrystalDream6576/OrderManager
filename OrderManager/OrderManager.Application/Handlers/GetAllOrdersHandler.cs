using OrderManager.Application.Abstractions.Mediator;
using OrderManager.Application.Queries;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Repositories;

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
