using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Authority.Query.GetAllAuthority
{
    public class GetAllAuthorityQueryHandler: IRequestHandler<GetAllAuthorityQuery, Response<IEnumerable<GetAllAuthorityQueryVm>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorityQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetAllAuthorityQueryVm>>> Handle(GetAllAuthorityQuery request, CancellationToken cancellationToken)
        {
            var allusers = await _userRepository.GetAllUserList();
            if (allusers != null)
            {
                //var dataVM = _mapper.Map<IEnumerable<GetUserListQueryVm>>(allusers);
                return new Response<IEnumerable<GetAllAuthorityQueryVm>>(allusers, "success");
            }
            return new Response<IEnumerable<GetAllAuthorityQueryVm>>(null, "Failed");
        }
    }
}
