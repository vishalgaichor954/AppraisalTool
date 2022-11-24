using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserByRoleId
{
    public class GetUserByRoleIdHandler:IRequestHandler<GetUserByRoleIdQuery,Response<GetUserByRoleIdDto>>
    {
        private readonly IUserRepository _userrepository;
        private readonly IMapper _mapper;
        public GetUserByRoleIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userrepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetUserByRoleIdDto>> Handle(GetUserByRoleIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userrepository.GetUserByRoleId(request.RoleId);
            var userresponse = _mapper.Map<GetUserByRoleIdDto>(user);
            return new Response<GetUserByRoleIdDto>(userresponse, "Success");
        }
    }
}
