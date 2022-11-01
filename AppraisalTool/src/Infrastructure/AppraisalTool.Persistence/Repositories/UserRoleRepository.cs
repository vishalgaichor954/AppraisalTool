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
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext dbContext, ILogger<UserRole> logger) : base(dbContext, logger)
        {
        }

        public async Task<IEnumerable<UserRole>> GetAllRole()
        {
            return await ListAllAsync();
        }
    }
}
