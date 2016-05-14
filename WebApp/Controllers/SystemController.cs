using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.Practices.ObjectBuilder2;
using WebApp.Core.Services;
using WebApp.Repositories;
using WebApp.Database;
using WebApp.Core.Extensions;

namespace WebApp.Controllers
{
    [RoutePrefix("system")]
    public class SystemController : ApiController
    {
        private readonly IAlertsService _alertsService;
        private readonly IAlertsRepository _alertsRepository;

        public SystemController(IAlertsService alertsService, IAlertsRepository alertsRepository)
        {
            _alertsService = alertsService;
            _alertsRepository = alertsRepository;
        }

        [Route("update")]
        [HttpGet] // TODO should remove
        public IHttpActionResult UpdateAlerts()
        {
            try
            {
                var parsers = _alertsService.GetAlertsParsers();

                foreach (var parser in parsers)
                {
                    var alerts = parser.Value.GetAlerts();
                    alerts.ForEach(i => i.Source_id = parser.Key);
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
            return alerts.Where(a => existItems.All(e => a.GetSearchKey() != e.Search_key));
        }                           
    }
}
