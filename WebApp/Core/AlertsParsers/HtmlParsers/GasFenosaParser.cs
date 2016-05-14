using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using WebApp.Database;

namespace WebApp.Core.AlertsParsers.HtmlParsers
{
    public class GasFenosaParser : IAlertsParser
    {
        private readonly HtmlWeb _webPage;
        private readonly string _url;

        public GasFenosaParser(HtmlWeb webPage, string url)
        {
            _webPage = webPage;
            _url = url;
        }

        public IEnumerable<Alert> GetAlerts()
        {
            var document = _webPage.Load(_url);
            var baseNodes = document.DocumentNode.SelectNodes(".//tr");

            foreach (var trNode in baseNodes)
            {
                var subjectDiv = trNode.SelectSingleNode(".//div[@class=\"views-field-title\"]");
                var textDiv = trNode.SelectSingleNode(".//div[@class=\"views-field-body\"]");
                var timeDiv = trNode.SelectSingleNode(".//div[@class=\"views-field-created\"]");

                var subject = subjectDiv.ChildNodes.FirstOrDefault(c => c.Name == "span")?.InnerText;
                var timeText = timeDiv.ChildNodes.FirstOrDefault(c => c.Name == "span")?.InnerText;
                var text = textDiv.ChildNodes.FirstOrDefault(c => c.Name == "span")?.InnerText;
               
                var link = subjectDiv.ChildNodes.FirstOrDefault(c => c.Name == "span")?
                                  .ChildNodes.FirstOrDefault(c => c.Name == "a")?.Attributes["href"].Value;

                // Get whole address.
                link = string.Concat(@"http://gasnaturalfenosa.md/press", link);

                yield return new Alert
                {
                    Subject = subject,
                    Text = text,
                    Notify_time = DateTime.ParseExact(timeText, "dd.mm.yyyy", null),
                };
            }
        }
    }
}