using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Notifications.Command.AddNotification
{
    public class AddNotificationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string NotificationText { get; set; }

        public DateTime NotificationDate { get; set; } = DateTime.Now;

        public bool IsRead { get; set; }
    }
}
