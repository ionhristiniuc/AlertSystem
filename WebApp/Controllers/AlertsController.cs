using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                return View(model);
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
    }
}