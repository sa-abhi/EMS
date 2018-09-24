using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventManagementSystem.Controllers
{
    [Authorize]
    public class EventRequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventRequest
        public ActionResult Index()
        {
            var eventRequests = db.EventRequests.Include(e => e.Area).Include(e => e.City).Include(e => e.Client).Include(e => e.EventSubType).Include(e => e.EventType).Include(e => e.Venue);
            return View(eventRequests.ToList());
        }

        // GET: EventRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRequest eventRequest = db.EventRequests.Find(id);
            if (eventRequest == null)
            {
                return HttpNotFound();
            }
            return View(eventRequest);
        }

        // GET: EventRequest/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientKey");
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName");
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: EventRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventRequestID,CityID,AreaID,EventTypeID,EventSubTypeID,EventName,EventDate,VenueID,Duration,NoOfGuest,Budget,Stage,Catering,SoundSystemAndMusic,Decoration,PhotographyAndCinematography,Invitation,SpecialInstruction")] EventRequest eventRequest)
        {
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", eventRequest.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", eventRequest.CityID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Name", eventRequest.ClientID);
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName", eventRequest.EventSubTypeID);
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", eventRequest.EventTypeID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", eventRequest.VenueID);

            var context = new IdentityDbContext();
            var users = context.Users.ToList();
            
            var user = User.Identity.Name;

            var Usercontact = users.Where(m => m.UserName== user).Single();
            var contact = Usercontact.PhoneNumber;
            var clID = db.Clients.Where(c => c.Phone == contact).Select(i=>i.ClientID).FirstOrDefault();

            eventRequest.ClientID = clID;

            if (ModelState.IsValid)
            {
                db.EventRequests.Add(eventRequest);
                db.SaveChanges();
                return RedirectToAction("ThankYou");
            }

            

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            return View(eventRequest);
        }

        // GET: EventRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRequest eventRequest = db.EventRequests.Find(id);
            if (eventRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", eventRequest.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", eventRequest.CityID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientKey", eventRequest.ClientID);
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName", eventRequest.EventSubTypeID);
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", eventRequest.EventTypeID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", eventRequest.VenueID);
            return View(eventRequest);
        }

        // POST: EventRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventRequestID,ClientID,CityID,AreaID,EventTypeID,EventSubTypeID,EventName,EventDate,VenueID,Duration,NoOfGuest,Budget,Stage,Catering,SoundSystemAndMusic,Decoration,PhotographyAndCinematography,Invitation,SpecialInstruction")] EventRequest eventRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", eventRequest.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", eventRequest.CityID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientKey", eventRequest.ClientID);
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName", eventRequest.EventSubTypeID);
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", eventRequest.EventTypeID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", eventRequest.VenueID);
            return View(eventRequest);
        }

        // GET: EventRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRequest eventRequest = db.EventRequests.Find(id);
            if (eventRequest == null)
            {
                return HttpNotFound();
            }
            return View(eventRequest);
        }

        // POST: EventRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventRequest eventRequest = db.EventRequests.Find(id);
            db.EventRequests.Remove(eventRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
