using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{    
    public class HomeController : Controller
    {
        private IUsersRepository _usersRepository;
        private IAlertsRepository _alertRepository;

        public HomeController(IAlertsRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public ActionResult Index()
        {
            //var users = _usersRepository.GetList(u => u.id < 9);
            var alerts = _alertRepository.GetAll();
            
            if (User.Identity.IsAuthenticated)
            {
                var userId = (User.Identity as ClaimsIdentity).Name;
                ViewBag.UserId = userId;
                var unreadAlerts = _alertRepository.GetUnreadAlerts(int.Parse(userId));
                ViewBag.unreadAlertsCount = unreadAlerts.Count();
                ViewBag.alerts = alerts
                    .OrderByDescending(x => x.Notify_time)
                    .Select(x => new AlertModel(x, unreadAlerts.Any(u => u.Id == x.Id))).ToList();

                ViewBag.isAuhtenticated = true;
                ViewBag.evetAlerts = alerts.Where(a => a.Alert_category == "Evenimente").Count();
                ViewBag.serviciiComunaleAlerts = alerts.Where(a => a.Alert_category == "ServiciiComunale").Count();
                ViewBag.meteoAlerts = alerts.Where(a => a.Alert_category == "Meteo").Count();
                ViewBag.transportAlerts = alerts.Where(a => a.Alert_category == "Transport").Count();

            }
            else
            {
                ViewBag.isAuhtenticated = false;
 
                ViewBag.alerts = alerts
                    .OrderByDescending(x => x.Notify_time)
                    .Select(x => new AlertModel(x, true)).ToList();

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}