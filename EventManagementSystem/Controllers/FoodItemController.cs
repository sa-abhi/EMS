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
    public class FoodItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FoodItem
        public ActionResult Index()
        {
            var foodItems = db.FoodItems.Include(f => f.FoodCategory);
            ViewBag.MealTypeID = new SelectList(new[] { "Breakfast", "Lunch", "Evening Snacks", "Dinner", "Others" });
            return View(foodItems.ToList());
        }

        // GET: FoodItem/Details/5
        public ActionResult Details(int? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            return View(foodItem);
        }

        // GET: FoodItem/Create
        public ActionResult Create()
        {
            ViewBag.FoodCategoryID = new SelectList(db.FoodCategories, "FoodCategoryID", "Name");
            
            return View();
        }

        // POST: FoodItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodItem foodItem)
        {
            ViewBag.MealType = new SelectList(new[] { "Breakfast", "Lunch", "Evening Snacks", "Dinner", "Others" });

            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileNameWithoutExtension(foodItem.ImageUpload.FileName);
                    var extention = Path.GetExtension(foodItem.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    foodItem.Image = newFilename;
                    foodItem.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.FoodItems.Add(foodItem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodCategoryID = new SelectList(db.FoodCategories, "FoodCategoryID", "Name", foodItem.FoodCategoryID);
            return View(foodItem);
        }

        // GET: FoodItem/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.MealType = new SelectList(new[] { "Breakfast", "Lunch", "Evening Snacks", "Dinner", "Others" });
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodCategoryID = new SelectList(db.FoodCategories, "FoodCategoryID", "Name", foodItem.FoodCategoryID);
            return View(foodItem);
        }

        // POST: FoodItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodItem foodItem)
        {
            ViewBag.MealTypeID = new SelectList(new[] { "Breakfast", "Lunch", "Evening Snacks", "Dinner", "Others" });

            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileNameWithoutExtension(foodItem.ImageUpload.FileName);
                    var extention = Path.GetExtension(foodItem.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    foodItem.Image = newFilename;
                    foodItem.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.Entry(foodItem).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.FoodCategoryID = new SelectList(db.FoodCategories, "FoodCategoryID", "Name", foodItem.FoodCategoryID);
            return View(foodItem);
        }

        // GET: FoodItem/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.MealTypeID = new SelectList(new[] { "Breakfast", "Lunch", "Evening Snacks", "Dinner", "Others" });

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            return View(foodItem);
        }

        // POST: FoodItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodItem foodItem = db.FoodItems.Find(id);
            db.FoodItems.Remove(foodItem);
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
