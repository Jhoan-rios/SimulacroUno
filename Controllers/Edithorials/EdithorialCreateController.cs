using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Simulacro1.Controllers.Edithorials
{
    public class EdithorialCreateController : Controller
    {
        private readonly IEdithorialRepository _edithorialRepository;
        public EdithorialCreateController(IEdithorialRepository edithorialRepository)
        {
            _edithorialRepository= edithorialRepository;
        }
        [HttpPost]
        [Route("Edithorial/Create")]
        public IActionResult Create([FromBody] Edithorial edithorial)
        {
            _edithorialRepository.Add(edithorial);
            return Ok();
        }
    }
}