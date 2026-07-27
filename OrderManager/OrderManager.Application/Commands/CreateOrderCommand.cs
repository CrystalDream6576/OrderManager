using OrderManager.Application.Abstractions.Mediator;

namespace OrderManager.Application.Commands
{
    public record CreateOrderCommand(string name, decimal total) : IRequest<bool>;
}
