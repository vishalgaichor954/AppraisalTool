using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Command.RemoveBranchCommand
{
    public class RemoveBranchesCommand:IRequest<Response<RemoveBranchesCommandDto>>
    {
     public RemoveBranchesCommand()
     {


     }
        public RemoveBranchesCommand(int id)
    {
        Id = id;

    }
    public int Id { get; set; }
}
}
