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

        private IEnumerable<Customer> getCustomers()
        {
            IEnumerable<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1" },
                new Customer { Id = 2, Name = "Customer 2" }

            };

            return customers;
        }

        // GET: Customers
        public ActionResult Index()
        {

            IEnumerable<Customer> customers = getCustomers();

            CustomersViewModel customersViewModel = new CustomersViewModel { Customers = customers };

            return View(customersViewModel);
        }

        public ActionResult Details(int id)
        {
            IEnumerable<Customer> customers = getCustomers();

            //Alternate predicate using lambda delegate

            /*
             * Customer matchedCustomer = customers.SingleOrDefault(customer => customer.Id == id);
             *
             */

            Predicate<Customer> findCustomer = delegate (Customer c) { return c.Id == id; };
            
            Customer matchedCustomer = customers.ToList().Find(findCustomer);
            
            return View(matchedCustomer);
        }

    }
}