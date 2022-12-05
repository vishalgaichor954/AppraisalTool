using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.UserRoles.Command.CreateUserRoleCommand;
using AppraisalTool.Application.Features.UserRoles.Command.UpdateUserRoleCommand;
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
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext dbContext, ILogger<UserRole> logger) : base(dbContext, logger)
        {
        }
        #region UserRole Crud
        public async Task<IEnumerable<UserRole>> GetAllRole()
        {
            var res = await _dbContext.UserRole.Where(x => x.IsDeleted !=true).ToListAsync();
            return res;
        }

       
        public async Task<CreateUserRolesCommandDto> CreateUserRole(UserRole res)
        {
            CreateUserRolesCommandDto Response = new CreateUserRolesCommandDto();
            await _dbContext.UserRole.AddAsync(res);
            await _dbContext.SaveChangesAsync();
            Response.Message = "User Role Added Successfully";
            Response.Succeeded = true;
            return Response;
        }

        public async Task<UpdateUserRolesCommandDto> UpdateUserRole(UpdateUserRolesCommand request, int id)
        {
            UpdateUserRolesCommandDto response = new UpdateUserRolesCommandDto();
            var res = await _dbContext.UserRole.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res == null)
            {
                response.Message = "Role Id Not Exist";
                response.Succeeded = false;
                return response;
            }
            else
            {

                res.Id = request.Id;
                res.Role = request.Role;
                await _dbContext.SaveChangesAsync();

                response.Message = "Update Successfully";
                response.Succeeded = true;
                return response;
            }
        }

        public async Task<UserRole> GetUserRoleById(int id)
        {
            var res=await _dbContext.UserRole.Where(x=>x.Id==id).FirstOrDefaultAsync();
            return res;
        }


        #endregion
    }
}
