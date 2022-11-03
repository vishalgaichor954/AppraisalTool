using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
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
    }
}
