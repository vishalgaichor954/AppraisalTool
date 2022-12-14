using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Command.RemoveUserRoleCommand
{
    public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRolesCommand, Response<RemoveUserRoleCommandDto>>
    {
        private readonly IRoleRepository _rolerepository;

        public RemoveUserRoleCommandHandler(IRoleRepository roleRepository)
        {
            _rolerepository = roleRepository;
        }
        public async Task<Response<RemoveUserRoleCommandDto>> Handle(RemoveUserRolesCommand request, CancellationToken cancellationToken)
        {
            var res = await _rolerepository.RemoveUserRole(request.Id);
            if (res.Succeeded)
            {
                return new Response<RemoveUserRoleCommandDto>(res, "Success");
            }
            else
            {
                return new Response<RemoveUserRoleCommandDto>(res, "Failed");
            }
        }
    }
}
