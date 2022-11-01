using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserRole.GetBranchList
{
    public class GetBranchListQueryHandler : IRequestHandler<GetBranchListQuery, Response<IEnumerable<Branch>>>
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchListQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task<Response<IEnumerable<Branch>>> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
        {
            var getbranch= await _branchRepository.GetAllBranch();
            return new Response<IEnumerable<Branch>>(getbranch);
        }
    }
}
