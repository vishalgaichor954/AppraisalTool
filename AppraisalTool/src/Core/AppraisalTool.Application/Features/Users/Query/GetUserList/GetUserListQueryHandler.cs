using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Profiles;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserList
{

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, Response<IEnumerable<GetUserListQueryVm>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository=userRepository;
            _mapper=mapper;
        }
        public async Task<Response<IEnumerable<GetUserListQueryVm>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allusers = await _userRepository.GetAllUser();
            if (allusers != null)
            {
                //var dataVM = _mapper.Map<IEnumerable<GetUserListQueryVm>>(allusers);
                return new Response<IEnumerable<GetUserListQueryVm>>(allusers, "success");
            }
            return new Response<IEnumerable<GetUserListQueryVm>>(allusers, "Failed");
        }
    }
}
