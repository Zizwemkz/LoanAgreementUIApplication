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
    public class CustomerLoansController : Controller
    {
        private VeriShareApplicationContext db = new VeriShareApplicationContext();

        DumyData GetData = new DumyData();
        // GET: CustomerLoans
        private CustomerLoanService _customerLoanService;
        private CustomerService _customerService;

        public CustomerLoansController()
        {
            this._customerLoanService = new CustomerLoanService();
            this._customerService = new CustomerService();
        }


        // GET: Customers
        public async Task<ActionResult> Index()
        {
            return View(await _customerService.GetAllCustomers());
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

        [HttpGet]
        // GET: CustomerLoans/Create
        public async Task<ActionResult> Create(int? id)
        {
            var FindCustomer = await _customerService.GetAllCustomers();

            var CustomerId = FindCustomer.Find(x => x.CustomerId == id).CustomerId;

            var CustomerLoan = new CustomerLoanViewModel
            {
                CustomerId = Convert.ToInt16(CustomerId)
            };
           ViewBag.AgreementId = new SelectList(await GetData.GetAlltypes(), "AgreementTypeId", "AgreementName");
            return View(CustomerLoan);
        }

        // POST: CustomerLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerLoanViewModel customerLoan,int? AgreementId)
        {

            var findpar = await GetData.GetAlltypes();
            int AgreementTypeId = findpar.Find(x => x.AgreementTypeId == AgreementId).AgreementTypeId;
            if (ModelState.IsValid)
            {
                if (customerLoan != null)
                {
                    var putcustomer = await _customerLoanService.AddCustomerLoan(customerLoan.StartDate.ToShortDateString(), customerLoan.EndDate.ToShortDateString(), customerLoan.RepoRate, AgreementTypeId,Convert.ToDouble(customerLoan.Amount));
                }
            }
            ViewBag.AgreementId = new SelectList(await GetData.GetAlltypes(), "AgreementTypeId", "AgreementName", AgreementId);
            return View(customerLoan);
        }

        // GET: CustomerLoans/Create
        public async Task<ActionResult> CalcLoan()
        {
            ViewBag.AgreementId = new SelectList(await GetData.GetAlltypes(), "AgreementTypeId", "AgreementName");
            return View();
        }

        // POST: CustomerLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CalcLoan(CustomerLoanViewModel Model)
        {
            if (ModelState.IsValid)
            {
                if (Model != null)
                {
                    var putcustomer = await _customerLoanService.AddCustomerLoan(Model.StartDate.ToShortDateString(), Model.EndDate.ToShortDateString(), Model.RepoRate, Model.AgreementTypeId, Convert.ToDouble(Model.Amount));
                }
            }
            var findpar = await GetData.GetAlltypes();
            int AgreementId = findpar.Select(x => x.AgreementTypeId).FirstOrDefault();
            ViewBag.AgreementId = new SelectList(await GetData.GetAlltypes(), "AgreementTypeId", "AgreementName", AgreementId);

            return View(Model);
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
