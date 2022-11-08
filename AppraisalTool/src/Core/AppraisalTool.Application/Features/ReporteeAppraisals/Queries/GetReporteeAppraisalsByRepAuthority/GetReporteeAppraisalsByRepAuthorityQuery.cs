using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetReporteeAppraisalsByRevAuthority
{
    public class GetReporteeAppraisalsByRepAuthorityQuery : IRequest<Response<List<ReporteeAppraisalListVm>>>
    {
       public int Id { get; set; }
    }
}
