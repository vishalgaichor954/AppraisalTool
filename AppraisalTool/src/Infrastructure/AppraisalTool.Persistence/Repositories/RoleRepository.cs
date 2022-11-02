
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
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

       
    }
}
