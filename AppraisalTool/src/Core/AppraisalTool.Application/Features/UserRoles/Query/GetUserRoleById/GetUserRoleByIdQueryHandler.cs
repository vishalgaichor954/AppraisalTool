using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Query.GetUserRoleById
{
    public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, Response<GetUserRoleByIdQueryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _rolerepository;

        public GetUserRoleByIdQueryHandler(IMapper mapper, IUserRoleRepository roleRepository)
        {
            _mapper = mapper;
            _rolerepository = roleRepository;
        }
        public async Task<Response<GetUserRoleByIdQueryDto>> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _rolerepository.GetUserRoleById(request.Id);
            var response = _mapper.Map<GetUserRoleByIdQueryDto>(res);
            return new Response<GetUserRoleByIdQueryDto>(response, "Success");
        }
    }
}
