using AppraisalTool.Application.Features.UserJobProfileRoles.Command.CreateJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserJobProfileRoles.Command.RemoveJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserJobProfileRoles.Command.UpdateJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserJobProfileRoles.Query.GetJobProfileRoleByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public RoleController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddJobProfileRole")]
        public async Task<ActionResult> AddJobProfileRole(CreateJobProfileCommand request)
        {
            _logger.LogInformation("AddJobProfileRole Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("AddJobProfileRole Completed");
            return Ok(dtos);
        }
        [HttpPut("UpdateJobProfileRole")]
        public async Task<ActionResult> UpdateJobProfileRole(UpdateJobProfileCommand request)
        {
            _logger.LogInformation("UpdateJobProfileRole Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("UpdateJobProfileRole Completed");
            return Ok(dtos);
        }

        [HttpDelete("RemoveJobProfileRole")]
        public async Task<ActionResult> RemoveJobProfileRole(int id)
        {
            _logger.LogInformation("RemoveJobProfileRole Initiated");
            var dtos = await _mediator.Send(new RemoveJobProfileCommand(){Id=id });

            _logger.LogInformation("RemoveJobProfileRole Completed");
            return Ok(dtos);
        }
        [HttpGet("GetJobRoleById")]
        public async Task<ActionResult> GetJobRoleById(int id)
        {
            var dtos = await _mediator.Send(new GetJobRoleByIdQuery { Id = id });
            return Ok(dtos);
        }

    }
}
