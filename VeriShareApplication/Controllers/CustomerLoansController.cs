using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeriShareApplication.Models;

namespace VeriShareApplication.Controllers
{
    public class CustomerLoansController : Controller
    {
        private VeriShareApplicationContext db = new VeriShareApplicationContext();

        // GET: CustomerLoans
        public ActionResult Index()
        {
            var customerLoans = db.CustomerLoans.Include(c => c.AgreementType).Include(c => c.Customer);
            return View(customerLoans.ToList());
        }

        // GET: CustomerLoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLoan customerLoan = db.CustomerLoans.Find(id);
            if (customerLoan == null)
            {
                return HttpNotFound();
            }
            return View(customerLoan);
        }

        // GET: CustomerLoans/Create
        public ActionResult Create()
        {
            ViewBag.AgreementId = new SelectList(db.AgreementTypes, "AgreementTypeId", "AgreementName");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName");
            return View();
        }

        // POST: CustomerLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanId,CustomerId,AgreementId,Amount,ReturnInterest,RepoRate,StatusCode,TransectionMessage,Agreementpicked,StartDate,EndDate")] CustomerLoan customerLoan)
        {
            if (ModelState.IsValid)
            {
                db.CustomerLoans.Add(customerLoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgreementId = new SelectList(db.AgreementTypes, "AgreementTypeId", "AgreementName", customerLoan.AgreementId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", customerLoan.CustomerId);
            return View(customerLoan);
        }

        // GET: CustomerLoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLoan customerLoan = db.CustomerLoans.Find(id);
            if (customerLoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgreementId = new SelectList(db.AgreementTypes, "AgreementTypeId", "AgreementName", customerLoan.AgreementId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", customerLoan.CustomerId);
            return View(customerLoan);
        }

        // POST: CustomerLoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanId,CustomerId,AgreementId,Amount,ReturnInterest,RepoRate,StatusCode,TransectionMessage,Agreementpicked,StartDate,EndDate")] CustomerLoan customerLoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerLoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgreementId = new SelectList(db.AgreementTypes, "AgreementTypeId", "AgreementName", customerLoan.AgreementId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", customerLoan.CustomerId);
            return View(customerLoan);
        }

        // GET: CustomerLoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLoan customerLoan = db.CustomerLoans.Find(id);
            if (customerLoan == null)
            {
                return HttpNotFound();
            }
            return View(customerLoan);
        }

        // POST: CustomerLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerLoan customerLoan = db.CustomerLoans.Find(id);
            db.CustomerLoans.Remove(customerLoan);
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
