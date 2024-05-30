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
    public class EdithorialUpdateController : Controller
    {
        private readonly IEdithorialRepository _edithorialRepository;
        public EdithorialUpdateController(IEdithorialRepository edithorialRepository)
        {
            _edithorialRepository = edithorialRepository;
        }

        [HttpPut]
        [Route("Edithorial/Update/{id}")]
        public IActionResult Update([FromBody] Edithorial edithorial){
            _edithorialRepository.Update(edithorial);
            return Ok();
        }

    }
}