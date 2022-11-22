using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalList
{
    public class GetAppraisalListQueryHandler : IRequestHandler<GetAppraisalListQuery, Response<IEnumerable<GetAppraisalDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAppraisalListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
       

        public async Task<Response<IEnumerable<GetAppraisalDto>>> Handle(GetAppraisalListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<GetAppraisalDto> allAppraisals = await _userRepository.GetAllAppraisals();
            if (allAppraisals != null)
            {
                //var dataVM = _mapper.Map<IEnumerable<GetAppraisalDto>>(allAppraisals);
                return new Response<IEnumerable<GetAppraisalDto>>(allAppraisals, "success");
            }
            return new Response<IEnumerable<GetAppraisalDto>>(null, "Failed");
        }
    }
}
