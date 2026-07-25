using OrderManager.Application.Abstractions;
using OrderManager.Application.Queries;
using OrderManager.Domain.Domain.Order;

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
