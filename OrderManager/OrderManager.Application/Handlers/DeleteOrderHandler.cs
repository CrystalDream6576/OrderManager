using OrderManager.Application.Abstractions.Mediator;
using OrderManager.Application.Abstractions.Services;
using OrderManager.Application.Commands;

namespace OrderManager.Application.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderService orderService;

        public DeleteOrderHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public bool Handle(DeleteOrderCommand request)
        {
            return orderService.Delete(request.Id);
        }
    }
}
