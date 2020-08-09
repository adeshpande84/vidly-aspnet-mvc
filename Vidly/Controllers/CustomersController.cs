using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1" },
                new Customer { Id = 2, Name = "Customer 2" }

            };

            CustomersViewModel customersViewModel = new CustomersViewModel { Customers = customers };

            return View(customersViewModel);
        }

        public ActionResult Details(int id)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1" },
                new Customer { Id = 2, Name = "Customer 2" }

            };

            //Alternate predicate using lambda delegate

            /*
             * Customer matchedCustomer = customers.Find(customer => customer.Id == id);
             *
             */

            Predicate<Customer> findCustomer = delegate (Customer c) { return c.Id == id; };
            
            Customer matchedCustomer = customers.Find(findCustomer);
            
            return View(matchedCustomer);
        }

    }
}