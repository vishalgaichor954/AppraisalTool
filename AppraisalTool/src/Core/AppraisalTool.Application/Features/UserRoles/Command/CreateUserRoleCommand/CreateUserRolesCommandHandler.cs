using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Command.CreateUserRoleCommand
{
    public class CreateUserRolesCommandHandler : IRequestHandler<CreateUserRolesCommand, Response<CreateUserRolesCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _rolerepository;

        public CreateUserRolesCommandHandler(IMapper mapper, IUserRoleRepository roleRepository)
        {
            _mapper = mapper;
            _rolerepository = roleRepository;
        }
        public async Task<Response<CreateUserRolesCommandDto>> Handle(CreateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var res = _mapper.Map<UserRole>(request);
            var response = await _rolerepository.CreateUserRole(res);
            if (response.Succeeded)
            {
                return new Response<CreateUserRolesCommandDto>(response, "Success");
            }
            else
            {
                return new Response<CreateUserRolesCommandDto>(response, "Failed");
            }
        }
    }
}
