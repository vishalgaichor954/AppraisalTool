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

namespace AppraisalTool.Application.Features.Users.Command.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<UpdateUserCommandDto>>
    {
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authservice;
        private readonly IRoleRepository _roleRepository;


        public UpdateUserCommandHandler(IRoleRepository roleRepository,IAuthenticationService authservice ,ILogger<UpdateUserCommandHandler> logger,IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
            _authservice = authservice;
            _roleRepository=roleRepository;
        }
        #region This method will call repository method 
        /// <summary>
        /// 01/11/2021 - This method will call repository method
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>UpdateUserCommandDto</returns>
        public async Task<Response<UpdateUserCommandDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateUserCommandHandler Intiated");
            var userDto = await _userRepository.UpdateUserAsync(request.Id, request);
            _logger.LogInformation("UpdateUserCommandHandler Completed");            
            if (userDto.Succeeded)
            {
                return new Response<UpdateUserCommandDto>(userDto, "Success");
            }
            else
            {
                var res = new Response<UpdateUserCommandDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
        #endregion
    }
}
