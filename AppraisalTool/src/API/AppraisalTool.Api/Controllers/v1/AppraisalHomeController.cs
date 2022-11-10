using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetYear;
﻿using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAllAppraisalResults;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetAllReporteeAppraisals;
using AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetReporteeAppraisalsByRevAuthority;
using AppraisalTool.Application.Features.SelfAppraisal.Command.AddAppraisal;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByAppraisalId;
using AppraisalTool.Application.Features.AppraisalResults.Commands.UpdateAppraisalResult;

namespace AppraisalTool.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AppraisalHomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AppraisalHomeController> _logger;

        public AppraisalHomeController(IMediator mediator, ILogger<AppraisalHomeController> logger)
        {
            _logger = logger;
            _mediator = mediator;


        }

        [HttpGet("byYear", Name = "GetAllData")]
        public async Task<ActionResult> GetDataByYear(int userId)


        {
            _logger.LogInformation("GetDataByYear Initiated");
            var dtos = new GetDataQuery() { UserId = userId };
            _logger.LogInformation("GetDataByYear Completed");
            return Ok(await _mediator.Send(dtos));

        }

        [HttpGet]
        public async Task<ActionResult> GetYear(int userId)
        {

            _logger.LogInformation("GetYear Initiated");
            var dtos = new GetYearQuery() { UserId = userId };
            _logger.LogInformation("GetYear Completed");
            return Ok(await _mediator.Send(dtos));
        }

        //Author : Ilyas Dabholkar
        //Return list of all appraisal results
        [HttpGet("GetAllAppraisalResult")]
        public async Task<ActionResult> GetAllAppraisalResult()
        {
            try
            {
                _logger.LogInformation("GetAllAppraisalResult Initiated");
                var res = await _mediator.Send(new GetAllAppraisalResultsQuery());
                _logger.LogInformation("GetAllAppraisalResult Completed");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //Author : Ilyas Dabholkar
        //Takes List of AppraisalResult Dto and bulk inserts them into db
        [HttpPost("AddAppraisalResults")]
        public async Task<ActionResult> AddAppraisalResults(List<AddAppraisalResultDto> results)
        {
            _logger.LogInformation("AddAppraisalResults Initiated");
            var dtos = await _mediator.Send(new AddAppraisalResultCommand() { DataList = results });
            _logger.LogInformation("AddAppraisalResults Completed");
            return Ok(dtos);
        }


        //Author : Ilyas Dabholkar
        //returns list of all appraisals data 
        [HttpGet("GetAllReporteeAppraisal")]
        public async Task<ActionResult> GetAllReporteeAppraisal()
        {
            try
            {
                _logger.LogInformation("GetAllReporteeAppraisal Initiated");
                var res = await _mediator.Send(new GetAllReporteeAppraisalsQuery());
                _logger.LogInformation("GetAllReporteeAppraisal Completed");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        //Author : Ilyas Dabholkar
        //Endpoint takes id of reporting autority and return list of appraisals data belonging to that reporting authority
        [HttpGet("GetReporteeAppraisalByRepAuthority")]
        public async Task<ActionResult> GetReporteeAppraisalByRepAuthority(int id)
        {
            try
            {
                _logger.LogInformation("GetReporteeAppraisalByRevAuthority Initiated");
                var res = await _mediator.Send(new GetReporteeAppraisalsByRepAuthorityQuery() { Id=id});
                _logger.LogInformation("GetReporteeAppraisalByRevAuthority Completed");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddAppraisal")]

        public async Task<ActionResult> AddAppraisal( AddAppraisalVM addAppraisalVM)
        {
            var response = await _mediator.Send(new AddAppraisalCommand() { addAppraisal = addAppraisalVM });
            return Ok(response);
        }

        [HttpGet("GetAppraisalResultsByAppraisalId")]
        public async Task<ActionResult> GetAppraisalResultsByAppraisalId(int id)
        {
            var response = await _mediator.Send(new GetApprasisalResultsByAppraisalIdQuery() { Id = id });
            return Ok(response);
        }

        [HttpPut("UpdateAppraisalResults")]
        public async Task<ActionResult> UpdateAppraisalResults(List<UpdateAppraisalResultDto> results)
        {
            _logger.LogInformation("UpdateAppraisalResults Initiated");
            var dtos = await _mediator.Send(new UpdateAppraisalResultCommand() { DataList = results });
            _logger.LogInformation("UpdateAppraisalResults Completed");
            return Ok(dtos);
        }



    }
}
  
