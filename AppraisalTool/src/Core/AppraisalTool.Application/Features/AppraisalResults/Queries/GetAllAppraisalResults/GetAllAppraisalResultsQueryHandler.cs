using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
using AppraisalTool.Application.Features.Users.Query.GetRoleList;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.AppraisalResults.Queries.GetAllAppraisalResults
{
    public class GetAllAppraisalResultsQueryHandler : IRequestHandler<GetAllAppraisalResultsQuery, Response<IEnumerable<AppraisalResult>>>
    {
        private readonly IAppraisalResultRepository _appraisalResultRepository;
        private readonly ILogger<GetAllAppraisalResultsQueryHandler> _logger;

        public GetAllAppraisalResultsQueryHandler(IAppraisalResultRepository appraisalResulrRepostory, ILogger<GetAllAppraisalResultsQueryHandler> logger)
        {
            _appraisalResultRepository = appraisalResulrRepostory;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<AppraisalResult>>> Handle(GetAllAppraisalResultsQuery request, CancellationToken cancellationToken)
        {
            var data = await _appraisalResultRepository.ListAllAsync();


            return new Response<IEnumerable<AppraisalResult>>(data, "success");

        }
    }

}