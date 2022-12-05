using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Command.UpdateBranchCommand
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand , Response<UpdateBranchCommandDto>>
    {
        private readonly IBranchRepository _branchRepository;
        public UpdateBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task<Response<UpdateBranchCommandDto>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branchDto = await _branchRepository.UpdateBranchAsync(request.Id, request);
            if (branchDto.Succeeded)
            {
                return new Response<UpdateBranchCommandDto>(branchDto, "Success");
            }
            else
            {
                var res = new Response<UpdateBranchCommandDto>(branchDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}


