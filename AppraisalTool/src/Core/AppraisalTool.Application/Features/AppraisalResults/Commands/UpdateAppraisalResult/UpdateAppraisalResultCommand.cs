using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.AppraisalResults.Commands.UpdateAppraisalResult
{
    public class UpdateAppraisalResultCommand: IRequest<Response<string>>
    {
        public List<UpdateAppraisalResultDto> DataList { get; set; }
    }
}
