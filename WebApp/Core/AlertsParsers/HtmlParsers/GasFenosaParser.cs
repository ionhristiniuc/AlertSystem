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
        private readonly Source _source;
        private readonly HtmlWeb _webPage = new HtmlWeb();        

        public GasFenosaParser(Source source)
        {
            _source = source;            
        }

        public IEnumerable<Alert> GetAlerts()
        {
            var document = _webPage.Load(_source.URL);
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
                    Short_text = text,
                    Source_id = _source.Id,                                        
                    Notify_time = DateTime.ParseExact(timeText, "dd.mm.yyyy", null),                                                                                
                };
            }
        }
    }
}