
using AppraisalTool.Application.Features.Users.Command.CreateRoleCommand;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
using AppraisalTool.Application.Features.Users.Query.GetRoleList;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Features.Users.Query.GetUserRole;
using AppraisalTool.Application.Features.Users.Query.GetUserRole.GetBranchList;
using AppraisalTool.Application.Features.Users.Queries.GetMenuList;
using AppraisalTool.Application.Features.Users.Queries.GetUserJobProfiles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppraisalTool.Application.Features.Users.Query.GetUserById;

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
        [HttpDelete("removeUser")]
        public async Task<ActionResult> RemoveAsync(int Id)
        {
            _logger.LogInformation("RemoveAsync Initiated");
            var dtos = await _mediator.Send(new RemoveUserCommand(Id));
            _logger.LogInformation("RemoveAsync Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUserAsync(UpdateUserCommand request)
        {
            _logger.LogInformation("UpdateUserAsync Initiates");
            var dtos=await _mediator.Send(request);
            _logger.LogInformation("UpdateUserAsync Completed ");
            return Ok(dtos);
        }
        [HttpGet]
        [Route("GetJobProfile")]
        public async Task<ActionResult> GetJobProfile()
        {
           var dtos= await _mediator.Send(new GetRoleQuery());
           return Ok(dtos);
                 
        }
        [HttpGet]
        [Route("GetBranch")]
        public async Task<ActionResult> GetBranch()
        {
            var dtos = await _mediator.Send(new GetBranchListQuery());
            return Ok(dtos);

        }
        [HttpGet]
        [Route("GetRole")]

        public async Task<ActionResult> GetRole()
        {
            var dtos = await _mediator.Send(new GetRoleListQuery());
            return Ok(dtos);

        }
        [HttpGet(Name = "GetUserList")]
        
        public async Task<ActionResult> GetAllUserList()
        {
            var res = await _mediator.Send(new GetUserListQuery());
            return Ok(res);
        }

        //@Author : Ilyas Dabholkar
        [HttpGet("GetUserJobProfile")]
        public async Task<ActionResult> GetUserJobProfile(int id)
        {
            _logger.LogInformation("GetUserJobProfile Initiated");
            var dtos = await _mediator.Send(new GetUserJobProfilesQuery() { Id=id});
            _logger.LogInformation("GetUserJobProfile Completed");
            return Ok(dtos);
        }



        //@Author : Abhishek Singh
        [HttpGet("GetAllCard")]
        public async Task<ActionResult> GetAllCard(int id)
        {
            _logger.LogInformation("GetUserJobProfile Initiated");
            var dtos = await _mediator.Send(new GetMenuListQuery() { Id = id });
            _logger.LogInformation("GetUserJobProfile Completed");
            return Ok(dtos);
        }

        [HttpGet("getUser")]
        public async Task<ActionResult> GetUserById(int id)
        {
            _logger.LogInformation("GetUserAsync Initiated");
            var dtos = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            _logger.LogInformation("GetUserAsync Completed");
            return Ok(dtos);
        }
    }
}
