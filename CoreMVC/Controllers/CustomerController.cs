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
    }
}