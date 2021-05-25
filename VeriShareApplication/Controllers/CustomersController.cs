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
    public class CustomersController : Controller
    {
        private VeriShareApplicationContext db = new VeriShareApplicationContext();
       public DumyData GetData = new DumyData();

        private CustomerService _CustomerService;

        public CustomersController()
        {
            this._CustomerService = new CustomerService();
        }


        // GET: Customers
        public async Task<ActionResult> Index()
        {
            return View(await _CustomerService.GetAllCustomers());
           
        }

       
        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                if (customer != null)
                {
                    var putcustomer = await _CustomerService.AddCustomer(customer);
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
