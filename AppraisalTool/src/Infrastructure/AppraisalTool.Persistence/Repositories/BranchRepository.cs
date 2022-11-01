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
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext dbContext, ILogger<Branch> logger) : base(dbContext, logger)
        {
        }

        public async Task<IEnumerable<Branch>> GetAllBranch()
        {
            return await ListAllAsync();
        }
    }
}
