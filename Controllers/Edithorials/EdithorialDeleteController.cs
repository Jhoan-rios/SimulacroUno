using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Simulacro1.Controllers.Edithorials
{
    public class EdithorialDeleteController : Controller
    {
        private readonly IEdithorialRepository _edithorialRepository;
        public EdithorialDeleteController(IEdithorialRepository edithorialRepository)
        {
            _edithorialRepository = edithorialRepository;
        }

        [HttpDelete]
        [Route("Edithorial/Delete/{id}")]
        public IActionResult Remove(int id){
            try
            {
                _edithorialRepository.Remove(id);
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
        [Route("Edithorial/Activar/{id}")]
        public IActionResult Activar(int id){
            try
            {
                _edithorialRepository.Activar(id);
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