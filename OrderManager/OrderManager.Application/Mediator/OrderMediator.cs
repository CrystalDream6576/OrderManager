using OrderManager.Application.Abstractions.Mediator;

namespace OrderManager.Application.Mediator
{
    public class OrderMediator : IMediator
    {
        private readonly IHandlerRegistry registry;

        public OrderMediator(IHandlerRegistry registry)
        {
            this.registry = registry;
        }

        public TResult Send<TResult>(IRequest<TResult> request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            Type requestType = request.GetType();

            IHandlerAdapter adapter = registry.GetHandler(requestType);

            var result = adapter.Handle(request);

            if (result is not TResult typedResult)
            {
                string message = string.Format(
                    "The handler for {0} returned {1}, but {2} was expected", 
                    requestType.Name,
                    result.GetType().Name, 
                    typeof(TResult).Name);

                throw new InvalidCastException(message);
            }

            return typedResult;
        }
    }
}
