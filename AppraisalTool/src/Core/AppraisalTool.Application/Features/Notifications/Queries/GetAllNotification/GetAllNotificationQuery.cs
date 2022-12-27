using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Notifications.Queries.GetAllNotification
{
    public class GetAllNotificationQuery:IRequest<Response<List<Notification>>>
    {
        public int Id { get; set; }
    }
}
