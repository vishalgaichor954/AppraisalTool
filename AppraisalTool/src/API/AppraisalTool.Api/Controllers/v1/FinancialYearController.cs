using AppraisalTool.Application.Features.FinancialYears.Command.CreateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.RemoveFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.UpdateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearById;
using AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
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
        public IActionResult AddFinancialYear(CreateFinancialYearCommand request)
        {
            _logger.LogInformation("AddFinancialYear Initiated ");
             var dtos= _mediator.Send(request);
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
            _logger.LogInformation("UpdateMenu Initiated");
            var dtos = await _mediator.Send(request);

            _logger.LogInformation("UpdateMenu Completed");
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
            var dtos = await _mediator.Send(new RemoveFinancialYearCommand() { Id= id });
            _logger.LogInformation("RemoveAsync Completed");
            return Ok(dtos);
        }
    }
}
