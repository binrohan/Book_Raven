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

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };

            return View("BookForm", viewModel);
        }
        

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(Book book)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel(book)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("BookForm", viewModel);
            }

            if (book.Id == 0)
            {
                book.AddedDate = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.PublisheDate = book.PublisheDate;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel(book)
            {
                Genres = _context.Genres.ToList()
            };

            return View("BookForm", viewModel);
        }


        public ActionResult Index()
        {
            
            if(User.IsInRole(RoleName.CanManageBooks))
                return View("List");

            return View("ReadOnlyList");
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