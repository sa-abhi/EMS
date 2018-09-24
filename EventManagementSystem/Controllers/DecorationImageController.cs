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
    public class DecorationImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DecorationImage
        public ActionResult Index()
        {
            var decorationImages = db.DecorationImages.Include(d => d.DecorationType);
            return View(decorationImages.ToList());
        }

        // GET: DecorationImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecorationImage decorationImage = db.DecorationImages.Find(id);
            if (decorationImage == null)
            {
                return HttpNotFound();
            }
            return View(decorationImage);
        }

        // GET: DecorationImage/Create
        public ActionResult Create()
        {
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name");
            return View();
        }

        // POST: DecorationImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DecorationImage decorationImage)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileNameWithoutExtension(decorationImage.ImageUpload.FileName);
                    var extention = Path.GetExtension(decorationImage.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    decorationImage.Image = newFilename;
                    decorationImage.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.DecorationImages.Add(decorationImage);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name", decorationImage.DecorationTypeID);
            return View(decorationImage);
        }

        // GET: DecorationImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecorationImage decorationImage = db.DecorationImages.Find(id);
            if (decorationImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name", decorationImage.DecorationTypeID);
            return View(decorationImage);
        }

        // POST: DecorationImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DecorationImage decorationImage)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileNameWithoutExtension(decorationImage.ImageUpload.FileName);
                    var extention = Path.GetExtension(decorationImage.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    decorationImage.Image = newFilename;
                    decorationImage.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.Entry(decorationImage).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name", decorationImage.DecorationTypeID);
            return View(decorationImage);
        }
        

        // GET: DecorationImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecorationImage decorationImage = db.DecorationImages.Find(id);
            if (decorationImage == null)
            {
                return HttpNotFound();
            }
            return View(decorationImage);
        }

        // POST: DecorationImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DecorationImage decorationImage = db.DecorationImages.Find(id);
            db.DecorationImages.Remove(decorationImage);
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
