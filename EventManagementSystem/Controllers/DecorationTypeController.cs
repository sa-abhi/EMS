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
    public class DecorationTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DecorationType
        public ActionResult Index()
        {
            return View(db.DecorationTypes.ToList());
        }

        // GET: DecorationType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecorationType decorationType = db.DecorationTypes.Find(id);
            if (decorationType == null)
            {
                return HttpNotFound();
            }
            return View(decorationType);
        }

        // GET: DecorationType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DecorationType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DecorationTypeID,Name")] DecorationType decorationType)
        {
            if (ModelState.IsValid)
            {
                db.DecorationTypes.Add(decorationType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(decorationType);
        }

        // GET: DecorationType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecorationType decorationType = db.DecorationTypes.Find(id);
            if (decorationType == null)
            {
                return HttpNotFound();
            }
            return View(decorationType);
        }

        // POST: DecorationType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DecorationTypeID,Name")] DecorationType decorationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decorationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(decorationType);
        }

        // GET: DecorationType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecorationType decorationType = db.DecorationTypes.Find(id);
            if (decorationType == null)
            {
                return HttpNotFound();
            }
            return View(decorationType);
        }

        // POST: DecorationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DecorationType decorationType = db.DecorationTypes.Find(id);
            db.DecorationTypes.Remove(decorationType);
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
