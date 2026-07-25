using MediatorExample.Application.Abstractions;
using MediatorExample.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Queries
{
    public record GetOrderByIdQuery(int id) : IRequest<Order>;
}
