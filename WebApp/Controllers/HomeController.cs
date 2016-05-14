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
            ViewBag.alerts = alerts.Select(x => new AlertModel(x)).ToList();

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