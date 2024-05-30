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
    public class BookUpdateController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookUpdateController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPut]
        [Route("Book/Update/{id}")]
        public IActionResult Update([FromBody] Book book){
            _bookRepository.Update(book);
            return Ok();
        }
    }
}