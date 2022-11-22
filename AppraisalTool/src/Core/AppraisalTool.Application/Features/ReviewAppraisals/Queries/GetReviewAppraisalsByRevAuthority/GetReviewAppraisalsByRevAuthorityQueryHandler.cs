using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.ReviewAppraisals.Queries.GetReviewAppraisalsByRevAuthority
{
    public class GetReviewAppraisalsByRevAuthorityQueryHandler : IRequestHandler<GetReviewAppraisalsByRevAuthorityQuery, Response<List<ReviewAppraisalListVm>>>
    {
        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        private readonly ILogger<GetReviewAppraisalsByRevAuthorityQueryHandler> _logger;

        public GetReviewAppraisalsByRevAuthorityQueryHandler(ISelfAppraisalRepository selfAppraisalRepository, ILogger<GetReviewAppraisalsByRevAuthorityQueryHandler> logger)
        {
            _selfAppraisalRepository = selfAppraisalRepository;
            _logger = logger;
        }

        public async Task<Response<List<ReviewAppraisalListVm>>> Handle(GetReviewAppraisalsByRevAuthorityQuery request, CancellationToken cancellationToken)
        {
            var data = await _selfAppraisalRepository.GetReviewAppraisalsByRevAuthority(request.Id);

            return new Response<List<ReviewAppraisalListVm>>(data, "success");
        }
    }
}
