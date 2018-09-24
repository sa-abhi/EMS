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
    public class VenueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Venue
        public ActionResult Index()
        {
            var venues = db.Venues.Include(v => v.Area).Include(v => v.City);
            return View(venues.ToList());
        }

        // GET: Venue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // GET: Venue/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            return View();
        }

        // POST: Venue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileNameWithoutExtension(venue.ImageUpload.FileName);
                    var extention = Path.GetExtension(venue.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    venue.Image = newFilename;
                    venue.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.Venues.Add(venue);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", venue.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", venue.CityID);
            return View(venue);
        }

        // GET: Venue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", venue.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", venue.CityID);
            return View(venue);
        }

        // POST: Venue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileNameWithoutExtension(venue.ImageUpload.FileName);
                    var extention = Path.GetExtension(venue.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    venue.Image = newFilename;
                    venue.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.Entry(venue).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", venue.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", venue.CityID);
            return View(venue);
        }

        // GET: Venue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: Venue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venue venue = db.Venues.Find(id);
            db.Venues.Remove(venue);
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
