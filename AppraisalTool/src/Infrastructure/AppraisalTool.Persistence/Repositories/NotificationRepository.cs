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
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext dbContext, ILogger<Notification> logger) : base(dbContext, logger)
        {
        }

        public async Task<List<Notification>> GetAllNotificationByUserId(int id)
        {

            try
            {
                //Appraisal appraisal = await _dbContext.Appraisal.FirstOrDefaultAsync(item => item.Id == id);

                List<Notification> notifications = await _dbContext.Notifications.Where(x => x.Id == id).ToListAsync(); 

                return notifications;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

    }
}
