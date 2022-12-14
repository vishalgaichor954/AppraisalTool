using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Command.RemoveJobProfileRoleCommand
{
    public class RemoveJobProfileCommandHandler : IRequestHandler<RemoveJobProfileCommand, Response<RemoveJobProfileCommandDto>>
    {
        private readonly IRoleRepository _rolerepository;
        
        public RemoveJobProfileCommandHandler(IRoleRepository roleRepository)
        {
            _rolerepository = roleRepository;
        }
        public async Task<Response<RemoveJobProfileCommandDto>> Handle(RemoveJobProfileCommand request, CancellationToken cancellationToken)
        {
            var res = await _rolerepository.RemoveJobProfileRole(request.Id);
            if (res.Succeeded)
            {
                return new Response<RemoveJobProfileCommandDto>(res, "Success");
            }
            else
            {
                return new Response<RemoveJobProfileCommandDto>(res, "Failed");
            }
        }
    }
}
