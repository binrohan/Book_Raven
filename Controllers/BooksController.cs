using Book_Raven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Raven.Controllers
{
    public class BooksController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var book = new Book() { Name = "Shrek!" };
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    
        public ActionResult ByPublishedDate(int year, byte month)
        {
            return Content(year + " / " + month);
        }
    
    }
}