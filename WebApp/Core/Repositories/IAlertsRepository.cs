using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Database;

namespace WebApp.Repositories
{
    public interface IAlertsRepository : IGenericRepository<Alert>
    {
        IEnumerable<Alert> GetUnreadAlerts(int userId);
        void MarkAlertAsRead(int userId, int alertId);
    }
}
