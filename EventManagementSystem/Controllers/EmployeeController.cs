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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Designation);
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {

                var lastEmpID = db.Employees.OrderByDescending(e => e.EmployeeKey).FirstOrDefault();
                string year = DateTime.Now.ToString("yy");
                string month = DateTime.Now.Month.ToString();
                if (lastEmpID == null)
                {
                    employee.EmployeeKey = "EMP" + year+month + "00001";
                }
                else
                {
                    employee.EmployeeKey = "Cl" + year + (Convert.ToInt32(employee.EmployeeKey.Substring(7, employee.EmployeeKey.Length - 7)) + 1).ToString("D5");
                }


                var fileName = Path.GetFileNameWithoutExtension(employee.ImageUpload.FileName);
                    var extention = Path.GetExtension(employee.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    employee.Image = newFilename;
                    employee.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }

            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName", employee.DesignationID);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName", employee.DesignationID);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileNameWithoutExtension(employee.ImageUpload.FileName);
                    var extention = Path.GetExtension(employee.ImageUpload.FileName);
                    var newFilename = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extention;
                    employee.Image = newFilename;
                    employee.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), newFilename));

                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName", employee.DesignationID);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
