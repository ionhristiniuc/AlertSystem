using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Database;

namespace WebApp.Core.Extensions
{
    public static class AlertsExtensions
    {
        public static string GetSearchKey(this Alert alert)
        {
            return string.Format("{0}-{1}-{2}",
                alert.Source_id, alert.Subject, alert.Notify_time.ToString());
        }
    }
}