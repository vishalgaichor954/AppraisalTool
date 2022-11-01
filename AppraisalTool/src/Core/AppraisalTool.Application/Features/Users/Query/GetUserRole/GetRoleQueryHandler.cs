using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserRole
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Response<IEnumerable<JobRoles>>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository=roleRepository;
        }
        public async Task<Response<IEnumerable<JobRoles>>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var getroles=await _roleRepository.GetAllJobRoles();
            return new Response<IEnumerable<JobRoles>>(getroles);
        }
    }
}
