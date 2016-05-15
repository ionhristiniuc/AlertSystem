using System;
using System.Collections.Generic;
using System.Linq;
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
            var unreadAlerts = _alertRepository.GetUnreadAlerts(int.Parse(User.Identity.Name));
            ViewBag.unreadAlertsCount = unreadAlerts.Count();
            ViewBag.alerts = alerts
                .OrderByDescending(x => x.Notify_time).Take(10)
                .Select(x => new AlertModel(x, unreadAlerts.Any(u => u.Id == x.Id))).ToList();

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