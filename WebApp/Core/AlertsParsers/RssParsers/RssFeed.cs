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
        private List<Alert> alerts;

        public RssFeed(String url)
        {
            _url = url;
            alerts = new List<Alert>();

            ParseAlerts();
        }

        private void ParseAlerts()
        {
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
        }

        public IEnumerable<Alert> GetAlerts()
        {           
            return alerts;
        }
    }
}