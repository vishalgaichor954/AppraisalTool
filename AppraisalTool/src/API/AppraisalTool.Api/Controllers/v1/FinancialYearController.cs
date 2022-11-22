using AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears;
using AppraisalTool.Application.Features.FinancialYears.Queries.GetFinancialYearsByUserJoining;
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
