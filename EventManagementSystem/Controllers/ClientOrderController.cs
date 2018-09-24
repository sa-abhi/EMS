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
    public class ClientOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientOrder
        public ActionResult Index()
        {
            var clientOrders = db.ClientOrders.Include(c => c.City).Include(c => c.Client).Include(c => c.EventSubType).Include(c => c.EventType).Include(c => c.Venue);
            return View(clientOrders.ToList());
        }

        // GET: ClientOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientOrder clientOrder = db.ClientOrders.Find(id);
            if (clientOrder == null)
            {
                return HttpNotFound();
            }
            return View(clientOrder);
        }

        // GET: ClientOrder/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientKey");
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName");
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: ClientOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientOrderID,ClientID,CityID,EventTypeID,EventSubTypeID,EventName,EventStartDate,EventEndDate,Date,VenueID,NoOfGuest,SpecialInstruction")] ClientOrder clientOrder)
        {
            if (ModelState.IsValid)
            {
                db.ClientOrders.Add(clientOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", clientOrder.CityID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientKey", clientOrder.ClientID);
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName", clientOrder.EventSubTypeID);
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", clientOrder.EventTypeID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", clientOrder.VenueID);
            return View(clientOrder);
        }

        // GET: ClientOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientOrder clientOrder = db.ClientOrders.Find(id);
            if (clientOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", clientOrder.CityID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientKey", clientOrder.ClientID);
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName", clientOrder.EventSubTypeID);
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", clientOrder.EventTypeID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", clientOrder.VenueID);
            return View(clientOrder);
        }

        // POST: ClientOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientOrderID,ClientID,CityID,EventTypeID,EventSubTypeID,EventName,EventStartDate,EventEndDate,Date,VenueID,NoOfGuest,SpecialInstruction")] ClientOrder clientOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", clientOrder.CityID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientKey", clientOrder.ClientID);
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName", clientOrder.EventSubTypeID);
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", clientOrder.EventTypeID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", clientOrder.VenueID);
            return View(clientOrder);
        }

        // GET: ClientOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientOrder clientOrder = db.ClientOrders.Find(id);
            if (clientOrder == null)
            {
                return HttpNotFound();
            }
            return View(clientOrder);
        }

        // POST: ClientOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientOrder clientOrder = db.ClientOrders.Find(id);
            db.ClientOrders.Remove(clientOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
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
