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
    public class EventsCinematographieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventsCinematographie
        public ActionResult Index()
        {
            var eventsCinematographies = db.EventsCinematographies.Include(e => e.ClientOrders);
            return View(eventsCinematographies.ToList());
        }

        // GET: EventsCinematographie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsCinematography eventsCinematography = db.EventsCinematographies.Find(id);
            if (eventsCinematography == null)
            {
                return HttpNotFound();
            }
            return View(eventsCinematography);
        }

        // GET: EventsCinematographie/Create
        public ActionResult Create()
        {
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey");
            return View();
        }

        // POST: EventsCinematographie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventscinematographyID,ClientOrderID,NumberOfTeaM,Price")] EventsCinematography eventsCinematography)
        {
            if (ModelState.IsValid)
            {
                db.EventsCinematographies.Add(eventsCinematography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsCinematography.ClientOrderID);
            return View(eventsCinematography);
        }

        // GET: EventsCinematographie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsCinematography eventsCinematography = db.EventsCinematographies.Find(id);
            if (eventsCinematography == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsCinematography.ClientOrderID);
            return View(eventsCinematography);
        }

        // POST: EventsCinematographie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventscinematographyID,ClientOrderID,NumberOfTeaM,Price")] EventsCinematography eventsCinematography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsCinematography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsCinematography.ClientOrderID);
            return View(eventsCinematography);
        }

        // GET: EventsCinematographie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsCinematography eventsCinematography = db.EventsCinematographies.Find(id);
            if (eventsCinematography == null)
            {
                return HttpNotFound();
            }
            return View(eventsCinematography);
        }

        // POST: EventsCinematographie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsCinematography eventsCinematography = db.EventsCinematographies.Find(id);
            db.EventsCinematographies.Remove(eventsCinematography);
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
