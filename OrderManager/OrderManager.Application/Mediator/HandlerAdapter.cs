using OrderManager.Application.Abstractions.Mediator;

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
                string message = string.Format("Expected request type {0},but received {1}.", 
                    typeof(TRequest).Name,
                    request.GetType().Name);

                throw new ArgumentException(message);
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
