using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Command.RemoveBranchCommand
{
    public class RemoveBranchesCommandHandler : IRequestHandler<RemoveBranchesCommand, Response<RemoveBranchesCommandDto>>
    {
      
      
        private readonly IBranchRepository _branchRepository;

        public RemoveBranchesCommandHandler(IBranchRepository branchRepository)
        {
           

            _branchRepository = branchRepository;
        }
       
        public async Task<Response<RemoveBranchesCommandDto>> Handle(RemoveBranchesCommand request, CancellationToken cancellationToken)
        {
            var res = await _branchRepository.RemoveBranch(request.Id);
            if (res.Succeeded)
            {
                return new Response<RemoveBranchesCommandDto>(res, "Success");
            }
            else
            {
                return new Response<RemoveBranchesCommandDto>(res, "Failed");
            }
        }
    }
}
