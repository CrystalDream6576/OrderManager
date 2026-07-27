using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Abstractions.Mediator
{
    public interface IHandlerRegistry
    {
        void Register<TRequest, TResult>(IRequestHandler<TRequest, TResult> handler)
            where TRequest : IRequest<TResult>;

        IHandlerAdapter GetHandler(Type requestType);
    }
}
