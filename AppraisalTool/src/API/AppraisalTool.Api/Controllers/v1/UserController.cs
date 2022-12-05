﻿
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
using AppraisalTool.Application.Features.Users.Query.GetUserByRoleId;
using AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalList;
using AppraisalTool.Application.Features.Branches.Command.AddBranchCommand;
using AppraisalTool.Application.Features.Branches.Command.UpdateBranchCommand;
using AppraisalTool.Application.Contracts.Persistence;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        private readonly IBranchRepository _branchRepository;
        
        public UserController(IMediator mediator, ILogger<UserController> logger, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
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
        public async Task<ActionResult> RemoveAsync(int id)
        {
            _logger.LogInformation("RemoveAsync Initiated");
            var dtos = await _mediator.Send(new RemoveUserCommand() { Id=id});
            _logger.LogInformation("RemoveAsync Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUserAsync(UpdateUserCommand request)
        {
            //var request = new UpdateUserCommand();
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
            _logger.LogInformation("GetAllCard Initiated");
            var dtos = await _mediator.Send(new GetMenuListQuery() { Id = id });
            _logger.LogInformation("GetAllCard Completed");
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
        [HttpGet("getUserByRoleId")]
        public async Task<ActionResult> GetUserByRoleId(int id)
        {
            _logger.LogInformation("GetUserByRoleId Initiated");
            var dtos = await _mediator.Send(new GetUserByRoleIdQuery() { RoleId = id });
            _logger.LogInformation("GetUserByRoleId Completed");
            return Ok(dtos);
        }


        [HttpGet("ListOfAppraisal")]
        public async Task<ActionResult> GetAllAppraisal()
        {
            _logger.LogInformation("GetAllAppraisal Initiated");
            var dtos = await _mediator.Send(new GetAppraisalListQuery()) ;
            _logger.LogInformation("GetAllAppraisal Completed");
            return Ok(dtos);
        }



        [HttpGet("ListOfBranch")]
        public async Task<ActionResult> GetAllBranch()
        {
            _logger.LogInformation("GetAllBranch Initiated");
            var dtos = await _mediator.Send(new GetBranchListQuery());
            _logger.LogInformation("GetAllBranch Completed");
            return Ok(dtos);
        }


        [HttpPost("AddBranch")]
        public async Task<ActionResult> AddBranch(AddBranchCommand request)
        {
            _logger.LogInformation("AddBranch Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("AddBranch Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateBranch")]
        public async Task<ActionResult> UpdateBranch(UpdateBranchCommand request)
        {
            _logger.LogInformation("UpdateBranch Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("UpdateBranch Completed");
            return Ok(dtos);
        }

        [HttpGet("GetBranchById")]
        public async Task<ActionResult> GetBranchById(int id)
        {
            var dtos = await _branchRepository.GetBranchById(id);
            return Ok(dtos);
        }

    }
}
