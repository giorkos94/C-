using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Csharp.Models;
namespace Csharp
{
    public class CustomerController : Controller
    {
        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();
        // GET: /<controller>/  
        public IActionResult Index()
        {
            List<Customer> lstCustomer = new List<Customer>();           
            return View(lstCustomer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer customer)
        {
            if (ModelState.IsValid)
            {
                // objcustomer.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }


}