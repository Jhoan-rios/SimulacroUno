using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.Services;
using Library.Models;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("Book")]
        public IEnumerable<Book> GetBooks(){
            return _bookRepository.GetAll();
        }
        [HttpGet]
        [Route("BookInactivo")]
        public IEnumerable<Book> GetBooksInactivo(){
            return _bookRepository.GetAllInactivo();
        }

        [HttpGet]
        [Route("Book/{id}")]
        public ActionResult<Book> Details(int id){
            var book = _bookRepository.GetById(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}