using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Notifications.Command.AddNotification
{
    public class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommand, Response<string>>
    {
       
        private readonly ILogger<AddNotificationCommandHandler> _logger;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public AddNotificationCommandHandler(ILogger<AddNotificationCommandHandler> logger, INotificationRepository notificationRepository, IMapper mapper)
        {
            _logger = logger;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            Notification notification = _mapper.Map<Notification>(request.addNotificationDto);

            var response = await _notificationRepository.AddAsync(notification);

            if (response != null)
            {
                return new Response<string>() { Data = null, Message = "Added Successfully", Succeeded = true, Errors = null };

            }

            return new Response<string>() { Data = null, Message = "Not Added Successfully", Succeeded = false, Errors = null };
        }
    }
}
