using AppraisalTool.Application.Features.FinancialYears.Command.CreateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.RemoveFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.UpdateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearById;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IFinacialYearRepository
    {
        public Task<CreateFinancialYearDto> AddFY(FinancialYear request);
        public Task<IEnumerable<FinancialYear>> ListFinancialYear();
        Task<UpdateFinancialYearCommandDto> UpdateFinancialYearAsync(int id, UpdateFinanacialYearCommand request);
        public Task<FinancialYear> GetFinancialYearById(int id);

        public Task<RemoveFinancialYearCommandDto> RemoveFinancialYear(int id);
    }
}
