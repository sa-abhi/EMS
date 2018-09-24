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
    public class EventBillController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventBill
        public ActionResult Index()
        {
            var eventBills = db.EventBills.Include(e => e.ClientOrder);
            return View(eventBills.ToList());
        }

        // GET: EventBill/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventBill eventBill = db.EventBills.Find(id);
            if (eventBill == null)
            {
                return HttpNotFound();
            }
            return View(eventBill);
        }

        // GET: EventBill/Create
        public ActionResult Create()
        {
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey");
            return View();
        }

        // POST: EventBill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventBillID,ClientOrderID,TotalBill,Discount,Advance,NetBill")] EventBill eventBill)
        {
            if (ModelState.IsValid)
            {
                db.EventBills.Add(eventBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventBill.ClientOrderID);
            return View(eventBill);
        }

        // GET: EventBill/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventBill eventBill = db.EventBills.Find(id);
            if (eventBill == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventBill.ClientOrderID);
            return View(eventBill);
        }

        // POST: EventBill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventBillID,ClientOrderID,TotalBill,Discount,Advance,NetBill")] EventBill eventBill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventBill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventBill.ClientOrderID);
            return View(eventBill);
        }

        // GET: EventBill/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventBill eventBill = db.EventBills.Find(id);
            if (eventBill == null)
            {
                return HttpNotFound();
            }
            return View(eventBill);
        }

        // POST: EventBill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventBill eventBill = db.EventBills.Find(id);
            db.EventBills.Remove(eventBill);
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
