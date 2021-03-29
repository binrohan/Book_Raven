using AutoMapper;
using Book_Raven.Dtos;
using Book_Raven.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Book_Raven.Controllers.api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetBooks()
        {
            return Ok(_context.Books.Include(b => b.Genre).ToList().Select(Mapper.Map<Book, BookDto>));
        }

        [HttpGet]
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        [HttpPost]
        public IHttpActionResult AddBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var book = Mapper.Map<BookDto, Book>(bookDto);

            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + bookDto.Id), bookDto);
        }

        [HttpPut]
        public IHttpActionResult EditBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null)
                return NotFound();

            Mapper.Map<BookDto, Book>(bookDto, bookInDb);

            _context.SaveChanges();

            return Ok(bookDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
