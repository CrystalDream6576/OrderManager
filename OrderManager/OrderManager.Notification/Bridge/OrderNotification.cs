using OrderManager.Domain.Entities;
using OrderManager.Notification.Providers;

namespace OrderManager.Notification.Bridge
{
    public abstract class OrderNotification
    {
        protected readonly IMessageProvider provider;

        protected OrderNotification(IMessageProvider provider)
        {
            this.provider = provider;
        }

        public abstract void Send(Order order);
    }
}
