using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simple_todo_list.Infra;
using simple_todo_list.Models;

namespace simple_todo_list.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        public ILogger<CategoriaController> _logger { get; }
        public ContextoGeral _context { get; }
        
        public CategoriaController(
            ILogger<CategoriaController> logger,
            ContextoGeral context )
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var x = "x";

            var result = _context.Categorias;

            return Ok(result);
        }

        
    }
}