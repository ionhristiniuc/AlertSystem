using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Database;
using SimpleFeedReader;

namespace WebApp.Core.AlertsParsers.RssParsers
{
    public class RssFeed : IAlertsParser
    {
        private string _url;
        
        public RssFeed(Source source)
        {
            _url = source.URL;            
        }

        private List<Alert> ParseAlerts()
        {
            List<Alert> alerts = new List<Alert>();
            var reader = new FeedReader();
            var items = reader.RetrieveFeed(_url);

            foreach (var i in items)
            {
                Alert alert = new Alert();
                alert.Subject = i.Title;
                alert.Text = i.Summary;
                alert.Notify_time = i.Date.UtcDateTime;
                alerts.Add(alert);
            }

            return alerts;
        }

        public IEnumerable<Alert> GetAlerts()
        {
            return ParseAlerts();            
        }
    }
}