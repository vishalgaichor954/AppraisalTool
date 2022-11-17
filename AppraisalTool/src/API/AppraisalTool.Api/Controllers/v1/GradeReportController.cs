using AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears;
using AppraisalTool.Application.Features.GradeReports.Queries.GetChartData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GradeReportController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<GradeReportController> _logger;

        public GradeReportController(IMediator mediator, ILogger<GradeReportController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetChartsData")]
        public async Task<ActionResult> GetChartsData(int Fid,int userId)
        {
            _logger.LogInformation("GetChartsData Initiated");
            var dtos = await _mediator.Send(new GetChartDataQuery() { FinancialYearId=Fid,UserId=userId});
            _logger.LogInformation("GetChartsData Completed");
            return Ok(dtos);
        }
    }
}
