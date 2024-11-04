using Festivos.Core.Servicios;
using Festivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festivos.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivoControlador : ControllerBase
    {
        private readonly IFestivosServicios _festivoServicio;

        // Inyecta el servicio en el constructor
        public FestivoControlador(IFestivosServicios festivoServicio)
        {
            _festivoServicio = festivoServicio;
        }

        // GET: api/FestivoControlador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerTodosLosFestivos()
        {
            var festivos = await _festivoServicio.ObtenerTodos();
            return Ok(festivos);
        }

        // GET: api/FestivoControlador/{fecha}
        [HttpGet("{fecha}")]
        public async Task<ActionResult> EsFestivo(DateTime fecha)
        {
            // Llama al servicio para comprobar si la fecha es festiva
            var esFestivo = await _festivoServicio.EsFestivo(fecha);
            if (!esFestivo)
            {
                return NotFound(new { mensaje = "La fecha proporcionada no es festiva" });
            }
            return Ok(new { mensaje = "La fecha proporcionada es festiva" });
        }

        // POST: api/FestivoControlador
        [HttpPost]
        public async Task<ActionResult> AgregarFestivo([FromBody] Festivo nuevoFestivo)
        {
            if (nuevoFestivo == null || string.IsNullOrEmpty(nuevoFestivo.Nombre))
            {
                return BadRequest(new { mensaje = "Los datos del festivo son inválidos o incompletos" });
            }

            await _festivoServicio.AgregarNuevoFestivo(nuevoFestivo);
            return CreatedAtAction(nameof(EsFestivo), new { fecha = new DateTime(1, nuevoFestivo.Mes, nuevoFestivo.Dia) }, nuevoFestivo);
        }

        // DELETE: api/FestivoControlador/{fecha}
        [HttpDelete("{fecha}")]
        public async Task<ActionResult> EliminarFestivo(DateTime fecha)
        {
            await _festivoServicio.EliminarFestivo(fecha);
            return NoContent();
        }
    }
}
