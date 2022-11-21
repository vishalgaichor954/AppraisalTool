using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalList
{
    public class GetAppraisalListQuery : IRequest<Response<IEnumerable<GetAppraisalDto>>>
    {
        

    }
}
