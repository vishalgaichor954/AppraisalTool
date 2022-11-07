using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MenuController> _logger;

        public MenuController(IMediator mediator, ILogger<MenuController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        //@Author : Triveni patil
        [HttpPost("AddMenu")]
        public async Task<ActionResult> AddMenu(CreateMenuCommand request)
        {
            _logger.LogInformation("Addmenu Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("Addmenu Completed");
            return Ok(dtos);
        }
    }
}
