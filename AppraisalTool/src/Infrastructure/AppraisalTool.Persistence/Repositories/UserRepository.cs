using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
using AppraisalTool.Application.Models.Mail;
using AppraisalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Persistence.Repositories
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        //private readonly IAuthenticationService _authService;

        public UserRepository(ApplicationDbContext context, ILogger<User> logger/* IAuthenticationService authservice*/) :base(context, logger)
        {
            _dbContext = context;
            _logger = logger;
            //_authService = authservice;
        }

        public async Task<User> AddUser(User u)
        {
            User usr = await _dbContext.User.FirstOrDefaultAsync(obj => obj.Email == u.Email);
            if (usr == null)
            {
                await AddAsync(u);
                return await _dbContext.User.FirstOrDefaultAsync(obj => obj.Email  == u.Email);

            }
            else
            {
                throw new Exception("User with this login id already exists");
            }
        }

        public async Task<CreateUserDto> RegisterUserAsync(User request)
        {
            var user = _dbContext.User.Where(u => u.Email == request.Email).FirstOrDefault();
            CreateUserDto response = new CreateUserDto();
            if(user != null)
            {
                response.Message = "Email id Already Exist .";
                response.Succeeded = false;
                return response;

            }
            //_authService.CreatePasswordHash(response.Password, out byte[] passwordHash, out byte[] passwordSalt);
            //user.PasswordHash = passwordHash;
            //user.PasswordSalt = passwordSalt;
            await _dbContext.User.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            response.Email = request.Email;
            response.Id = request.Id;
            response.FirstName = request.FirstName;
            response.LastName = request.LastName;
            response.Succeeded = true;
            response.Message = "User registered successfully .";
            return response;


        }

        //@Author : Ilyas Dabholkar
        public async Task<User> FindUserByEmail(string email)
        {
            User user = await _dbContext.User.Include(x=>x.Role).Include(x=>x.JobRoles).ThenInclude(x=>x.JobRole).FirstOrDefaultAsync(u => u.Email == email);
            if(user == null)
            {
                return null;
            }
            return user;
        }
        //public async Task<dynamic> getCards(int id)
        //{
        //   var  menu = _dbContext.MenuRoleMappings.Where(x => x.Role_id == id).Include(y => y.MenuList).ToList();
        //    return menu;
        //}

        //@Author : Abhishek Singh
        public async Task<List<MenuRoleMapping>> getAllCards(int id)
        {
            List<MenuRoleMapping> menu = _dbContext.MenuRoleMappings.Where(x => x.Role_id == id).Include(y => y.MenuList).ToList();
            return menu;
        }


        public async Task<RemoveUserCommandDto> RemoveUserAsync(int id)
        {
            var user = await _dbContext.User.Where(u => u.Id == id).FirstOrDefaultAsync();

           RemoveUserCommandDto response = new RemoveUserCommandDto();
        
    
            if (user != null)
            {
                user.IsDeleted =true;
                await _dbContext.SaveChangesAsync();
                response.Id = id;
                response.Message = $"User of id:{id} has been removed successfully .";
                response.Succeeded = true;
                return response;
            }
            else
            {
                response.Id = id;
                response.Message = $"User of id:{id} does not exists .";
                response.Succeeded = false;
                return response;
            }
        }

        public async Task<UpdateUserCommandDto> UpdateUserAsync(int id, UpdateUserCommand request)
        {
            var user = await _dbContext.User.Where(u => u.Email ==request.Email).FirstOrDefaultAsync();
            UpdateUserCommandDto response = new UpdateUserCommandDto();
            if (user!= null)
            {
                response.Message = "Email Already Exist";
                response.Succeeded = false;
                return response;
            }
            var userToUpdate=await _dbContext.User.Where(u=>u.Id==id).FirstOrDefaultAsync();
            if (userToUpdate != null)
            {
                userToUpdate.Id = request.Id;
                userToUpdate.FirstName=request.FirstName;
                userToUpdate.LastName=request.LastName;
                userToUpdate.Email=request.Email;
                userToUpdate.RoleId = request.RoleId;
                userToUpdate.BranchId = request.BranchId;
                await _dbContext.SaveChangesAsync();
                response.Message = "User Details Update Successfully";
                response.Succeeded = true;
                response.Id = userToUpdate.Id;
                return response;
            }
            else
            {
                response.Message = "User Doesnt Exist";
                response.Succeeded = false;
                return response;
            }
        }

         //@Author : Ilyas Dabholkar
        public async Task<bool> UpdateUser(User user)
        {
            await UpdateAsync(user);
            return true;
        }

        //@Author : Ilyas Dabholkar
        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.User.Include(x => x.Role).Include(x => x.JobRoles).ThenInclude(x => x.JobRole).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
