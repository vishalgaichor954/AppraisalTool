using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Notifications.Command.AddNotification
{
    public class AddNotificationCommand : IRequest<Response<string>>
    {
        public AddNotificationDto addNotificationDto { get; set; }
    }
}
