using OrderManager.Application.Abstractions;

namespace OrderManager.Application.Commands
{
    public record CreateOrderCommand(string name, decimal total) : IRequest<bool>;
}
