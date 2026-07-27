using OrderManager.Application.Abstractions.Mediator;
using OrderManager.Domain.Entities;

namespace OrderManager.Application.Queries
{
    public record GetOrderByIdQuery(int id) : IRequest<Order>;
}
