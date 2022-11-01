using AppraisalTool.Application.Contracts.Infrastructure;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Categories.Commands.CreateCategory;
using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Application.Models.Mail;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthenticationService _authService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;

        public AuthController(IAuthenticationService authService,IMapper mapper,IEmailService emailservice)
        {
            _authService = authService;
            _mapper = mapper;
            _emailservice = emailservice;
        }


        //@Author : Ilyas Dabholkar
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> RegisterUser(AddUserViewModel model)
        {
            try
            {
                User user = _mapper.Map<User>(model);
                _authService.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                bool userAdded = await _authService.AddUser(user);

                if (userAdded)
                {
                    var email = new Email()
                    {
                        To = model.Email,
                        Body = $"Dear User, <br/><br/>You application registered successfully on portal.<br/>\r\n  Kindly refer below credentials to Login.<br/>\r\nUsername : {model.Email} <br/>\r\nPassword : {model.Password}.<br /><br />Thanks <br/> <br/>Regards, <br/> Team. Support",
                        Subject = "User Registered Successfully !!"
                    };
                    await _emailservice.SendEmail(email);
                    return Ok("User Created Successfully");
                }
                return BadRequest("Failed To Register User");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //@Author : Ilyas Dabholkar
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> LoginUser(LoginUserViewModel model)
        {
            try
            {
                AuthenticationResponse response = await _authService.Login(model.Email, model.Password);
                if (response != null)
                {
                    return Ok(response);
                }
                return BadRequest(new AuthenticationResponse() { Message = "Failed to Login user", IsAuthenticated = false,Token=null,Role=null,Name=null,RoleId=null }); ;

            }
            catch(Exception e)
            {
                return BadRequest(new AuthenticationResponse() { Message = e.Message, IsAuthenticated = false, Token = null, Role = null,Name=null, RoleId = null });
            }
           
        }

        //@Author : Ilyas Dabholkar
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            string newPassword = await _authService.ResetPassword(email);
            if(newPassword != null)
            {
                var targetEmail = new Email()
                {
                    To = email,
                    Body = $"Dear User, <br/><br/>Your Password has been reset successfully<br/>\r\n  Use following credentials to Login.<br/>\r\nUsername : {email} <br/>\r\nPassword : {newPassword}.<br /><br />Thanks <br/> <br/>Regards, <br/> Team. Support",
                    Subject = "Password Reset Successfully !!"
                };
                await _emailservice.SendEmail(targetEmail);
                return Ok(new Response<string>() { Succeeded=true,Errors=null,Message="Password Reset Succcessfully",Data=null});
            }
            return BadRequest(new Response<string>() { Succeeded = false, Errors = { "Failed to reset password" }, Message = "Password Reset Failed", Data = null });

        }
    }
}
