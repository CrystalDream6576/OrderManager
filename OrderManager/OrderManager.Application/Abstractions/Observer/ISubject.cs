namespace OrderManager.Application.Abstractions.Observer
{
    public interface ISubject<T>
    {
        void Attach(ISubscriber<T> subscriber);
        void Detach(ISubscriber<T> subscriber);
        void Notify(T data);
    }
}
