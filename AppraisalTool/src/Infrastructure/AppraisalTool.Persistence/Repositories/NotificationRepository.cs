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

                List<Notification> notifications = await _dbContext.Notifications.Where(x => x.UserId == id && x.IsRead == false).ToListAsync(); 

                //return notifications;
                return notifications.OrderByDescending(d => d.NotificationDate).ToList<Notification>();

            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }


        public async Task<string> ClearNotifications(List<int> notificationIdList)
        {
            try
            {
                //Appraisal appraisal = await _dbContext.Appraisal.FirstOrDefaultAsync(item => item.Id == id);
                notificationIdList.ForEach(notification =>
                {
                    _dbContext.Database.ExecuteSqlRaw($"Update Notifications Set IsRead=1 Where Id={notification}");
                });
                             //return notifications;
                return "wow";

            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }

        }

    }
}
