using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApp.Core.Services;
using WebApp.Repositories;

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
                    // choose which alerts will be updated - filter
                    _alertsRepository.Add(alerts.ToArray());
                }

                return new StatusCodeResult(HttpStatusCode.OK, this);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }            
        }

        // Search notifications logic
        // Update db with new notifications        
    }
}
