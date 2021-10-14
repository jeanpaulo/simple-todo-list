using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        /// <summary>
        /// Obtem todas as categorias
        /// </summary>
        [HttpGet]
        [Route("api/categoria")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<Categoria>), (int)HttpStatusCode.OK)]
        public IActionResult ObterTodasCategorias()
        {
            try
            {
                List<Categoria> categorias = _context.Categorias.ToList<Categoria>();

                if(categorias == null) return BadRequest();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu algum erro na Action {nameof(ObterTodasCategorias)}: {ex}");
                return StatusCode(500, "Erro interno de servidor");
            }
            
        }


        /// <summary>
        /// Obtem uma categoria por Id
        /// </summary>
        /// <param name="pId">
        /// Id Categoria
        /// </param>
        [HttpGet]
        [Route("api/categoria/{pId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Categoria), (int)HttpStatusCode.OK)]
        public IActionResult ObterCategoriaPorId(Guid pId)
        {
            try 
            {
                Categoria categoria = _context.Categorias.Single<Categoria>(c => c.CategoriaId == pId);

                if(categoria == null) return NotFound();

                return Ok(categoria);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu algum erro na Action {nameof(ObterCategoriaPorId)}: {ex}");
                return StatusCode(500, "Erro interno de servidor");
            }
        }

        /// <summary>
        /// Desativar Categoria por Id
        /// </summary>
        /// <param name="pId">
        /// Id Categoria
        /// </param>
        [HttpGet]
        [Route("api/categoria/desativar/{pId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Categoria), (int)HttpStatusCode.OK)]
        public IActionResult DesativarCategoriaPorId(Guid pId)
        {
            try 
            {
                Categoria categoria = _context.Categorias.Single<Categoria>(c => c.CategoriaId == pId);

                if(categoria == null) return NotFound();

                categoria.Ativo = false;
                _context.SaveChanges();

                return Ok(categoria);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu algum erro na Action {nameof(DesativarCategoriaPorId)}: {ex}");
                return StatusCode(500, "Erro interno de servidor");
            }
        }

        /// <summary>
        /// Deletar Categoria
        /// </summary>
        /// <param name="pId">
        /// Id Categoria
        /// </param>
        [HttpGet]
        [Route("api/categoria/deletar/{pId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Categoria), (int)HttpStatusCode.OK)]
        public IActionResult DeletarCategoriaPorId(Guid pId)
        {
            try 
            {
                Categoria categoria = _context.Categorias.Single<Categoria>(c => c.CategoriaId == pId);
                if(categoria == null) return NotFound();

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return Ok("Deletado");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu algum erro na Action {nameof(DeletarCategoriaPorId)}: {ex}");
                return StatusCode(500, "Erro interno de servidor");
            }
        }

        /// <summary>
        /// Adiciona nova categoria
        /// </summary>
        [HttpPost]
        [Route("api/categoria")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Categoria), (int)HttpStatusCode.OK)]
        public IActionResult AdicionarCategoria([FromBody] Categoria categoriaJson)
        {
            try 
            {
                if (categoriaJson == null) return BadRequest();

                if (categoriaJson.CategoriaId == Guid.Empty) 
                {
                    categoriaJson.CategoriaId = Guid.NewGuid();
                }

                _context.Categorias.Add(categoriaJson);
                _context.SaveChanges();

                return CreatedAtAction(nameof(AdicionarCategoria), new { id = categoriaJson.CategoriaId }, categoriaJson);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu algum erro na Action {nameof(AdicionarCategoria)}: {ex}");
                return StatusCode(500, "Erro interno de servidor");
            }
        }


        // FALTA UPDATE
        
    }
}