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
    public class AuthorUpdateController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorUpdateController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpPut]
        [Route("Author/Update/{id}")]
        public IActionResult Update([FromBody] Author author){
            _authorRepository.Update(author);
            return Ok();
        }

    }
}