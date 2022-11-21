using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IFinancialYearRepository: IAsyncRepository<FinancialYear>
    {
        public Task<List<FinancialYear>> GetAllFinancialYears();

        public Task<List<FinancialYear>> GetFinancialYearsByUserJoining(int userId);
    }
}
