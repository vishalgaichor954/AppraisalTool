using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.RemoveUserCommand
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Response<RemoveUserCommandDto>>
    {
        private readonly ILogger<RemoveUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(ILogger<RemoveUserCommandHandler> logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger= logger;
            _mapper = mapper;
            _userRepository=userRepository;
        }
        public async Task<Response<RemoveUserCommandDto>> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Intiated");
            var userdto = await _userRepository.RemoveUserAsync(request.Id);
            _logger.LogInformation("Handle Completed");
            if (userdto.Succeeded)
            {
                return new Response<RemoveUserCommandDto>(userdto, "Success");
            }
            else
            {
                var res = new Response<RemoveUserCommandDto>(userdto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
