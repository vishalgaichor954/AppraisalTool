using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
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

    }
}
