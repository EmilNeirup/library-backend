using libraryAPI.Models;
using libraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace libraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get() =>
            _bookService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPut]
        public ActionResult<Book> Create(Book book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, bool InStock, string BorrowerId, string BorrowerName, string BorrowerStartDate, string BorrowerEndDate)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            
            Borrower newBorrower = new Borrower();
            newBorrower.Id = BorrowerId;
            newBorrower.Name = BorrowerName;
            newBorrower.StartDate = BorrowerStartDate;
            newBorrower.EndDate = BorrowerEndDate;

            book.BorrowerList.Add(newBorrower);
            book.InStock = InStock;

            _bookService.Update(book);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}