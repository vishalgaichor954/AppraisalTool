using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetRoleList
{
    public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, Response<IEnumerable<UserRole>>>
    {
        private readonly IUserRoleRepository _roleRepository;
         public GetRoleListQueryHandler(IUserRoleRepository roleRepository)
        {
        _roleRepository=roleRepository;
        }
         public async Task<Response<IEnumerable<UserRole>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var getroles = await _roleRepository.GetAllRole();
            return new Response<IEnumerable<UserRole>>(getroles);
        }
    }
}
