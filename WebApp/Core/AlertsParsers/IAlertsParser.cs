﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Database;

namespace WebApp.Core.AlertsParsers
{
    public interface IAlertsParser
    {
        IEnumerable<Alert> GetAlerts();
    }
}
