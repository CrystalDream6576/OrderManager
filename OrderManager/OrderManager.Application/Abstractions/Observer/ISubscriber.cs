using OrderManager.Domain.Entities;
using OrderManager.Domain.Enums;

namespace OrderManager.Application.Abstractions.Observer
{
    public interface ISubscriber<T>
    {
        void Update(T data);
    }
}
