using OrderManager.Application.Abstractions.Mediator;

namespace OrderManager.Application.Commands
{
    public record DeleteOrderCommand(int Id) : IRequest<bool>;
}
