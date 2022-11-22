using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.AppraisalResults.Commands.UpdateAppraisalResultByReva
{
    public class UpdateAppraisalResultByRevaCommand : IRequest<Response<string>>
    {
        public int AppraisalId { get; set; }
        public int StatusId { get; set; }
        public List<UpdateAppraisalResultByRevaDto> DataList { get; set; }
    }
}
