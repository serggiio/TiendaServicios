using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;
using static TiendaServicios.Api.Autor.Controllers.AutorController;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<List<AutorDto>>> GetAutores()
        {
            const string HeaderKeyName = "HeaderKey";
            Request.Headers.TryGetValue(HeaderKeyName, out StringValues headerValue);

            if (!headerValue.Any() || headerValue.ElementAt(0) == string.Empty)
            {
                return Unauthorized();
            }
            else if (headerValue.Count() > 1)
            {
                return BadRequest();
                // return NotFound();
                // return NoContent();
            }

            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutorLibro(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico{ AutorGuid = id });
        }
    }
}
