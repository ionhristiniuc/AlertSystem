using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebApp.Database;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AlertsController : Controller
    {
        private IAlertsRepository _alertsRepository;

        public AlertsController(IAlertsRepository alertsRepository)
        {
            _alertsRepository = alertsRepository;
        }

        // GET: Alerts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAlert(AlertModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["alert"] = model;
                return RedirectToAction("Index","Home");
               
            }

            var alert = new Alert()
            {
                User_id = model.User_id,
                Raiting = 0,
                Address = model.Address,
                Short_text = model.Short_text,
                Text = model.Text,
                Alert_category = model.Category,
                Subject = model.Subject,
                Notify_time = model.Notify_time,                
            };

            _alertsRepository.Add(alert);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]        
        public virtual JsonResult MarkAlertAsRead(int alertId)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity == null)
                    return Json(null, JsonRequestBehavior.DenyGet);

                var userId = int.Parse(claimsIdentity.Name);
                _alertsRepository.MarkAlertAsRead(userId, alertId);

                var pendingAlerts = _alertsRepository.GetUnreadAlerts(userId);
                var result = new
                {
                    totalPendingCount = pendingAlerts.Count(),
                    servComunPendingCount = pendingAlerts.Where(a => a.Alert_category == "ServiciiComunale").Count(),
                    meteoAlerts = pendingAlerts.Where(a => a.Alert_category == "Meteo").Count(),
                    transportAlerts = pendingAlerts.Where(a => a.Alert_category == "Transport").Count(),
                    evetAlerts = pendingAlerts.Where(a => a.Alert_category == "Evenimente").Count()
                };              
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }
    }
}