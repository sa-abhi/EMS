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
    public class ClientFeedbackController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientFeedback
        public ActionResult Index()
        {
            return View(db.ClientFeedback.ToList());
        }

        // GET: ClientFeedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientFeedback clientFeedback = db.ClientFeedback.Find(id);
            if (clientFeedback == null)
            {
                return HttpNotFound();
            }
            return View(clientFeedback);
        }

        // GET: ClientFeedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientFeedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientFeedbackID,Name,Email,FeedbackDate,Message")] ClientFeedback clientFeedback)
        {
            if (ModelState.IsValid)
            {
                db.ClientFeedback.Add(clientFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientFeedback);
        }

        // GET: ClientFeedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientFeedback clientFeedback = db.ClientFeedback.Find(id);
            if (clientFeedback == null)
            {
                return HttpNotFound();
            }
            return View(clientFeedback);
        }

        // POST: ClientFeedback/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientFeedbackID,Name,Email,FeedbackDate,Message")] ClientFeedback clientFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientFeedback);
        }

        // GET: ClientFeedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientFeedback clientFeedback = db.ClientFeedback.Find(id);
            if (clientFeedback == null)
            {
                return HttpNotFound();
            }
            return View(clientFeedback);
        }

        // POST: ClientFeedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientFeedback clientFeedback = db.ClientFeedback.Find(id);
            db.ClientFeedback.Remove(clientFeedback);
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
