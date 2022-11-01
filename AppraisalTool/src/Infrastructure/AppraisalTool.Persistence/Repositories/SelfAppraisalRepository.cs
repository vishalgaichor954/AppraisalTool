using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;

namespace AppraisalTool.Persistence.Repositories
{
    public class SelfAppraisalRepository : ISelfAppraisalRepository
    {
       
        
        private readonly ApplicationDbContext _dbContext;

        public SelfAppraisalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }


        public async Task<List<Appraisal>> GetDataById(int userId, int financialYearId )
        {

            //var user = await _dbContext.User.Include(x => x.Role).Include(x => x.Appraisals).ThenInclude(x=>x.FinancialYear).FirstOrDefaultAsync(u => u.Id == userId );
            
            var appraisals = await _dbContext.Appraisal.Include(x => x.FinancialYear).Where(x => x.UserId == userId && x.FinancialYearId == financialYearId).Include(x=>x.User).ThenInclude(x=>x.Role).ToListAsync();
            


            //var appraisals = await _dbContext.FinancialYear.Include(y=>y.Appraisals).ToListAsync();


            //var user = await _dbContext.User.Include(x => x.Role).Include(x =>x.
            //List < User > users = _dbContext.User.ToList();
            //List<Appraisal> appraisals = _dbContext.Appraisal.ToList();
            //List<FinancialYear> financialYears = _dbContext.FinancialYear.ToList();
            //List<UserRole> userRoles = _dbContext.UserRole.ToList();

            //var result = (from A in _dbContext.User
            //              join B in _dbContext.Appraisal on A.Id equals B.UserId
            //              join C in _dbContext.FinancialYear on B.FinancialYearId equals C.Id










            //var appraisal1 = await  _dbContext.Appraisal.Where(x => x.UserId == appraisal.UserId && x.FinancialYearId == appraisal.FinancialYearId).ToListAsync();
            return appraisals;
        }
    }
}
