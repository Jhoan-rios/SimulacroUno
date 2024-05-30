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
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [Route("Author")]
        public IEnumerable<Author> GetAuthors(){
            return _authorRepository.GetAll();
        }
        [HttpGet]
        [Route("AuthorInactivo")]
        public IEnumerable<Author> GetAuthorsInactivo(){
            return _authorRepository.GetAllInactivo();
        }

        [HttpGet]
        [Route("Author/{id}")]
        public ActionResult<Author> Details(int id){
            var author = _authorRepository.GetById(id);
            if(author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
    }
}