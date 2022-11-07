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
    public class MetricRepository : BaseRepository<ListOfMetrics>, IMetricRepository
    {
        public MetricRepository(ApplicationDbContext dbContext, ILogger<ListOfMetrics> logger) : base(dbContext, logger)
        {
        }

        public async Task<IEnumerable<ListOfMetrics>> GetListOfMetricsByKraSubType(int id)
        {
            IEnumerable<ListOfMetrics> metrics = await _dbContext.listOfMetrics.Where(x => x.List_Id == id).Include(x=>x.ListOfKra).ThenInclude(x=>x.KraTypes).ToListAsync();
            return metrics;
        }
    }
}
