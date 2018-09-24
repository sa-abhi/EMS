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
    public class EventsCateringController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventsCatering
        public ActionResult Index()
        {
            var eventsCaterings = db.EventsCaterings.Include(e => e.ClientOrder);
            return View(eventsCaterings.ToList());
        }

        // GET: EventsCatering/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsCatering eventsCatering = db.EventsCaterings.Find(id);
            if (eventsCatering == null)
            {
                return HttpNotFound();
            }
            return View(eventsCatering);
        }

        // GET: EventsCatering/Create
        public ActionResult Create()
        {
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey");
            return View();
        }

        // POST: EventsCatering/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventsCateringID,ClientOrderID,MealType,FoodItems,PerPersonCost,TotalCost")] EventsCatering eventsCatering)
        {
            if (ModelState.IsValid)
            {
                db.EventsCaterings.Add(eventsCatering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsCatering.ClientOrderID);
            return View(eventsCatering);
        }

        // GET: EventsCatering/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsCatering eventsCatering = db.EventsCaterings.Find(id);
            if (eventsCatering == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsCatering.ClientOrderID);
            return View(eventsCatering);
        }

        // POST: EventsCatering/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventsCateringID,ClientOrderID,MealType,FoodItems,PerPersonCost,TotalCost")] EventsCatering eventsCatering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsCatering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsCatering.ClientOrderID);
            return View(eventsCatering);
        }

        // GET: EventsCatering/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsCatering eventsCatering = db.EventsCaterings.Find(id);
            if (eventsCatering == null)
            {
                return HttpNotFound();
            }
            return View(eventsCatering);
        }

        // POST: EventsCatering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsCatering eventsCatering = db.EventsCaterings.Find(id);
            db.EventsCaterings.Remove(eventsCatering);
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
