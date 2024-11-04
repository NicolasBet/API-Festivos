using Festivos.Core.Servicios;
using Festivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoController : ControllerBase
    {
        private readonly ITipoServicios _tipoServicios;

        public TipoController(ITipoServicios tipoServicios)
        {
            _tipoServicios = tipoServicios;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerTodos()
        {
            var tipos = await _tipoServicios.ObtenerTodosLosTipos();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> ObtenerDetallesDeTipo(int id)
        {
            var tipo = await _tipoServicios.ObtenerDetallesDeTipo(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarNuevoTipo([FromBody] Tipo tipo)
        {
            await _tipoServicios.AgregarNuevoTipo(tipo);
            return CreatedAtAction(nameof(ObtenerDetallesDeTipo), new { id = tipo.Id }, tipo);
        }
    }
}
