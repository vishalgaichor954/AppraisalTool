using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationCommand: IRequest<Response<string>>
    {
        public List<int> NotificationIds { get; set; }
    }
}
