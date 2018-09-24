using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventManagementSystem.Models;

namespace EventManagementSystem.Controllers
{
    public class EventPaymentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventPayment
        public ActionResult Index()
        {
            var eventPayments = db.EventPayments.Include(e => e.ClientOrder);
            return View(eventPayments.ToList());
        }

        // GET: EventPayment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventPayment eventPayment = db.EventPayments.Find(id);
            if (eventPayment == null)
            {
                return HttpNotFound();
            }
            return View(eventPayment);
        }


    }
}
