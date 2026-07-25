using OrderManager.Application.Abstractions;
using OrderManager.Domain.Domain.Order;

namespace OrderManager.Application.Queries
{
    public record GetOrderByIdQuery(int id) : IRequest<Order>;
}
