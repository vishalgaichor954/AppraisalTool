using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAllAppraisalResults;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetDataByYear(int yearId, int userId)

        {
            _logger.LogInformation("GetDataByYear Initiated");
            var dtos = new GetDataQuery() { FinancialYearId = yearId, UserId = userId };
            _logger.LogInformation("GetDataByYear Completed");
            return Ok(await _mediator.Send(dtos));

        }

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

        [HttpPost("AddAppraisalResults")]
        public async Task<ActionResult> RegisterAsync(List<AddAppraisalResultDto> results)
        {
            _logger.LogInformation("AddAppraisalResults Initiated");
            var dtos = await _mediator.Send(new AddAppraisalResultCommand() { DataList = results});
            _logger.LogInformation("AddAppraisalResults Completed");
            return Ok(dtos);
        }


    }
}
