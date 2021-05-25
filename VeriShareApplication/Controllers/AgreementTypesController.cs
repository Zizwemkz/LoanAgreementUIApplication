using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VeriShareApplication.Logic;
using VeriShareApplication.Models;

namespace VeriShareApplication.Controllers
{
    public class AgreementTypesController : Controller
    {
        private VeriShareApplicationContext db = new VeriShareApplicationContext();
      
        private AgreementTypeService _greementTypeService;

        public AgreementTypesController()
        {
            this._greementTypeService = new AgreementTypeService();
        }


        // GET: AgreementTypes
        public async Task<ActionResult> Index()
        {
            return View(await _greementTypeService.GetAllAgreementTypes());
        }

       
        // GET: AgreementTypes/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AgreementTypeViewModel model)
        {
            if (ModelState.IsValid)
            {   if (model != null){
                var putcustomer = await _greementTypeService.AddAgreementType(model);
                return RedirectToAction("Index");
            }
        }
             return RedirectToAction("Not_Found", "Error");
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
