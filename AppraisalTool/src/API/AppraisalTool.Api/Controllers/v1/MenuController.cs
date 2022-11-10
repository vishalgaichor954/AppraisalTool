using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
using AppraisalTool.Application.Features.Menu.Command.RemoveMenuCommand;
using AppraisalTool.Application.Features.Menu.Command.UpdateMenuCommand;
using AppraisalTool.Application.Features.Menu.Query.GetMenuById;
using AppraisalTool.Application.Features.Menu.Query.GetMenuList;
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
        [HttpPut("UpdateMenu")]
        public async Task<ActionResult> UpdateMenu(UpdateMenuCommand request)
        {
            _logger.LogInformation("UpdateMenu Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("UpdateMenu Completed");
            return Ok(dtos);
        }

        [HttpGet("GetMenuById")]
        public async Task<ActionResult> GetMenuById(int id)
        {
            _logger.LogInformation("GetMenuById Initiated");
            var dtos = await _mediator.Send(new GetMenuByIdQuery { Menu_Id = id });
            _logger.LogInformation("GetMenuById Completed");
            return Ok(dtos);
        }
        [HttpGet(Name = "GetMenuList")]

        public async Task<ActionResult> GetAllMenuList()
        {
            var res = await _mediator.Send(new GetMenuListQuery());
            return Ok(res);
        }

        [HttpDelete("removeMenu")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            _logger.LogInformation("RemoveAsync Initiated");
            var dtos = await _mediator.Send(new RemoveMenuCommand() { Menu_Id = id });
            _logger.LogInformation("RemoveAsync Completed");
            return Ok(dtos);
        }

    }
}
