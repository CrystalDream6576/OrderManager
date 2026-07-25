using OrderManager.Application.Abstractions;
using OrderManager.Application.Commands;


namespace OrderManager.Application.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public bool Handle(CreateOrderCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.name) || request.total <= 0) return false;

            var order = new Order
            {
                Name = request.name,
                Total = request.total
            };

            this.orderRepository.Add(order);

            return true;
        }
    }
}
