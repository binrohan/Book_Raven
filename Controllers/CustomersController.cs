using Book_Raven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Raven.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        
        public ActionResult Index()
        {
            var customers = GetCustomers();


            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Bruce Wayne" },
                new Customer { Id = 2, Name = "Cark Kent" }
            };
        }
    }
}