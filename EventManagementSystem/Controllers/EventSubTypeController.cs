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
    public class EventSubTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventSubType
        public ActionResult Index()
        {
            var eventSubTypes = db.EventSubTypes.Include(e => e.EventType);
            return View(eventSubTypes.ToList());
        }

        // GET: EventSubType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventSubType eventSubType = db.EventSubTypes.Find(id);
            if (eventSubType == null)
            {
                return HttpNotFound();
            }
            return View(eventSubType);
        }

        // GET: EventSubType/Create
        public ActionResult Create()
        {
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName");
            return View();
        }

        // POST: EventSubType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventSubTypeID,EventSubTypeName,EventTypeID")] EventSubType eventSubType)
        {
            if (ModelState.IsValid)
            {
                db.EventSubTypes.Add(eventSubType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", eventSubType.EventTypeID);
            return View(eventSubType);
        }

        // GET: EventSubType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventSubType eventSubType = db.EventSubTypes.Find(id);
            if (eventSubType == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", eventSubType.EventTypeID);
            return View(eventSubType);
        }

        // POST: EventSubType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventSubTypeID,EventSubTypeName,EventTypeID")] EventSubType eventSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventSubType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName", eventSubType.EventTypeID);
            return View(eventSubType);
        }

        // GET: EventSubType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventSubType eventSubType = db.EventSubTypes.Find(id);
            if (eventSubType == null)
            {
                return HttpNotFound();
            }
            return View(eventSubType);
        }

        // POST: EventSubType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventSubType eventSubType = db.EventSubTypes.Find(id);
            db.EventSubTypes.Remove(eventSubType);
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
