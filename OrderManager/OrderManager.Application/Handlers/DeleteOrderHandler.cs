using MediatorExample.Application.Abstractions;
using MediatorExample.Infrastructure.Repositories;
using OrderManager.Application.Commands;

namespace OrderManager.Application.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public bool Handle(DeleteOrderCommand request)
        {
            return orderRepository.Delete(request.Id);
        }
    }
}
