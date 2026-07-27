using OrderManager.Notification.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Notification.Providers
{
    public interface IMessageProvider
    {
        void BuildMessage(NotificationMessage message);
    }
}
