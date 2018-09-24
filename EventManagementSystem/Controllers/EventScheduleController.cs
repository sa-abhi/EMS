using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagementSystem.Models;

namespace EventManagementSystem.Controllers
{
    public class EventScheduleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: EventSchedule
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            //var eventList = db.EventSchedules.ToList();
            var eventList = (from es in db.EventSchedules
                             join v in db.Venues
                             on es.VenueID equals v.VenueID
                             select new {
                                 EventName=es.EventName,
                                 EventStartDate=es.EventStartDate,
                                 EventEndDate=es.EventEndDate,
                                 VenueID=es.VenueID,
                                 VenueName=v.VenueName,
                                 Description=es.Description}).ToList();

            return Json(eventList, JsonRequestBehavior.AllowGet);
        }
    }
}