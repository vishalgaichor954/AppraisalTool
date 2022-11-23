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

        //Author : Ilyas Dabholkar
        //Accepts List of AppraisalReult and bulk inserts them
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

        //Author : Ilyas Dabholkar
        //Returns List of AppraisalResults with provided appraisalId
        public async Task<List<AppraisalResult>> GetAppraisalResultsByApppraisalId(int id)
        {
            List<AppraisalResult> list = await _dbContext.AppraisalResult.Where(item => item.AppraisalId == id).ToListAsync();
            return list;
        }

        //Author : Ilyas Dabholkar
        public async Task<bool> UpdateAprraisalResultData(List<AppraisalResult> appraisalResult)
        {
            try
            {
                _dbContext.AppraisalResult.UpdateRange(appraisalResult);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        //Author : Ilyas Dabholkar
        public async Task<List<AppraisalResult>> GetAprraisalResultData(int fYearId,int userId)
        {
            Appraisal? appraisal = await _dbContext.Appraisal.FirstOrDefaultAsync(item => item.UserId == userId && item.FinancialYearId == fYearId);
            if(appraisal!= null)
            {
                List<AppraisalResult> appraisalResults = await _dbContext.AppraisalResult.Where(item => item.AppraisalId == appraisal.Id).ToListAsync();
                return appraisalResults;
            }
            return null;
        }
      


    }
}
