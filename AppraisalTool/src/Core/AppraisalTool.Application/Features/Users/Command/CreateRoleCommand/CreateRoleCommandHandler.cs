using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.CreateRoleCommand
{
    public class CreateRoleCommandHandler:IRequestHandler<CreateRoleCommands,Response<CreateRoleCommandDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateRoleCommandHandler> _logger;
        private readonly IMapper _mapper;
        

        public CreateRoleCommandHandler(IUserRepository userRepository, ILogger<CreateRoleCommandHandler> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
          
        }

        public async Task<Response<CreateRoleCommandDto>> Handle(CreateRoleCommands request, CancellationToken cancellationToken)
        {
            var userRole = _mapper.Map<UserJobRoles>(request);
            var response = await _userRepository.CreateUserRole(userRole);
            return new Response<CreateRoleCommandDto>(response);

        }
    }
}
