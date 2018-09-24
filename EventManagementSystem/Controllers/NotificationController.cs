using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagementSystem.Models;

using System.Data.Entity;

namespace EventManagementSystem.Controllers
{
    public class NotificationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Notification
        public ActionResult Index()
        {
            List<EventRequest> request = db.EventRequests.Where(er => er.isSeen == true).ToList();
            return View(request);
        }

        public JsonResult HideSeenNotification(int eventId)
        {
            var seenFalseList = db.EventRequests.FirstOrDefault(e => e.EventRequestID == eventId);
            if (seenFalseList != null)
            {
                seenFalseList.isSeen = true;
                db.Entry(seenFalseList).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetNotification()
        {
            var notification = from er in db.EventRequests
                               where er.isSeen == false
                               select new { id = er.EventRequestID, name = er.EventName };

            if (notification != null)
            {
                return Json(notification, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult NotificationCount()
        {
            int count = db.EventRequests.Where(e => e.isSeen == false).Count();
            if (count != 0)
            {
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult NotificationDetails(int reqid)
        {
            var notiDetails = (from er in db.EventRequests
                               join ci in db.Cities
                               on er.CityID equals ci.CityID
                               join ar in db.Areas
                               on ci.CityID equals ar.CityID
                               join es in db.EventSubTypes
                               on er.EventSubTypeID equals es.EventSubTypeID
                               join v in db.Venues
                               on er.VenueID equals v.VenueID
                               where er.EventRequestID == reqid
                               select new
                               {
                                   eventname = er.EventName,
                                   city = ci.CityName,
                                   area = ar.AreaName,
                                   eventcategory = es.EventSubTypeName,
                                   venue = v.VenueName,
                                   date = er.EventDate.ToString()
                               }).ToList();

            return Json(notiDetails, JsonRequestBehavior.AllowGet);
        }
    }
}