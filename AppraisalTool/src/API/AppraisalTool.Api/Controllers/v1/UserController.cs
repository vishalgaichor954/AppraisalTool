
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger=logger;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterAsync(CreateUserCommand request)
        {
            _logger.LogInformation("RegisterAsync Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("RegisterAsync Completed");
            return Ok(dtos);
        }
    }
}
