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
    public class EdithorialsController : Controller
    {
        private readonly IEdithorialRepository _edithorialRepository;
        public EdithorialsController(IEdithorialRepository edithorialRepository)
        {
            _edithorialRepository = edithorialRepository;
        }

        [HttpGet]
        [Route("Edithorial")]
        public IEnumerable<Edithorial> GetEdithorials(){
            return _edithorialRepository.GetAll();
        }
        [HttpGet]
        [Route("EdithorialInactivo")]
        public IEnumerable<Edithorial> GetEdithorialsInactivo(){
            return _edithorialRepository.GetAllInactivo();
        }

        [HttpGet]
        [Route("Edithorial/{id}")]
        public ActionResult<Edithorial> Details(int id){
            var edithorial = _edithorialRepository.GetById(id);
            if(edithorial == null)
            {
                return NotFound();
            }
            return Ok(edithorial);
        }
    }
}