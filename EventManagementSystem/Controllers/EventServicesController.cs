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
    public class EventServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventServices
        public ActionResult Index()
        {
            var eventServicess = db.EventServicess.Include(e => e.ClientOrder).Include(e => e.Service).Include(e => e.ServiceProvider);
            return View(eventServicess.ToList());
        }

        // GET: EventServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventServices eventServices = db.EventServicess.Find(id);
            if (eventServices == null)
            {
                return HttpNotFound();
            }
            return View(eventServices);
        }

        // GET: EventServices/Create
        public ActionResult Create()
        {
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName");
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName");
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderKey");
            return View();
        }

        // POST: EventServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventServicesID,ClientOrderID,ServiceID,ServiceProviderID,Price,Cost")] EventServices eventServices)
        {
            if (ModelState.IsValid)
            {
                db.EventServicess.Add(eventServices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName", eventServices.ClientOrderID);
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName", eventServices.ServiceID);
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderKey", eventServices.ServiceProviderID);
            return View(eventServices);
        }

        // GET: EventServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventServices eventServices = db.EventServicess.Find(id);
            if (eventServices == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName", eventServices.ClientOrderID);
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName", eventServices.ServiceID);
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderKey", eventServices.ServiceProviderID);
            return View(eventServices);
        }

        // POST: EventServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventServicesID,ClientOrderID,ServiceID,ServiceProviderID,Price,Cost")] EventServices eventServices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventServices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName", eventServices.ClientOrderID);
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName", eventServices.ServiceID);
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderKey", eventServices.ServiceProviderID);
            return View(eventServices);
        }

        // GET: EventServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventServices eventServices = db.EventServicess.Find(id);
            if (eventServices == null)
            {
                return HttpNotFound();
            }
            return View(eventServices);
        }

        // POST: EventServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventServices eventServices = db.EventServicess.Find(id);
            db.EventServicess.Remove(eventServices);
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
