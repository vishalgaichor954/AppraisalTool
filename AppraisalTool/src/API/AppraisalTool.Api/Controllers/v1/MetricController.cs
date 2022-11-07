using AppraisalTool.Application.Features.Metrics.Queries.GetAllMetricsList;
using AppraisalTool.Application.Features.Metrics.Queries.GetMetricsByKraSubtype;
using AppraisalTool.Application.Features.Users.Query.GetUserRole;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppraisalTool.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MetricController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MetricController> _logger;

        public MetricController(IMediator mediator, ILogger<MetricController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllListOfMetric")]
        public async Task<ActionResult> GetAllListOfMetric()
        {
            var dtos = await _mediator.Send(new GetAllMetricsListQuery());
            return Ok(dtos);
        }

        [HttpGet]
        [Route("GetMetricsByKraSubtype")]
        public async Task<ActionResult> GetMetricsByKraSubtype(int id)
        {
            var dtos = await _mediator.Send(new GetMetricsByKraSubtypeQuery() { Id=id});
            return Ok(dtos);
        }

    }
}
