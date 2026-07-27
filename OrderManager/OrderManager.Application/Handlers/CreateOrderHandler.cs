using OrderManager.Application.Abstractions.Mediator;
using OrderManager.Application.Abstractions.Services;
using OrderManager.Application.Commands;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Repositories;


namespace OrderManager.Application.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderService orderService;

        public CreateOrderHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public bool Handle(CreateOrderCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.name) || request.total <= 0) 
                return false;

            var order = new Order
            {
                Name = request.name,
                Total = request.total
            };

            return orderService.Add(order);
        }
    }
}
