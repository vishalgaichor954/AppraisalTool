using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.ReviewAppraisals.Queries.GetReviewAppraisalsByRevAuthority
{
    public class GetReviewAppraisalsByRevAuthorityQuery : IRequest<Response<List<ReviewAppraisalListVm>>>
    {
        public int Id { get; set; }
    }
}


