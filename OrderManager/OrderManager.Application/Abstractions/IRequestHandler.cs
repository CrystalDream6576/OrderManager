using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Abstractions
{
    public interface IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        TResult Handle(TRequest request);
    }
}
