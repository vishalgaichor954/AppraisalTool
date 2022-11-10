using AppraisalTool.Domain.Common;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IAppraisalResultRepository: IAsyncRepository<AppraisalResult>
    {
        public Task<bool> AddAprraisalResultData(List<AppraisalResult> appraisalResult);
        public Task<List<AppraisalResult>> GetAppraisalResultsByApppraisalId(int id);
        public Task<bool> UpdateAprraisalResultData(List<AppraisalResult> appraisalResult);
    }
}
