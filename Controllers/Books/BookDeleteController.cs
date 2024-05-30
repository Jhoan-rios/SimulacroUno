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
    public class BookDeleteController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookDeleteController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpDelete]
        [Route("Book/Delete/{id}")]
        public IActionResult Remove(int id){
            try
            {
                _bookRepository.Remove(id);
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
        [Route("Book/Active/{id}")]
        public IActionResult Activar(int id){
            try
            {
                _bookRepository.Activar(id);
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