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
    public class InvoiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoice
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.ClientOrder);
            return View(invoices.ToList());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName");
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceID,InvoiceKey,ClientOrderID,PaymentType,PaidAmount,MadeBy,Date,Notes")] Invoice invoice)
        {
            ViewBag.ClientOrderList = new SelectList(db.ClientOrders, "ClientOrderID", "ClientOrderID");

            var lastInvKey = db.Invoices.OrderByDescending(e => e.InvoiceKey).FirstOrDefault();
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.Month.ToString("d2");
            if (lastInvKey == null)
            {
                invoice.InvoiceKey = "INV" + year + month + "00001";
            }
            else
            {
                invoice.InvoiceKey = "INV" + year + month + (Convert.ToInt32(lastInvKey.InvoiceKey.Substring(7, lastInvKey.InvoiceKey.Length - 7)) + 1).ToString("D5");
            }

            if (ModelState.IsValid)
            {
                var EvPay = db.EventPayments.Where(coi => coi.ClientOrderID == invoice.ClientOrderID).FirstOrDefault();
                var paidAmm = db.EventPayments.Where(coi => coi.ClientOrderID == invoice.ClientOrderID).Select(s => s.PaidAmount).Single();
                EvPay.PaidAmount = paidAmm + invoice.PaidAmount;
                if (EvPay.Total == (paidAmm + invoice.PaidAmount))
                {
                    EvPay.PaymentStatus = true;
                }
                else
                {
                    EvPay.PaymentStatus = false;
                }
                db.Entry(EvPay).State = EntityState.Modified;

                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName", invoice.ClientOrderID);
            return View(invoice);
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName", invoice.ClientOrderID);
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,InvoiceKey,ClientOrderID,PaymentType,PaidAmount,MadeBy,Date,Notes")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientOrderID = new SelectList(db.ClientOrders, "ClientOrderID", "EventName", invoice.ClientOrderID);
            return View(invoice);
        }

        public JsonResult GetOrderInfo(int coid)
        {
            var info = db.EventPayments.Where(s => s.ClientOrderID == coid).Select(a=>new { TotalBill=a.Total, DueAmmount =(a.Total- a.PaidAmount)}).FirstOrDefault();
            return Json(info, JsonRequestBehavior.AllowGet);
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
