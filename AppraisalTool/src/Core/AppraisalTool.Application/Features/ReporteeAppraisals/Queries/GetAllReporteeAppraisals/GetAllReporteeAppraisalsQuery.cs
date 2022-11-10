using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetAllReporteeAppraisals
{
    public class GetAllReporteeAppraisalsQuery : IRequest<Response<List<ReporteeAppraisalListVm>>>
    {
    
    }
}
