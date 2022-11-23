using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByFidAndUserId
{
    public class GetAppraisalResultsByFidAndUserIdQuery: IRequest<Response<List<GetAppraisalsByUidAndFidDto>>>
    {
        public int FinancialYearid { get; set; }
        public int UserId { get; set; }
    }
}
