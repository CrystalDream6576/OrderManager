using OrderManager.Application.Abstractions;

namespace OrderManager.Application.Commands
{
    public record DeleteOrderCommand(int Id) : IRequest<bool>;
}
