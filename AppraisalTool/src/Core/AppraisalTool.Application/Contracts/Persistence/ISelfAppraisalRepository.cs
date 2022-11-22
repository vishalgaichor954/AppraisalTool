using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Domain.Common;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface ISelfAppraisalRepository
    {
        public  Task<IQueryable<GetDataVM>> GetDataById(int userId);
        public  Task<List<Appraisal>> GetYear(int userId);
        public Task<List<ReporteeAppraisalListVm>> GetAllReporteeAppraisals();
        public Task<List<ReporteeAppraisalListVm>> GetReporteeAppraisalsByRepAuthority(int id);
        public Task<Appraisal> AddAppraisal(Appraisal addAppraisal);
        public Task<bool> UpdateAppraisalStatus(int appraisalId, int status);
        public Task<List<ReviewAppraisalListVm>> GetReviewAppraisalsByRevAuthority(int id);
        public Task<bool> UpdateAppraisalStatusByReva(int appraisalId, int statusId);
    }
}
