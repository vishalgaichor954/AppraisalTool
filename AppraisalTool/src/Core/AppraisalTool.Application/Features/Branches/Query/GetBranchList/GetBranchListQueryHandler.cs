using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Query.GetBranchList
{
    public class GetBranchListQueryHandler : IRequestHandler<GetBranchListQuery, Response<IEnumerable<GetBranchDto>>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetBranchListQueryHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }


        public async Task<Response<IEnumerable<GetBranchDto>>> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
        {
            var allbranches = await _branchRepository.GetAllBranch();
            var response = _mapper.Map<IEnumerable<GetBranchDto>>(allbranches);
            if (response != null)
            {
                //var dataVM = _mapper.Map<IEnumerable<GetAppraisalDto>>(allAppraisals);
                return new Response<IEnumerable<GetBranchDto>>(response, "success");
            }
            return new Response<IEnumerable<GetBranchDto>>(null, "Failed");
        }
    }
}