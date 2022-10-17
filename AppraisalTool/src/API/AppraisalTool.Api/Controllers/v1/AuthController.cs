using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Categories.Commands.CreateCategory;
using AppraisalTool.Application.Models.AppraisalTool;
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

        public AuthController(IAuthenticationService authService,IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("/User/Register")]
        public async  Task<ActionResult> RegisterUser(AddUserViewModel model)
        {
            //#region Register
            //User user = new User()
            //{
            //    Name = model.Name,
            //    Email = model.Email,
            //    Password = model.Password,
            //    Address = model.Address,
            //    Role = "user",
            //    CreatedOn = DateTime.Now
            //};
            try
            {
                User user = _mapper.Map<User>(model);
                _authService.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                bool userAdded = await _authService.AddUser(user);
                if (userAdded)
                {
                    return Ok("User Created Successfully");
                }
                return BadRequest("Failed To Register User");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
