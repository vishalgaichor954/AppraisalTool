using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Command.UpdateBranchCommand
{
    public class UpdateBranchCommand : IRequest<Response<UpdateBranchCommandDto>>
    {
        public int Id { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
    }
}
