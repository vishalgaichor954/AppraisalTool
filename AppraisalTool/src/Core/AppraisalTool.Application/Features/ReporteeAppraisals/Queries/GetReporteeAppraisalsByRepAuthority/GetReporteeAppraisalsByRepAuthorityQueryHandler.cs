using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetAllReporteeAppraisals;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetReporteeAppraisalsByRevAuthority
{
    public class GetReporteeAppraisalsByRepAuthorityQueryHandler : IRequestHandler<GetReporteeAppraisalsByRepAuthorityQuery, Response<List<ReporteeAppraisalListVm>>>
    {
        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        private readonly ILogger<GetReporteeAppraisalsByRepAuthorityQueryHandler> _logger;

        public GetReporteeAppraisalsByRepAuthorityQueryHandler(ISelfAppraisalRepository selfAppraisalRepository, ILogger<GetReporteeAppraisalsByRepAuthorityQueryHandler> logger)
        {
            _selfAppraisalRepository = selfAppraisalRepository;
            _logger = logger;
        }

        public async Task<Response<List<ReporteeAppraisalListVm>>> Handle(GetReporteeAppraisalsByRepAuthorityQuery request, CancellationToken cancellationToken)
        {
            var data = await _selfAppraisalRepository.GetReporteeAppraisalsByRepAuthority(request.Id);
            return new Response<List<ReporteeAppraisalListVm>>(data, "success");
        }
    }
}
