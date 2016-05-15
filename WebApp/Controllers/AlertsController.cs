using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public virtual JsonResult MarkAlertAsRead(int userId, int alertId)
        {
            try
            {
                _alertsRepository.MarkAlertAsRead(userId, alertId);
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
    }
}