using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAllAppraisalResults;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByAppraisalId
{
    public class GetAppraisalResultsByAppraisalIdQueryHandler : IRequestHandler<GetApprasisalResultsByAppraisalIdQuery, Response<List<AppraisalResult>>>
    {

        private readonly IAppraisalResultRepository _appraisalResultRepository;
        private readonly ILogger<GetAppraisalResultsByAppraisalIdQueryHandler> _logger;

        public GetAppraisalResultsByAppraisalIdQueryHandler(IAppraisalResultRepository appraisalResultRepository,ILogger<GetAppraisalResultsByAppraisalIdQueryHandler> logger)
        {
            _appraisalResultRepository = appraisalResultRepository;
            _logger = logger;
        }

        public async Task<Response<List<AppraisalResult>>> Handle(GetApprasisalResultsByAppraisalIdQuery request, CancellationToken cancellationToken)
        {
            List<AppraisalResult> appraisalResults = await _appraisalResultRepository.GetAppraisalResultsByApppraisalId(request.Id);
            return new Response<List<AppraisalResult>>(appraisalResults, "success");
        }
    }
}
