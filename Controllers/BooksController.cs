using Book_Raven.Models;
using Book_Raven.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Raven.Controllers
{
    public class BooksController : Controller
    {
        // GET: Movies

        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Random()
        {
            var book = new Book() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RamdomBookViewModel
            {
                Book = book,
                Customers = customers
            };

            return View(viewModel);

            //return View(book);
            //Or
            //ViewData["Book"] = book;
            
            //return View();
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult Index()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();

            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Genre).FirstOrDefault(b => b.Id == id);

            return View(book);
        }
    
        [Route("books/published/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByPublishedDate(int year, byte month)
        {
            return Content(year + " / " + month);
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Name = "Himu" },
                new Book { Id = 2, Name = "Fifty Shades of Gray"}
            };
        }
    }
}