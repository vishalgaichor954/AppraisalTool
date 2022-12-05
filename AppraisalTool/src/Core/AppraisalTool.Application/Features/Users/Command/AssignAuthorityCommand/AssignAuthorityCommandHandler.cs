using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.AssignAuthorityCommand
{
    public class AssignAuthorityCommandHandler : IRequestHandler<AssignAuthorityCommand, Response<AssignAuthorityCommandDto>>
    {
        private readonly IUserRepository _userRepository;

        public AssignAuthorityCommandHandler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task<Response<AssignAuthorityCommandDto>> Handle(AssignAuthorityCommand request, CancellationToken cancellationToken)
        {
            
            var userDto = await _userRepository.AssignAuthority(request.Id, request);
           
            if (userDto.Succeeded)
            {
                return new Response<AssignAuthorityCommandDto>(userDto, "Success");
            }
            else
            {
                var res = new Response<AssignAuthorityCommandDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}
