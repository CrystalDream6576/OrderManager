using OrderManager.Domain.Entities;
using OrderManager.Notification.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Notification.Bridge
{
    public class SmsNotification : OrderNotification
    {
        public SmsNotification(IMessageProvider provider) : base(provider)
        {
        }

        public override void Send(Order order)
        {
            provider.BuildMessage(new Messages.NotificationMessage()
            {
                Recipient = order.PhoneNumber,
                Subject = "Order Status Updated",
                Body = $"Your order #{order.Id} is now {order.Status}."
            });
        }
    }
}
