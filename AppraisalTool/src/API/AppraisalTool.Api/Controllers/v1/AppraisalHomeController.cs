using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetYear;
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

        [HttpGet]
        public async Task<ActionResult> GetYear(int userId)
        {

            _logger.LogInformation("GetYear Initiated");
            var dtos = new GetYearQuery() { UserId = userId };
            _logger.LogInformation("GetYear Completed");
            return Ok(await _mediator.Send(dtos));

        }


    }
}
