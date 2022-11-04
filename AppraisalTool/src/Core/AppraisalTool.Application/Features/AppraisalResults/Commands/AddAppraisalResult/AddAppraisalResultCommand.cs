using AppraisalTool.Application.Response;
using MediatR;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult
{
    public class AddAppraisalResultCommand : IRequest<Response<string>>
    {
        public List<AddAppraisalResultDto> DataList { get; set; }
    }
}
