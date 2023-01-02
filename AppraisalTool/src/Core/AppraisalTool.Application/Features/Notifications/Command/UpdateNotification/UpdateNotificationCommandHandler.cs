using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, Response<string>>
    {
        private readonly ILogger<UpdateNotificationCommandHandler> _logger;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public UpdateNotificationCommandHandler(ILogger<UpdateNotificationCommandHandler> logger, INotificationRepository notificationRepository, IMapper mapper)
        {
            _logger = logger;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            

            var response = await _notificationRepository.ClearNotifications(request.NotificationIds);

            if (response != null)
            {
                return new Response<string>() { Data = null, Message = "Successful", Succeeded = true, Errors = null };

            }

            return new Response<string>() { Data = null, Message = "Not  Successful", Succeeded = false, Errors = null };
        }
    }
}
