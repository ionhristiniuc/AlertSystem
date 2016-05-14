using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.AlertsParsers;

namespace WebApp.Core.Services
{
    public interface IAlertsService
    {
        IDictionary<int, IAlertsParser> GetAlertsParsers();
    }
}
