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
    public class FinancialYearRepository : BaseRepository<FinancialYear>, IFinancialYearRepository
    {

        private readonly ILogger _logger;

        public FinancialYearRepository(ApplicationDbContext dbContext, ILogger<FinancialYear> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<FinancialYear>> GetAllFinancialYears()
        {
            List<FinancialYear> years = _dbContext.FinancialYear.ToList();
            return years;
        }

        public async Task<List<FinancialYear>> GetFinancialYearsByUserJoining(int userId)
        {
            User user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == userId);
            int year = DateTime.Parse(user.JoinDate.ToString()).Year;
            List<FinancialYear> years = await _dbContext.FinancialYear.Where(item =>item.StartYear >= year).ToListAsync();
            return years;
        }
    }
}
