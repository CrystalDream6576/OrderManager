using OrderManager.Application.Abstractions.Observer;
using OrderManager.Domain.Entities;
using OrderManager.Notification.Bridge;

namespace OrderManager.Notification.Subscribers
{
    public class CustomerOrderSubscriber : ISubscriber<Order>
    {
        private readonly OrderNotification notification;


        public CustomerOrderSubscriber(OrderNotification notification)
        {
            this.notification = notification;
        }

        public void Update(Order data)
        {
            notification.Send(data);
        }
    }
}
