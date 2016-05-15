using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Extensions;
using WebApp.Database;

namespace WebApp.Repositories
{
    public class AlertsRepository : GenericRepository<Alert>, IAlertsRepository
    {
        public void Add(params Alert[] items)
        {
            foreach (var alert in items)
                alert.Search_key = alert.GetSearchKey();

            base.Add(items);
        }

        public IEnumerable<Alert> GetUnreadAlerts(int userId)
        {
            using (var dbModel = new alertSystemEntities())
            {
                var res = from a in dbModel.Alerts
                          join uaq in dbModel.UserAlertQueue on 
                          new
                          {
                              AlertId = a.Id,
                              UserId = userId
                          }
                          equals
                          new
                          {
                              AlertId = uaq.AlertId,
                              UserId = uaq.UserId
                          }
                          into oj
                          from sub in oj.DefaultIfEmpty()
                          where sub.Id == null
                          select a;

                return res.ToList();
            }
        }

        public void MarkAlertAsRead(int userId, int alertId)
        {
            IGenericRepository<UserAlertQueue> repo = new GenericRepository<UserAlertQueue>();
            var existentObj = repo.GetSingle(uaq => uaq.AlertId == alertId && uaq.UserId == userId);

            if (existentObj == null)
            {
                var uaq = new UserAlertQueue()
                {
                    AlertId = alertId,
                    UserId = userId,
                    ViewedOn = DateTime.UtcNow
                };

                repo.Add(uaq);                
            }
        }
    }
}
