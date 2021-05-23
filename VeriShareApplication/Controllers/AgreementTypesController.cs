using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VeriShareApplication.Models;

namespace VeriShareApplication.Controllers
{
    public class AgreementTypesController : Controller
    {
        private VeriShareApplicationContext db = new VeriShareApplicationContext();
        public  DumyData GetData = new DumyData();
        // GET: AgreementTypes
        public async Task<ActionResult> Index()
        {
            return View(await GetData.GetAlltypes());
        }

        // GET: AgreementTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgreementType agreementType = db.AgreementTypes.Find(id);
            if (agreementType == null)
            {
                return HttpNotFound();
            }
            return View(agreementType);
        }

        // GET: AgreementTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgreementTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgreementTypeId,AgreementName")] AgreementType agreementType)
        {
            if (ModelState.IsValid)
            {
                db.AgreementTypes.Add(agreementType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agreementType);
        }

        // GET: AgreementTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgreementType agreementType = db.AgreementTypes.Find(id);
            if (agreementType == null)
            {
                return HttpNotFound();
            }
            return View(agreementType);
        }

        // POST: AgreementTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgreementTypeId,AgreementName")] AgreementType agreementType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agreementType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agreementType);
        }

        // GET: AgreementTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgreementType agreementType = db.AgreementTypes.Find(id);
            if (agreementType == null)
            {
                return HttpNotFound();
            }
            return View(agreementType);
        }

        // POST: AgreementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgreementType agreementType = db.AgreementTypes.Find(id);
            db.AgreementTypes.Remove(agreementType);
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
