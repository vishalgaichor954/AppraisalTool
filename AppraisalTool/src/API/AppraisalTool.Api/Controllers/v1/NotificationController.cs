using AppraisalTool.Application.Features.Notifications.Command.AddNotification;
using AppraisalTool.Application.Features.Notifications.Command.UpdateNotification;
using AppraisalTool.Application.Features.Notifications.Queries.GetAllNotification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(IMediator mediator, ILogger<NotificationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost("AddNotifications")]
        public async Task<ActionResult> AddNotificationAsync(AddNotificationDto result)
        {
            _logger.LogInformation("AddNotification Initiated");
            var dtos = await _mediator.Send(new AddNotificationCommand() { addNotificationDto=result});
            _logger.LogInformation("AddNotification Completed");
            return Ok(dtos);
        }

        [HttpPost("ClearNotification")]
        public async Task<ActionResult> ClearAllNotification([FromBody] List<int> ints)
        {
            _logger.LogInformation("ClearAllNotification Initiated");
            var dtos = await _mediator.Send(new UpdateNotificationCommand() { NotificationIds=ints });
            _logger.LogInformation("ClearAllNotification Completed");
            return Ok(dtos);
        }

        [HttpGet("GetAllNotificationByUserId")]
        public async Task<ActionResult> getAllNotification(int id)
        {
            _logger.LogInformation("getAllNotification Initiated");
            var dtos = await _mediator.Send(new GetAllNotificationQuery() { Id=id});
            _logger.LogInformation("getAllNotification Completed");
            return Ok(dtos);
        }

    }
}
