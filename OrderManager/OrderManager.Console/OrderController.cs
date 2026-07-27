using OrderManager.Application.Abstractions.Mediator;
using OrderManager.Application.Abstractions.Services;
using OrderManager.Application.Commands;
using OrderManager.Application.Queries;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Enums;

namespace OrderManager.Console
{
    public class OrderController
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public bool CreateOrder(string name, decimal total)
        {
            var command = new CreateOrderCommand(name, total);
            return mediator.Send(command);
        }

        public bool DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand(id);

            return mediator.Send(command);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();

            return mediator.Send(query);
        }

        public Order GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery(id);

            return mediator.Send(query);
        }
    }
}
