using MediatorExample.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Mediator
{
    public class HandlerAdapter<TRequest, TResult> : IHandlerAdapter
        where TRequest : IRequest<TResult>
    {
        private readonly IRequestHandler<TRequest, TResult> handler;

        public HandlerAdapter(IRequestHandler<TRequest, TResult> handler)
        {
            this.handler = handler;
        }

        public object Handle(object request)
        {
            if (request is not TRequest typedRequest)
            {
                throw new ArgumentException(
                    $"Expected request type {typeof(TRequest).Name}, " +
                    $"but received {request.GetType().Name}.");
            }

            TResult result = handler.Handle(typedRequest);

            if (result is null)
            {
                throw new InvalidOperationException(
                    $"Handler {typeof(TRequest).Name} returned null.");
            }

            return result;
        }
    }
}
