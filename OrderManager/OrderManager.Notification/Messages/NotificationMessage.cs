using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Notification.Messages
{
    public class NotificationMessage
    {
        public string Recipient { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
