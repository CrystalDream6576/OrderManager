using OrderManager.Notification.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Notification.Providers
{
    public class EmailProvider : IMessageProvider
    {
        public void BuildMessage(NotificationMessage message)
        {
            string text = string.Format("Email to: {0} | Subject: {1} | Message: {2}",
                message.Recipient,
                message.Subject,
                message.Body);

            Console.WriteLine(text);
        }
    }
}
