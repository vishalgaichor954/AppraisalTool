
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.UserJobProfileRoles.Command.CreateJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserJobProfileRoles.Command.RemoveJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserJobProfileRoles.Command.UpdateJobProfileRoleCommand;
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

    public class RoleRepository : BaseRepository<JobRoles>,IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext, ILogger<JobRoles> logger) : base(dbContext, logger)
        {
        }

        public async Task<IEnumerable<JobRoles>> GetAllJobRoles()
        {
            return await ListAllAsync();
        }

        public async Task<bool> AddJobRoles(List<UserJobRoles> userJobRoles)
        {
            try
            {
                await _dbContext.UserJobRoles.AddRangeAsync(userJobRoles);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        public async Task<CreateJobProfileCommandDto> AddJobProfileRole(JobRoles result)
        {
            CreateJobProfileCommandDto Response = new CreateJobProfileCommandDto();
            await _dbContext.JobRoles.AddAsync(result);
            await _dbContext.SaveChangesAsync();
            Response.Message = "JobProfile Role Added Successfully";
            Response.Succeeded = true;
            return Response;

        }

        public async Task<UpdateJobProfileCommandDto> UpdatejobProfileRole(UpdateJobProfileCommand request, int id)
        {
            UpdateJobProfileCommandDto response = new UpdateJobProfileCommandDto();
            var res = await _dbContext.JobRoles.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(res == null)
            {
                response.Message = "Job Profile Id Doesn't Exist";
                response.Succeeded = false;
                return response;
            }
            else
            {

                res.Id = request.Id;
                res.Name = request.Name;
                await _dbContext.SaveChangesAsync();
                response.Id = res.Id;
                response.Name = res.Name;
                response.Message = "Update Successfully";
                response.Succeeded=true;
                return response;
            }
        }

        public async Task<RemoveJobProfileCommandDto> RemoveJobProfileRole(int id)
        {
            RemoveJobProfileCommandDto Response = new RemoveJobProfileCommandDto();
            var res = await _dbContext.JobRoles.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                res.IsActive = false;
                await _dbContext.SaveChangesAsync();
                Response.Succeeded=true;
                Response.Message = $"Id{id} deleted Successfully";
                return Response;
            }
            else
            {
                Response.Succeeded = false;
                Response.Message = "Id Doesn'nt Exist";
                return Response;
            }
        }

        public async Task<JobRoles> GetJobProfileById(int id)
        {
            var res = await _dbContext.JobRoles.Where(x => x.Id == id).FirstOrDefaultAsync();
            return res;
        }
    }
}
