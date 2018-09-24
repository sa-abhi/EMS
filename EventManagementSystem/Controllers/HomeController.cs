using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Service()
        {
            ViewBag.Message = "Your Service page.";

            return View();
        }

        public ActionResult BirthDay()
        {
            ViewBag.Message = "Birth Day page.";

            return View();
        }
        public ActionResult Wedding()
        {
            ViewBag.Message = " Wedding page.";

            return View();
        }
        public ActionResult Corporate()
        {
            ViewBag.Message = " Corporate page.";

            return View();
        }
    }
}