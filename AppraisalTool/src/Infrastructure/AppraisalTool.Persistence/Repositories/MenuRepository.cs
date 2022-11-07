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
    public class MenuRepository : BaseRepository<MenuList>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext dbContext, ILogger<MenuList> logger) : base(dbContext, logger)
        {
        }
    }
}
