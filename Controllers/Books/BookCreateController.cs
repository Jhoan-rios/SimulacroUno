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
    public class BookCreateController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookCreateController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpPost]
        [Route("Book/Create")]
        public IActionResult Create([FromBody] Book book)
        {
            _bookRepository.Add(book);
            return Ok();
        }
    }
}