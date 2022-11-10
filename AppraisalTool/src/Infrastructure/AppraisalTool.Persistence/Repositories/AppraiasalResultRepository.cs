using AppraisalTool.Application.Contracts.Persistence;
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
    public class AppraiasalResultRepository : BaseRepository<AppraisalResult>, IAppraisalResultRepository
    {
        public AppraiasalResultRepository(ApplicationDbContext dbContext, ILogger<AppraisalResult> logger) : base(dbContext, logger)
        {
           
        }

        public async Task<bool> AddAprraisalResultData(List<AppraisalResult> appraisalResult)
        {
            try
            {
                await _dbContext.AppraisalResult.AddRangeAsync(appraisalResult);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        public async Task<List<AppraisalResult>> GetAppraisalResultsByApppraisalId(int id)
        {
            List<AppraisalResult> list = await _dbContext.AppraisalResult.Where(item => item.AppraisalId == id).ToListAsync();
            return list;
        }
    
    }
}
