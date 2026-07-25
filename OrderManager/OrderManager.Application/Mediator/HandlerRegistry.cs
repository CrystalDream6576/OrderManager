using MediatorExample.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Mediator
{
    public class HandlerRegistry : IHandlerRegistry
    {
        private readonly Dictionary<Type, IHandlerAdapter> handlers = new();

        public void Register<TRequest, TResult>(IRequestHandler<TRequest, TResult> handler)
            where TRequest : IRequest<TResult>
        {
            Type requestType = typeof(TRequest);

            var adapter = new HandlerAdapter<TRequest, TResult>(handler);

            handlers[requestType] = adapter;
        }

        public IHandlerAdapter GetHandler(Type requestType)
        {
            if (requestType is null)
            {
                throw new ArgumentNullException(nameof(requestType));
            }

            if (!handlers.TryGetValue(requestType, out IHandlerAdapter? handler))
            {
                throw new InvalidOperationException(
                    $"No handler is registered for " +
                    $"{requestType.Name}.");
            }

            return handler;
        }
    }
}
