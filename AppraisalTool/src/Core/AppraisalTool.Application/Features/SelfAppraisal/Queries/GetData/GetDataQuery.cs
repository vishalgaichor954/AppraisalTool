using AppraisalTool.Application.Response;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData
{
    public class GetDataQuery : IRequest<Response<IEnumerable<GetDataVM>>>

    {
       
        public int UserId { get; set; }
        public int FyId { get; set; }
    }
}
