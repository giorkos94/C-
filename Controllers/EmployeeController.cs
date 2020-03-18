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
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objcustomer = new EmployeeDataAccessLayer();
        // GET: /<controller>/  
        public IActionResult Index()
        {
            List<Customer> lstCustomer = new List<Customer>();
            lstCustomer = objcustomer.GetAllCustomer().ToList();
            return View(lstCustomer);
        }

        [HttpGet]
       public IActionResult AddCalls(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = objcustomer.GetCustomerData(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCalls(int id, [Bind]Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objcustomer.AddCalls(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = objcustomer.GetCustomerData(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objcustomer.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = objcustomer.GetCustomerData(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = objcustomer.GetCustomerData(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objcustomer.DeleteCustomerCalls(id);
            return RedirectToAction("Index");
        }
    }

}