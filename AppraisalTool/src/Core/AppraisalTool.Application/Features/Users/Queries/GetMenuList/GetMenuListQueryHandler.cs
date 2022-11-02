using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;

using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Queries.GetMenuList
{
    public class GetMenuListQueryHandler : IRequestHandler<GetMenuListQuery, Response<List<MenuRoleMapping>>>
    {
        private readonly IUserRepository _userRepository;
        public GetMenuListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<List<MenuRoleMapping>>> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
        {
            List<MenuRoleMapping> menu = await _userRepository.getAllCards(request.Id);

            var response = new Response<List<MenuRoleMapping>>(menu);
            return response;
        }
    }
}
