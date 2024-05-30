using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    public class AuthorDeleteController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorDeleteController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpDelete]
        [Route("Author/Delete/{id}")]
        public IActionResult Remove(int id){
            try
            {
                _authorRepository.Remove(id);
                return Ok(new { message = "Book marked as inactive" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("Author/Activar/{id}")]
        public IActionResult Activar(int id){
            try
            {
                _authorRepository.Activar(id);
                return Ok(new { message = "Book marked as inactive" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}