using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    public class AuthorCreateController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorCreateController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpPost]
        [Route("Author/Create")]
        public IActionResult Create([FromBody] Author author)
        {
            _authorRepository.Add(author);
            return Ok();
        }
    }
}