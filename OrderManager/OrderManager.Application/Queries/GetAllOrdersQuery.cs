using OrderManager.Application.Abstractions;
using OrderManager.Domain.Domain.Order;

namespace OrderManager.Application.Queries
{
    public record GetAllOrdersQuery() : IRequest<IEnumerable<Order>>;
}
