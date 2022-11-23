using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalList;
using AppraisalTool.Application.Features.Users.Command.CreateRoleCommand;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Models.Mail;
using AppraisalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        //private readonly IAuthenticationService _authService;

        public UserRepository(ApplicationDbContext context, ILogger<User> logger/* IAuthenticationService authservice*/) : base(context, logger)
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
                return await _dbContext.User.FirstOrDefaultAsync(obj => obj.Email == u.Email);

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
            if (user != null)
            {
                response.Message = "Email id Already Exist .";
                response.Succeeded = false;
                return response;

            }
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
        public async Task<bool> AssignAuthority(int repaId, int revaId, int userId)
        {
            try
            {
                await _dbContext.UserAuthorityMappings.AddAsync(new UserAuthorityMapping() { ReportingAuthorityId = repaId, ReviewingAuthorityId = revaId, UserId = userId });
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        //public async Task<bool> AssignAuthority(int repaId,int revaId,int userId)
        //{
        //    try
        //    {
        //        await _dbContext.UserAuthorityMappings.AddAsync(new UserAuthorityMapping() { ReportingAuthorityId = repaId, ReviewingAuthorityId = revaId, UserId = userId });
        //        await _dbContext.SaveChangesAsync();
        //        return true;
        //    }
        //    catch(Exception e)
        //    {
        //        return false;
        //    }

        //}

        //@Author : Ilyas Dabholkar
        public async Task<User> FindUserByEmail(string email)
        {
            User user = await _dbContext.User.Include(x => x.Role).Include(x => x.JobRoles).ThenInclude(x => x.JobRole).FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
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
                user.IsDeleted = true;
                //await DeleteAsync(user);
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
            
            int PrimaryJobProfileId = 0;
            int SecondaryJobProfileId = 0;
            UpdateUserCommandDto response = new UpdateUserCommandDto();
            var userToUpdate = await _dbContext.User.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (userToUpdate != null)
            {
                
                userToUpdate.FirstName = request.FirstName;
                userToUpdate.LastName = request.LastName;
                userToUpdate.Email = request.Email;
                userToUpdate.RoleId = (int)request.RoleId;
                userToUpdate.BranchId = (int)request.BranchId;
                var Getuserrole = await GetUserById(userToUpdate.Id);
                


                foreach (UserJobRoles item in Getuserrole.JobRoles)
                {
                    if (item.IsPrimary)
                    {

                        item.JobRoleId= (int)request.PrimaryJobProfileId;

                    }
                    else if (item.IsSecondary)
                    {

                        item.JobRoleId = (int)request.SecondaryJobProfileId;
                    }
                }
                var authority = await _dbContext.UserAuthorityMappings.Where(x => x.UserId == userToUpdate.Id).FirstOrDefaultAsync();
                if (authority != null)
                {
                    authority.ReportingAuthorityId = request.RepaId;
                    authority.ReviewingAuthorityId = request.RevaId;
                }
             
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

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //@Author : Ilyas Dabholkar
        public async Task<CreateRoleCommandDto> CreateUserRole(UserJobRoles request)
        {
            CreateRoleCommandDto response = new CreateRoleCommandDto();
            await _dbContext.UserJobRoles.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            response.Message = "UserRole Added successfully .";
            return response;
        }


        public async Task<IEnumerable<User>> GetAllUser()
        {
            IEnumerable<User> users = await _dbContext.User.Include(x => x.Branch).Include(x => x.Role).Include(x => x.JobRoles).ThenInclude(x => x.JobRole).Where(u=>u.IsDeleted !=true).ToListAsync();
            return users;
            
        }
        //public async Task<bool> AssignAuthority(int repaId, int revaId, int userId)
        //{
        //    try
        //    {
        //        await _dbContext.UserAuthorityMappings.AddAsync(new UserAuthorityMapping() { ReportingAuthorityId = repaId, ReviewingAuthorityId = revaId, UserId = userId });
        //        await _dbContext.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //}

        //@Author : Ilyas Dabholkar
        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.User.Include(x => x.Branch).Include(x => x.Role).Include(x => x.JobRoles).ThenInclude(x => x.JobRole).FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted != true);
            return user;


        }

        public async Task<User> GetUserByRoleId(int roleId)
        {
            var user = await _dbContext.User.Where(u => u.RoleId == roleId).FirstOrDefaultAsync();
            return user;
        }

        //@author :triveni patil
        public async Task<GetUserListQueryVm> GetUserbyid(int id)
        {
            var user = await _dbContext.User.Include(x => x.Branch).Include(x => x.Role).Include(x => x.JobRoles).ThenInclude(x => x.JobRole).FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted != true);
            string primaryRole = "";
            string secondaryRole = "";
            int primaryRoleId = 0;
            int secondaryRoleId = 0;

            foreach (UserJobRoles item in user.JobRoles)
            {
                if (item.IsPrimary)
                {
                    primaryRole = item.JobRole.Name;
                    primaryRoleId = item.JobRole.Id;

                }
                else if (item.IsSecondary)
                {
                    secondaryRole = item.JobRole.Name;
                    secondaryRoleId = item.JobRole.Id;
                }
            }

            var result = (from A in _dbContext.User
                          join B in _dbContext.UserAuthorityMappings on A.Id equals B.UserId
                          select new GetUserListQueryVm
                          {
                              Id = A.Id,
                              FirstName = A.FirstName,
                              LastName = A.LastName,
                              Email = A.Email,
                              BranchId = A.BranchId,
                              BranchName = A.Branch.BranchName,
                              JoinDate = A.JoinDate,
                              LastAppraisalDate = A.LastAppraisalDate,
                              Role = A.RoleId,
                              RoleName = A.Role.Role,
                              PrimaryJobProfileId = primaryRoleId,
                              PrimaryJobProfileName = primaryRole,
                              SecondaryJobProfileId = secondaryRoleId,
                              SecondaryJobProfileName = secondaryRole,
                              RepaId = B.ReportingAuthorityId,
                              RevaId = B.ReviewingAuthorityId

                          });
            var res = await result.Where(u => u.Id == id).FirstOrDefaultAsync();
            return res;
                        
        }
        
        public async Task<IEnumerable<GetAppraisalDto>> GetAllAppraisals()
        {
            //IEnumerable<Appraisal> appraisals = await _dbContext.Appraisal.Include(x => x.Id).
            //    Include(x => x.UserId).
            //    Include(x => x.StatusId).
            //    Include(x => x.FinancialYearId).ToListAsync();
            //return appraisals;

            IEnumerable<GetAppraisalDto> res = (from A in _dbContext.User
                                                join B in _dbContext.Appraisal on A.Id equals B.UserId



                                                select new GetAppraisalDto
                                                {
                                                    AppraisalId = B.Id,
                                                    UserId=B.UserId,
                                                    Firstname=A.FirstName,
                                                    LastName=A.LastName,
                                                    FinanceYearId=B.FinancialYearId,
                                                    StartYear=B.FinancialYear.StartYear,
                                                    EndYear=B.FinancialYear.EndYear,
                                                    StatusId=B.StatusId,
                                                    StatusName = B.Status.StatusTitle,

                                                }) ;
            return res;



        }


    }

       
        
  } 


        
