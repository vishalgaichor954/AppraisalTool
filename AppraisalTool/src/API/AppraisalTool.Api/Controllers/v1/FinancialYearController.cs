using AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears;
using AppraisalTool.Application.Features.Users.Query.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
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

        [HttpGet("GetAllFinancialYears")]
        public async Task<ActionResult> GetAllFinancialYears()
        {
            _logger.LogInformation("GetAllFinancialYears Initiated");
            var dtos = await _mediator.Send(new GetAllFinancialYearsQuery());
            _logger.LogInformation("GetAllFinancialYears Completed");
            return Ok(dtos);
        }
    }
}
