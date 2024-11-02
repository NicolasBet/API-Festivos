using Festivos.Core.Servicios; // Asegúrate de que la interfaz correcta esté aquí
using Festivos.Dominio.Entidades; // Asegúrate de que la entidad "Festivo" esté aquí
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
        public async Task<ActionResult<Festivo>> EsFestivo(DateTime fecha)
        {
            var festivo = await _festivoServicio.EsFestivo(fecha);
            if (festivo == null)
            {
                return NotFound(new { mensaje = "La fecha proporcionada no es festiva" });
            }
            return Ok(festivo);
        }

        // POST: api/FestivoControlador
        [HttpPost]
        public async Task<ActionResult> AgregarFestivo([FromBody] Festivo nuevoFestivo)
        {
            await _festivoServicio.AgregarNuevoFestivo(nuevoFestivo);
            return CreatedAtAction(nameof(EsFestivo), new { fecha = nuevoFestivo.Fecha }, nuevoFestivo);
        }
    }
}
