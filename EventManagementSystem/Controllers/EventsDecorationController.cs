using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventManagementSystem.Models;
using System.IO;

namespace EventManagementSystem.Controllers
{
    public class EventsDecorationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventsDecoration
        public ActionResult Index()
        {
            var eventsDecorations = db.EventsDecorations.Include(e => e.ClientOrder).Include(e => e.DecorationImage).Include(e => e.DecorationType);
            return View(eventsDecorations.ToList());
        }

        // GET: EventsDecoration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsDecoration eventsDecoration = db.EventsDecorations.Find(id);
            if (eventsDecoration == null)
            {
                return HttpNotFound();
            }
            return View(eventsDecoration);
        }

        // GET: EventsDecoration/Create
        public ActionResult Create()
        {
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey");
            ViewBag.DecorationImageID = new SelectList(db.DecorationImages, "DecorationImageID", "Image");
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name");
            return View();
        }

        // POST: EventsDecoration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventsDecoration eventsDecoration)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileNameWithoutExtension(eventsDecoration.ImageUpload.FileName);
                    var extention = Path.GetExtension(eventsDecoration.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    eventsDecoration.CustomImage = newFilename;
                    eventsDecoration.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.EventsDecorations.Add(eventsDecoration);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsDecoration.ClientOrderID);
            ViewBag.DecorationImageID = new SelectList(db.DecorationImages, "DecorationImageID", "Image", eventsDecoration.DecorationImageID);
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name", eventsDecoration.DecorationTypeID);
            return View(eventsDecoration);
        }

        // GET: EventsDecoration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsDecoration eventsDecoration = db.EventsDecorations.Find(id);
            if (eventsDecoration == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsDecoration.ClientOrderID);
            ViewBag.DecorationImageID = new SelectList(db.DecorationImages, "DecorationImageID", "Image", eventsDecoration.DecorationImageID);
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name", eventsDecoration.DecorationTypeID);
            return View(eventsDecoration);
        }

        // POST: EventsDecoration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventsDecoration eventsDecoration)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileNameWithoutExtension(eventsDecoration.ImageUpload.FileName);
                    var extention = Path.GetExtension(eventsDecoration.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    eventsDecoration.CustomImage = newFilename;
                    eventsDecoration.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.Entry(eventsDecoration).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderKey", eventsDecoration.ClientOrderID);
            ViewBag.DecorationImageID = new SelectList(db.DecorationImages, "DecorationImageID", "Image", eventsDecoration.DecorationImageID);
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name", eventsDecoration.DecorationTypeID);
            return View(eventsDecoration);
        }

        // GET: EventsDecoration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsDecoration eventsDecoration = db.EventsDecorations.Find(id);
            if (eventsDecoration == null)
            {
                return HttpNotFound();
            }
            return View(eventsDecoration);
        }

        // POST: EventsDecoration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsDecoration eventsDecoration = db.EventsDecorations.Find(id);
            db.EventsDecorations.Remove(eventsDecoration);
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
