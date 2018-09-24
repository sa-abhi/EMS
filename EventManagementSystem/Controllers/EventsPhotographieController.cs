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
    public class EventsPhotographieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventsPhotographie
        public ActionResult Index()
        {
            var eventsPhotographies = db.EventsPhotographies.Include(e => e.ClientOrder);
            return View(eventsPhotographies.ToList());
        }

        // GET: EventsPhotographie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsPhotography eventsPhotography = db.EventsPhotographies.Find(id);
            if (eventsPhotography == null)
            {
                return HttpNotFound();
            }
            return View(eventsPhotography);
        }

        // GET: EventsPhotographie/Create
        public ActionResult Create()
        {
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey");
            return View();
        }

        // POST: EventsPhotographie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventsPhotographyID,ClientOrderID,Category,NumberOfTeam,Price")] EventsPhotography eventsPhotography)
        {
            if (ModelState.IsValid)
            {
                db.EventsPhotographies.Add(eventsPhotography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsPhotography.ClientOrderID);
            return View(eventsPhotography);
        }

        // GET: EventsPhotographie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsPhotography eventsPhotography = db.EventsPhotographies.Find(id);
            if (eventsPhotography == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsPhotography.ClientOrderID);
            return View(eventsPhotography);
        }

        // POST: EventsPhotographie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventsPhotographyID,ClientOrderID,Category,NumberOfTeam,Price")] EventsPhotography eventsPhotography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsPhotography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsPhotography.ClientOrderID);
            return View(eventsPhotography);
        }

        // GET: EventsPhotographie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsPhotography eventsPhotography = db.EventsPhotographies.Find(id);
            if (eventsPhotography == null)
            {
                return HttpNotFound();
            }
            return View(eventsPhotography);
        }

        // POST: EventsPhotographie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsPhotography eventsPhotography = db.EventsPhotographies.Find(id);
            db.EventsPhotographies.Remove(eventsPhotography);
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
