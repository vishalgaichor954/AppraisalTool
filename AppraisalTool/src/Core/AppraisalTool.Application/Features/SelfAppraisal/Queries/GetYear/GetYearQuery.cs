using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.SelfAppraisal.Queries.GetYear
{
    public class GetYearQuery : IRequest<Response<IEnumerable<GetYearVm>>>
    {
        public int UserId { get; set; }
    }
}
