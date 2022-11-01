using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserList
{

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, Response<IEnumerable<GetUserListQueryVm>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task<Response<IEnumerable<GetUserListQueryVm>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allusers = await _userRepository.GetAllUser();
            if (allusers != null)
            {
                return new Response<IEnumerable<GetUserListQueryVm>>(allusers, "success");
            }
            return new Response<IEnumerable<GetUserListQueryVm>>(allusers, "Failed");
        }
    }
}
