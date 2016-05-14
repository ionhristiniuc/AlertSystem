using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.AlertsParsers;
using WebApp.Core.AlertsParsers.RssParsers;
using WebApp.Core.Enums;
using WebApp.Database;

namespace WebApp.Core.Factories
{
    public class AlertsParsersFactory
    {
        public IAlertsParser CreateParser(Source s)
        {
            var type = (ParserTypesEnum) Enum.Parse(typeof (ParserTypesEnum), s.ParserType);

            switch (type)
            {
                case ParserTypesEnum.RssFeed:
                    return new RssFeedParser(s);
                case ParserTypesEnum.GazNaturalFenosaHtmlParser:
                    return null;
                default:
                    throw new ArgumentException("Unexpected Parser Name " + s.Name);
            }
        }
    }
}
