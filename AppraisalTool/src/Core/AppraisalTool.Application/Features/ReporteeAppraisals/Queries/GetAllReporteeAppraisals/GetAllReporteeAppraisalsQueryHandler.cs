using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAllAppraisalResults;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetAllReporteeAppraisals
{
    public class GetAllReporteeAppraisalsQueryHandler : IRequestHandler<GetAllReporteeAppraisalsQuery, Response<List<ReporteeAppraisalListVm>>>
    {

        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        private readonly ILogger<GetAllReporteeAppraisalsQueryHandler> _logger;

        public GetAllReporteeAppraisalsQueryHandler(ISelfAppraisalRepository selfAppraisalRepository,ILogger<GetAllReporteeAppraisalsQueryHandler> logger)
        {
            _selfAppraisalRepository = selfAppraisalRepository;
            _logger = logger;
        }


        public async Task<Response<List<ReporteeAppraisalListVm>>> Handle(GetAllReporteeAppraisalsQuery request, CancellationToken cancellationToken)
        {
            var data = await _selfAppraisalRepository.GetAllReporteeAppraisals();
            return new Response<List<ReporteeAppraisalListVm>>(data, "success");
        }
    }
}
