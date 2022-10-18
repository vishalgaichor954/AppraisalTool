using AppraisalTool.Application.Contracts.Infrastructure;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Models.Mail;
using AppraisalTool.Application.Responses;
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
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;

        public CreateUserCommandHandler(IUserRepository userRepository, ILogger<CreateUserCommandHandler> logger, IMapper mapper, IEmailService emailService)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
            _emailservice = emailService;
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
            var user = _mapper.Map<User>(request);
            var userDto = await _userRepository.RegisterUserAsync(user);
            _logger.LogInformation("Hanlde Completed");
            if (userDto.Succeeded)
            {
                ////var email = new Email()
                ////{
                ////    To = userDto.Email,
                ////    Body = $"Dear User, <br/><br/You application registered successfully on portal.<br/>\r\n we will contact you soon!.<br /><br />Thanks <br/> <br/>Regards, <br/> Team. Support",
                ////    Subject = "User Registered Successfully !!"
                ////};
                //await _emailservice.SendEmail(email);
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
