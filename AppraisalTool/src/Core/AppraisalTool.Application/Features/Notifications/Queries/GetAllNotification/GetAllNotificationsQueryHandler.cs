using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Notifications.Queries.GetAllNotification
{
    public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationQuery, Response<List<Notification>>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ILogger<GetAllNotificationsQueryHandler> _logger;

        public GetAllNotificationsQueryHandler(INotificationRepository notificationRepository, ILogger<GetAllNotificationsQueryHandler> logger)
        {
            _notificationRepository = notificationRepository;
            _logger = logger;
        }

        public async Task<Response<List<Notification>>> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
        {
            List<Notification> notifications = await _notificationRepository.GetAllNotificationByUserId(request.Id);
            return new Response<List<Notification>>(notifications, "success");
        }
    }
}
