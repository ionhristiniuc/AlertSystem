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
using WebApp.Core.Extensions;

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
                    var newItems = GetNewAlerts(alerts);
                    _alertsRepository.Add(newItems.ToArray());
                }

                return new StatusCodeResult(HttpStatusCode.OK, this);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }            
        }

        private IEnumerable<Alert> GetNewAlerts(IEnumerable<Alert> alerts)
        {
            var searchKeys = alerts.Select(a => a.GetSearchKey());
            var existItems = _alertsRepository.GetList(a => searchKeys.Contains(a.Search_key));
            return alerts.Where(a => !existItems.Any(e => a.Search_key == e.Search_key));
        }                           
    }
}
