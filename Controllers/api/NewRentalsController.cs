using Book_Raven.Dtos;
using Book_Raven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Book_Raven.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;


        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.BookIds.Count == 0)
                return BadRequest("No books have been given.");

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            //// Add this validation if Single or Default method is used
            if (customer == null)
                return BadRequest("Customer not found.");

            var books = _context.Books.Where(b => newRental.BookIds.Contains(b.Id)).ToList();

            if (books.Count != newRental.BookIds.Count)
                return BadRequest("One or more books are not found.");

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    BadRequest(book.Name + "(" + book.Id + ") is not available." );

                book.NumberAvailable --;

                var rental = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };
                
                
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            
            return Ok();
        }
    }
}