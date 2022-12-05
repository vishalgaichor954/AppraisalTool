using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Command.AddBranchCommand
{
    public class AddBranchCommand : IRequest<Response<AddBranchCommandDto>>
    {
        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
    }
}
