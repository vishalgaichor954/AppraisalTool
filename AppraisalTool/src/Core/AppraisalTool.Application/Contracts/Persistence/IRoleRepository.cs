using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<JobRoles>> GetAllJobRoles();
        public Task<bool> AddJobRoles(List<UserJobRoles> userJobRoles);
    }

}
