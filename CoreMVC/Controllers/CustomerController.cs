using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVC.DAL;
using CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccess_Layer cds = new CustomerDataAccess_Layer();

        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            customers = cds.GetAllCustomer().ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer cus)
        {
            if(ModelState.IsValid)
            {
                cds.AddCustomer(cus);
                return RedirectToAction("Index");
            }
            return View(cus);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Customer customer = cds.GetCustomerData(id);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind]Customer customer)
        {
            if(id !=customer.ID)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                cds.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}