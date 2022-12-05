using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Command.UpdateUserRoleCommand
{
    public class UpdateUserRolesCommandHandler : IRequestHandler<UpdateUserRolesCommand, Response<UpdateUserRolesCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _rolerepository;

        public UpdateUserRolesCommandHandler(IMapper mapper, IUserRoleRepository roleRepository)
        {
            _mapper = mapper;
            _rolerepository = roleRepository;
        }
        public async Task<Response<UpdateUserRolesCommandDto>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var Response = await _rolerepository.UpdateUserRole(request, request.Id);
            if (Response.Succeeded)
            {
                return new Response<UpdateUserRolesCommandDto>(Response, "Success");
            }
            else
            {
                return new Response<UpdateUserRolesCommandDto>(Response, "Failed");
            }
        }
    }
}
