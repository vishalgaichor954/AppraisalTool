using AppraisalTool.Application.Contracts.Infrastructure;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Models.Mail;
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

namespace AppraisalTool.Application.Features.Users.Command.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<CreateUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly IAuthenticationService _authService;

        public CreateUserCommandHandler(IAuthenticationService authService, IUserRepository userRepository, ILogger<CreateUserCommandHandler> logger, IMapper mapper, IEmailService emailService, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
            _emailservice = emailService;
            _authService = authService;
            _roleRepository = roleRepository;
        }

        #region This method will call repository method 
        /// <summary>
        /// 01/11/2021 - This method will call repository method
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>return createuserDto</returns>
        public async Task<Response<CreateUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            //primaryRole=request.primaryrole
            //SecondaryRole=request.SecondaryRole
            
          
            var user = _mapper.Map<User>(request);

            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            

            var userDto = await _userRepository.RegisterUserAsync(user);
            if (userDto != null)
            {

                List<UserJobRoles> jobList = new List<UserJobRoles>()
                {
                    new UserJobRoles(){UserId = userDto.Id,JobRoleId=request.PrimaryRole,IsPrimary=true,IsSecondary=false},
                    new UserJobRoles(){UserId = userDto.Id,JobRoleId=request.SecondaryRole,IsPrimary=false,IsSecondary=true}
                };
                await _roleRepository.AddJobRoles(jobList);
            }
            //bool authorityStatus = await _userRepository.AssignAuthority(request.RepaId,request.RevaId, userDto.Id);

            _logger.LogInformation("Hanlde Completed");
            if (userDto.Succeeded /*&& authorityStatus == true*/)
            {
                var email = new Email()
                {
                    To = request.Email,
                    Body = $"Hello {request.FirstName} {request.LastName}, <br/><br/>Your account has been successfully created on Appraisal Portal.<br/>\r\n  Please  refer below credentials for login on the portal.<br/>\r\n Email :  {request.Email} <br/>\r\n Password : {request.Password} <br /> <br/>Regards, <br/> support team.",
                    Subject = $"{request.FirstName} Registered Successfully !!"
                };
                await _emailservice.SendEmail(email);
                return new Response<CreateUserDto>(userDto, "success");
            }
            else
            {
                var res = new Response<CreateUserDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }


        }
    }
    #endregion
}
