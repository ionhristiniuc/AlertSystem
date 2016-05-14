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
    }
}
