using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApp.Core.Services;
using WebApp.Repositories;
using WebApp.Database;

namespace WebApp.Controllers
{
    public class SystemController : ApiController
    {
        private readonly IAlertsService _alertsService;
        private readonly IAlertsRepository _alertsRepository;

        public SystemController(IAlertsService alertsService, IAlertsRepository alertsRepository)
        {
            _alertsService = alertsService;
            _alertsRepository = alertsRepository;
        }

        public IHttpActionResult UpdateAlerts()
        {
            try
            {
                var parsers = _alertsService.GetAlertsParsers();

                foreach (var parser in parsers)
                {
                    var alerts = parser.Value.GetAlerts();
                    var filteredAlerts = FilterAlerts(alerts);                    
                    _alertsRepository.Add(alerts.ToArray());
                }

                return new StatusCodeResult(HttpStatusCode.OK, this);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }            
        }

        private IEnumerable<Alert> FilterAlerts(IEnumerable<Alert> alerts)
        {                       
            return null;
        }

        private void InsertAlertToDb(Alert alert)
        {
            alert.Search_key = string.Format("{0}-{1}-{2}",
                alert.Source_id, alert.Subject, alert.Notify_time.ToString());

            _alertsRepository.Add(alert);
        }

        
        // Search notifications logic
        // Update db with new notifications        
    }
}
