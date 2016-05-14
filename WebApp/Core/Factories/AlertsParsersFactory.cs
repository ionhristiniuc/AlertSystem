using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.AlertsParsers;
using WebApp.Core.AlertsParsers.RssParsers;

namespace WebApp.Core.Factories
{
    public class AlertsParsersFactory
    {
        public IAlertsParser CreateParser(string name)
        {
            switch (name)
            {
                case "Moldtelecom":
                    return new MoldtelecomAlertsParser();
                default:
                    throw new ArgumentException("Unexpected Parser Name " + name);
            }
        }
    }
}
