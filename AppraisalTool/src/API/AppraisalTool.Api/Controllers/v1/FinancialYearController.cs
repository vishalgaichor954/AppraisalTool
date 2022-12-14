﻿using AppraisalTool.Application.Features.FinancialYears.Command.CreateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.RemoveFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.UpdateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearById;
using AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearList;
﻿using AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears;
using AppraisalTool.Application.Features.FinancialYears.Queries.GetFinancialYearsByUserJoining;
using AppraisalTool.Application.Features.Users.Query.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FinancialYearController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FinancialYearController> _logger;

        public FinancialYearController(IMediator mediator, ILogger<FinancialYearController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        [Route("AddFinancialYear")]
        public async Task<ActionResult> AddFinancialYear(CreateFinancialYearCommand request)
        {
            _logger.LogInformation("AddFinancialYear Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("AddFinancialYear Completed");
            return Ok(dtos);

        }
        [HttpGet]
        [Route("ListFinancialYear")]
        public  async Task<ActionResult> ListFinancialYear()
        {
           _logger.LogInformation("ListFinancialYear Initiated");
            var res = await _mediator.Send(new GetFinancialYearListQuery());
            return Ok(res);

        }

        [HttpPut("UpdateFinanacialYear")]
        public async Task<ActionResult> UpdateFinanacialYear(UpdateFinanacialYearCommand request)
        {
            _logger.LogInformation("UpdateFinanacialYear Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("UpdateFinanacialYear Completed");
            return Ok(dtos);
        }
        [HttpGet("GetFinancialYearById")]
        public async Task<ActionResult> GetFinancialYearById(int id)
        {
            var dtos = await _mediator.Send(new GetFinancialYearByIdQuery { Id = id });
            return Ok(dtos);
        }
        [HttpDelete("removeFinancialYear")]
        public async Task<ActionResult> RemoveFinancialYear(int id)
        {
            _logger.LogInformation("RemoveAsync Initiated");
            var dtos = await _mediator.Send(new RemoveFinancialYearCommand() { Id = id });
            _logger.LogInformation("RemoveAsync Completed");
            return Ok(dtos);
        }
        [HttpGet("GetAllFinancialYears")]

        public async Task<ActionResult> GetAllFinancialYears()
        {
            _logger.LogInformation("GetAllFinancialYears Initiated");
            var dtos = await _mediator.Send(new GetAllFinancialYearsQuery());
            _logger.LogInformation("GetAllFinancialYears Completed");
            return Ok(dtos);
        }


        //Author : Ilyas Dabholkar
        //Returns financial year list with year greater than or equal to user joining date
        [HttpGet("GetFinancialYearsByUserJoining")]
        public async Task<ActionResult> GetFinancialYearsByUserJoining(int userId)
        {
            _logger.LogInformation("GetFinancialYearsByUserJoining( Initiated");
            var dtos = await _mediator.Send(new GetFinancialYearsByUserJoiningQuery(){ UserId=userId});
            _logger.LogInformation("GetFinancialYearsByUserJoining( Completed");
            return Ok(dtos);
        }


    }
}
