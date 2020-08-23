using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private IEnumerable<Customer> getCustomers()
        {
            IEnumerable<Customer> customers = _context.Customer.Include(c => c.MembershipType);

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